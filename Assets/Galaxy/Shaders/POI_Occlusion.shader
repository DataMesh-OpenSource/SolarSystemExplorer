// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "POI_Occlusion"
{
	Properties
	{
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"Queue" = "Transparent+99"
		}

		Pass
		{
			Lighting Off
			ColorMask 0
			Cull Off
			ZWrite On
			Blend One Zero

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
			    float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			min16float4 frag(v2f i) : SV_Target
			{
			    return 1;
			}
			ENDCG
		}
	}
}
