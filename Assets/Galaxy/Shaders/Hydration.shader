Shader "Custom/HydrationEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_ColorTex("Texture", 2D) = "white" {}
		__Size("Point Size", Range(0,0.03)) = 0.025
		__PointPushScale("Point PushScale", vector) = (0,1,0,0)
		__PointColor("Point Color", Color) = (0.3,0.65,1,1)
		__FillColor("Fill Color", Color) = (1,1,1,1)
		__Hydrate("Hydrate", Range(0,1)) = 0
		__NoiseScale("Noise Scale", vector) = (20,50,20,8)
	}

	SubShader
	{
		Pass		//Wireframe and fill pass.
		{
			Tags
			{
				"RenderType" = "Opaque"
				"Queue" = "Opaque"
			}

			ZWrite On
			Lighting Off
			Cull Back

			CGPROGRAM

			#pragma target 4.0
			#pragma vertex vert
			#pragma fragment frag
			#include ".\cginc\Hydration_WireframeContent.cginc"

			ENDCG
		}

		Pass		//Points of light pass.
		{
			Tags
			{ 
				"RenderType" = "Transparent"
				"Queue" = "Transparent"    
			} 

			ZTest Off
			ZWrite Off
			Lighting Off
			Cull Back
			Blend One One

			CGPROGRAM
			#pragma target 5.0
			#pragma vertex vert
			#pragma geometry geo
			#pragma fragment frag

			#include ".\cginc\Hydration_PointsContent.cginc"

			ENDCG
		}
		
		
	}
	CustomEditor "EscherMaterialEditor"
}
