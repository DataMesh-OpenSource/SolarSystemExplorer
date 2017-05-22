Shader "Custom/PlanetExplosion" {
	Properties{
		_ExpandRadius("爆散半径",Float) = 2
		//_MeltRadius("融化变色半径",Float) = 0
		//_DisappearPercent("消失",Range(0,1)) = 0
		_ExpandCenter("爆散中心",Vector) = (0,0,0)

		_BeginColor("Begin Color",Color) = (0.3,0.3,0.3)
		_MeltColor("MeltColor", Color) = (0.9,1,0,1)
		_FinalColor("Final Color",Color) = (0.4,0.4,0,0)

		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Opaque" }
		LOD 100
		//cull off
		//Lighting Off
		CGPROGRAM
#pragma vertex vert
#pragma surface surf BlinnPhong alpha// alpha// NoLighting//
#include "UnityCG.cginc"


		sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
		float meltPercent;
		float finalPercent;
	};

	float _ExpandRadius;
	//float _MeltRadius;
	//float _DisappearPercent;
	float3 _ExpandCenter;

	float4 _MeltColor;
	float4 _FinalColor;
	float4 _BeginColor;

	void vert(inout appdata_full v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input, o);
		float3 fracCenterPos = (v.texcoord.x, 0, v.texcoord.y);
		fracCenterPos = mul((float3x3)unity_ObjectToWorld, fracCenterPos);
		//float3 fracWorldPosition = mul((float3x3)unity_ObjectToWorld, fracCenterPos);
		float3 expandCenterLocalPos = _ExpandCenter;// mul((float3x3)unity_WorldToObject, _ExpandCenter);
		//float distance = length(fracWorldPosition - _ExpandCenter);

		float3 directionVector = fracCenterPos - expandCenterLocalPos;
		//float3 inazuma = fracCenterPos - normalize(directionVector);
		float distance = length(directionVector);
		//directionVector.y = 0;
		//directionVector.z *= 1.5;
		//directionVector.x *= 1.4;
		//float3 moveCenter = fracCenterPos - directionVector;

		o.meltPercent = saturate((_ExpandRadius - distance) / 4);
		//o.meltPercent = saturate(o.meltPercent);
		float expand = max(0, (_ExpandRadius - distance) / 6);
		o.finalPercent = saturate(expand - 0.5);
		v.vertex.xyz += mul((float3x3)unity_WorldToObject, expand*directionVector * 2);// (normalize(directionVector)) * 10;

		o.uv_MainTex = v.texcoord2;


	}

	void surf(Input IN, inout SurfaceOutput o) {
		//// Albedo comes from a texture tinted by color
		//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		//o.Albedo = c.rgb;
		//// Metallic and smoothness come from slider variables
		//o.Metallic = _Metallic;
		//o.Smoothness = _Glossiness;
		//o.Alpha = c.a;
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

		float4 tempRGBA = lerp(c, _MeltColor, IN.meltPercent);
		tempRGBA = lerp(tempRGBA, _FinalColor, IN.finalPercent);
		o.Albedo = tempRGBA.rgb;
		o.Alpha = tempRGBA.a*(1 - IN.finalPercent);
		//o.Albedo = (IN.distance > _SlightMoveRadius) ? _MeltColor.xyz:_FinalColor.xyz;
		o.Emission = _MeltColor * IN.finalPercent*(1 - IN.finalPercent) * 8;
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
