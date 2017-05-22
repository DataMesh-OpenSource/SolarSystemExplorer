// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Planets/OrbitalTrail" 
{
	Properties
	{
		[HDR] _Color("Color", Color) = (1,1,1,1)
		[HDR] _PlanetHighlightColor ("Highlight Color", Color) = (0,0,0,0)

		_MainTex("Falloff Texture", 2D) = "white" {}
		_TransitionAlpha("Transition Alpha", Float) = 1
		_Truthfulness("Truthfulness (0 = schematic, 1 = real)", Float) = 1
		_Width ("Width", Float) = .012

		_GlobalScale ("Global Scale", Float) = 1
		_FadeOffDistanceAroundPlanet ("FadeOff Distance Around Planet", Float) = 1
		_TrailTailAngle ("Tail Angle Offset", Float) = 1
	}

	SubShader
	{
		Tags
		{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
		}
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma geometry geo
				#pragma target 5.0
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma multi_compile _ IN_TRANSITION REALSCALE SCHEMATIC

				#include "UnityCG.cginc"
				#include "/./../../Shaders/cginc/NearClip.cginc"

#define MAX_ORBIT 9

				struct OrbitDataPoint
				{
					float3 realPos;
					float3 schematicPos;
					uint globalIndex;

					uint orbitStartIndex;
					uint orbitEntryCount;
					uint orbitIndex;
				};

				struct v2g 
				{
					float4 planetPosAndRadius : TEXCOORD0;
					float3 wPos[2] : TEXCOORD1;
					float4 points[4] : TEXCOORD3;
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					float2 texCoord : TEXCOORD1;
					float3 wPos : TEXCOORD2;
					float4 planetPosAndRadius : TEXCOORD3;
					float3 nextDirection : TEXCOORD4;
					float  clipAmount : TEXCOORD5;
				};

				float4 _Color;
				float4 _PlanetHighlightColor;

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _TransitionAlpha;

				float _Truthfulness;

				float4x4 _Orbits2World;
				float _Width;

				StructuredBuffer<OrbitDataPoint> _OrbitsData;

				float _FadeOffDistanceAroundPlanet;
				float _GlobalScale;
				float _TrailTailAngle;

				float4 planetPositionsAndRadius0;
				float4 planetPositionsAndRadius1;
				float4 planetPositionsAndRadius2;
				float4 planetPositionsAndRadius3;
				float4 planetPositionsAndRadius4;
				float4 planetPositionsAndRadius5;
				float4 planetPositionsAndRadius6;
				float4 planetPositionsAndRadius7;
				float4 planetPositionsAndRadius8;


				uint tIndex(uint index, OrbitDataPoint origin)
				{
					return origin.orbitStartIndex + (index + origin.orbitEntryCount) % origin.orbitEntryCount;
				}

				float4 selectPlanet(int index)
				{
					[flatten]
					switch (index)
					{
						default:
						case 0: return planetPositionsAndRadius0;
						case 1: return planetPositionsAndRadius1;
						case 2: return planetPositionsAndRadius2;
						case 3: return planetPositionsAndRadius3;
						case 4: return planetPositionsAndRadius4;
						case 5: return planetPositionsAndRadius5;
						case 6: return planetPositionsAndRadius6;
						case 7: return planetPositionsAndRadius7;
						case 8: return planetPositionsAndRadius8;
					}
				}

				v2g vert(uint id : SV_VertexID)
				{
					OrbitDataPoint p1 = _OrbitsData[id];

					OrbitDataPoint p0 = _OrbitsData[tIndex(p1.globalIndex - 1, p1)];
					OrbitDataPoint p2 = _OrbitsData[tIndex(p1.globalIndex + 1, p1)];
					OrbitDataPoint p3 = _OrbitsData[tIndex(p1.globalIndex + 2, p1)];

					float3 realPoints[4] = 
					{
						p0.realPos,
						p1.realPos,
						p2.realPos,
						p3.realPos,
					};

					float3 schematicPoints[4] =
					{
						p0.schematicPos,
						p1.schematicPos,
						p2.schematicPos,
						p3.schematicPos,
					};

					float4x4 mvp = mul(UNITY_MATRIX_VP, _Orbits2World);

#if IN_TRANSITION
					float truthfulness = _Truthfulness;
#elif REALSCALE
					const float truthfulness = 1;
#else // SCHEMATIC
					const float truthfulness = 0;
#endif

					v2g o;

					float3 wPos[2];
					wPos[0] = mul(_Orbits2World, float4(lerp(schematicPoints[1], realPoints[1], truthfulness), 1)).xyz;
					wPos[1] = mul(_Orbits2World, float4(lerp(schematicPoints[2], realPoints[2], truthfulness), 1)).xyz;

					float4 points[4];
					points[0] = mul(mvp, float4(lerp(schematicPoints[0], realPoints[0], truthfulness), 1));
					points[1] = mul(mvp, float4(lerp(schematicPoints[1], realPoints[1], truthfulness), 1));
					points[2] = mul(mvp, float4(lerp(schematicPoints[2], realPoints[2], truthfulness), 1));
					points[3] = mul(mvp, float4(lerp(schematicPoints[3], realPoints[3], truthfulness), 1));
					
					o.points = points;

					o.planetPosAndRadius = selectPlanet(p1.orbitIndex);
					o.wPos = wPos;

					return o;
				}

				[maxvertexcount(4)]
				void geo(point v2g input[1], inout TriangleStream<v2f> triStream)
				{
					v2g p = input[0];
					float4 points[4] = p.points;
					float4 correctPoints[4];

					[unroll]
					for (int i = 0; i < 4; i++)
					{
						correctPoints[i] = points[i] / abs(points[i].w);
					}

					float3 directions3D[3];
					directions3D[0] = (correctPoints[1] - correctPoints[0]);
					directions3D[1] = (correctPoints[2] - correctPoints[1]);
					directions3D[2] = (correctPoints[3] - correctPoints[2]);

					float2 directions[3];
					directions[0] = normalize(directions3D[0].xy);
					directions[1] = normalize(directions3D[1].xy);
					directions[2] = normalize(directions3D[2].xy);
					
					float2 spTangents[2];
					spTangents[0] = normalize(directions[1] + directions[0]);
					spTangents[1] = normalize(directions[2] + directions[1]);

					float2 sides[2];
					sides[0] = cross(float3(spTangents[0].xy, 0), float3(0, 0, 1)).xy;
					sides[1] = cross(float3(spTangents[1].xy, 0), float3(0, 0, 1)).xy;

					float4 v[4];
					v[0] = float4(p.points[1] - _Width * float3(sides[0], 0) * p.points[1].w, p.points[1].w);
					v[1] = float4(p.points[1] + _Width * float3(sides[0], 0) * p.points[1].w, p.points[1].w);
					v[2] = float4(p.points[2] - _Width * float3(sides[1], 0) * p.points[2].w, p.points[2].w);
					v[3] = float4(p.points[2] + _Width * float3(sides[1], 0) * p.points[2].w, p.points[2].w);
					
					float clipAmount = CalcVertClipAmount(p.wPos[0]);


					v2f pIn = (v2f)0;
					pIn.planetPosAndRadius = p.planetPosAndRadius;
					pIn.nextDirection = normalize(p.wPos[1] - p.wPos[0]);
					
					pIn.vertex = v[0];
					pIn.texCoord = float2(0, 1);
					pIn.wPos = p.wPos[0];
					pIn.clipAmount = clipAmount;
					triStream.Append(pIn);

					pIn.vertex = v[1];
					pIn.texCoord = float2(1, 1);
					pIn.wPos = p.wPos[0];
					pIn.clipAmount = clipAmount;
					triStream.Append(pIn);

					pIn.vertex = v[2];
					pIn.texCoord = float2(0, 1);
					pIn.wPos = p.wPos[1];
					pIn.clipAmount = clipAmount;
					triStream.Append(pIn);

					pIn.vertex = v[3];
					pIn.texCoord = float2(1, 1);
					pIn.wPos = p.wPos[1];
					pIn.clipAmount = clipAmount;
					triStream.Append(pIn);

					return;
				}

				fixed4 frag(v2f i) : COLOR
				{			
					float3 toPlanet = i.wPos - i.planetPosAndRadius.xyz;
					float distanceFromPlanet = length(toPlanet);

					toPlanet = normalize(toPlanet);
					
					float planetDistanceOpacity = saturate(distanceFromPlanet / _FadeOffDistanceAroundPlanet / _GlobalScale);
					planetDistanceOpacity = lerp(planetDistanceOpacity, 1, dot(i.nextDirection, toPlanet) < 0);

					float4 planetTailHighlight = lerp(_PlanetHighlightColor, 0, saturate(dot(i.nextDirection, toPlanet) - _TrailTailAngle));

					min16float4 finalColor = tex2D(_MainTex, i.texCoord).aaaa * (_Color + planetTailHighlight) * planetDistanceOpacity * _TransitionAlpha;

					return ApplyVertClipAmount(finalColor, i.clipAmount);
				}
				ENDCG
			}
		}
	FallBack "Diffuse"
}
