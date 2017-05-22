Shader "Unlit/sd_AlphaMovie"
{
	Properties
	{
		_Color("Color",Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_CenterAlpha("Center Alpha",Float) = 1
		_SideAlpha("Side Alpha",Float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue" = "Transparent+40" }
		LOD 100
			cull off
		CGPROGRAM
#pragma vertex vert
#pragma surface surf NoLighting alpha

		sampler2D _MainTex;
	float4 _Color;
	float _SideAlpha;
	float _CenterAlpha;
	//sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
		float distanceAlpha;
		//float2 uv;
	};




	void vert(inout appdata_base v, out Input o)
	{
		UNITY_INITIALIZE_OUTPUT(Input, o);
		//o.posXZ.x = v.vertex.x;
		//o.posXZ.y = v.vertex.z;
		//o.uvXZ = v.texcoord.xy;
	}

	void surf(Input IN, inout SurfaceOutput o)
	{

		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = c.rgb*_Color;
		/*if (!(length(c.rgb) > 0))
		{
			o.Alpha = 0;
		}*/
		//float distance = length(IN.posXZ);
		float distance = length(IN.uv_MainTex);
		o.Alpha = c.r* lerp(_CenterAlpha, _SideAlpha, distance);// saturate(lerp(_CenterAlpha, _SideAlpha, distance));
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


