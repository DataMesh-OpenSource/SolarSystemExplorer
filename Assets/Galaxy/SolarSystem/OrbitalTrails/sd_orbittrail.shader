Shader "Custom/OrbitTrail_AutoSuit"
{
	Properties
	{
		_CircleRampMap("轨迹渐变贴图：", 2D) = "white" {}
		_WidthRampMap("横向渐变贴图：", 2D) = "white" {}
		_OrbitColor("Orbit Color", Color) = (0.7,0.9,1,0)
		_CurrentRadian("Current Radian",Float) = 0
		_Radius("Radius",Float) = 0.1
		_Width("Width",Float) = 0.001
		_TotalAlpha("Total Alpha",Range(0,1)) = 1
	}

		// Common water code that will be used in all CGPROGRAMS below
		CGINCLUDE
#include "UnityCG.cginc"

	float4 _OrbitColor;
	float _CurrentRadian;
	sampler2D _CircleRampMap;
	sampler2D _WidthRampMap;
	float _Radius;
	float _Width;
	float _TotalAlpha;

	struct Input
	{
		float2 uv_CircleRampMap;
		float alphaValue;
	};

	void vert(inout appdata_full v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input, o);
		//half4 c = tex2Dlod(_CircleRampMap, float4(v.texcoord.xy, 0, 0));

		v.vertex.xyz = normalize(v.vertex.xyz)*(_Radius - (v.texcoord.y - 0.5)*_Width);

		
		
	}



	void surf(Input IN, inout SurfaceOutput o)
	{
		float widthAlpha = tex2D(_WidthRampMap, IN.uv_CircleRampMap.yx).a;
		
		float circleAlpha = tex2D(_CircleRampMap, IN.uv_CircleRampMap+(0,_CurrentRadian/6.2832)).a;
		o.Albedo = _OrbitColor.rgb;
		o.Alpha = circleAlpha*widthAlpha*_TotalAlpha;
	}




	ENDCG

		Category
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Opaque" }

		cull off
		SubShader
	{
		Lod 500
		CGPROGRAM

#pragma vertex vert
#pragma surface surf Lambert alpha

		ENDCG

	}

	}
}
