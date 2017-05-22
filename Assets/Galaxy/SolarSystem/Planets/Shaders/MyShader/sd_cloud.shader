Shader "Custom/SimpleCloud" 
{
	Properties
	{
		_SunDirection("Sun Direction", Vector) = (1,1,1,0)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_NormalMap("Normal Map", 2D) = "bump" {}
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Opaque" }
		LOD 100
		//cull off
		//Lighting Off
		CGPROGRAM
#pragma vertex vert
#pragma surface surf Lambert alpha
#include "UnityCG.cginc"

			struct Input
		{
			float3 position;// :SV_POSITION;
			float2 uv_MainTex;
			float2 uv_NormalMap;
		};

		float4 _SunDirection;
		sampler2D _MainTex;
		sampler2D _NormalMap;
		float _ReflAmount;

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			//float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
			o.position = mul((float3x3)unity_ObjectToWorld, v.vertex.xyz);
		}

		void surf(Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			float3 normals = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap)).rgb;
			o.Normal = normals;

			float sunDot = dot(normalize(_SunDirection), normalize(IN.position.xyz));
			sunDot = saturate(sunDot * 5 + 0.5);
			/*if (sunDot > 0.1)
			{
				sunDot = 1;
			}
			else if(sunDot>-0.1)
			{
				sunDot*=10;
			}
			else
			{
				sunDot = -1;
			}*/

			float nightFactor = lerp(0.5, 1.2, sunDot);

			//o.Emission = texCUBE(_Cubemap, WorldReflectionVector(IN, o.Normal)).rgb * _ReflAmount;
			//o.Albedo = nightFactor;// sunDot;//c.rgb*1;// *_MainTint;
			o.Albedo = c.rgb*nightFactor;
			o.Alpha = c.a;
		}

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}

		ENDCG
		
	}
}