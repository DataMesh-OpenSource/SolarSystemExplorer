Shader "Custom/SingleWave" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	//_Color2("Second Color", Color) = (1,1,1,1)
	_MainTex ("Trans (A)", 2D) = "white" {}
	_OrbitAlpha("Trans (A)", 2D) = "white" {}
    //_GlowTex ("Glow", 2D) = "" {}
	//_GlowColor("Glow Color", Color) = (1,1,1,0)
	//_GlowStrength("Glow Strength", Float) = 1.0
	//_Center("Center",Vector) = (0,0,0)
	//_LeftBorder("Left Border",Float) = 0
	_CurrentZ("CurrentZ", Float) = 0
	_ProcessLength("ProcessLength",Range(0.1,6.28)) = 1
}

SubShader {
	Tags{ "Queue" = "Transparent+40" "RenderType" = "Glow11Transparent" }
	LOD 200

CGPROGRAM
#pragma vertex vert
#pragma surface surf Lambert alpha

sampler2D _MainTex;
fixed4 _Color;
//fixed4 _Color2;
//float3 _Center;
float _CurrentZ;
float _ProcessLength;

struct Input {
	float2 uv_MainTex;
	float distance;
	float x;
	float z;
};


float getFirstWaveAlpha(float distance)
{
	float value1 = 1-saturate(distance  / _ProcessLength);
	//float value2 = saturate(sign(distance - _ProcessLength));
	return value1;// -value2;
}


void vert(inout appdata_base v, out Input o)
{
	UNITY_INITIALIZE_OUTPUT(Input, o);
	o.distance = abs(_CurrentZ - v.vertex.x);
	o.x = v.vertex.x;
	o.z = v.vertex.z;
}

void surf (Input IN, inout SurfaceOutput o) {

	float alphaValue = getFirstWaveAlpha(IN.distance);
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex);//*_Color;
	o.Albedo = _Color;
	o.Alpha =  c.r * alphaValue;
}
ENDCG
}


}
