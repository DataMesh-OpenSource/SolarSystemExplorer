// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/OccluderShader"
{
    Properties
    {
        _TransitionAlpha("Transition Alpha", Float) = 0
    }
        SubShader
        {
            Tags { "Queue" = "Overlay" }
            ZTest Always
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                };

                struct v2f
                {
                    float4 vertex : POSITION;
                };

                float _TransitionAlpha;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    return o;
                }

                float4 frag(v2f i) : SV_Target
                {
                    return float4(0,0,0,_TransitionAlpha);
                }
                ENDCG
            }
        }
}
