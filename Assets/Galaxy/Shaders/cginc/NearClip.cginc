// This is implemented here in functions designed to be used from both
// the vertex shader and the pixel shader.  Most objects are fine using the vert
// shader version of this, but certian FX, like the glow card on the sun, require
// this calculation to be done per pixel


struct PixelFromCamera
{
	min16float3 posFromCamera;
	min16float3 distance;
	min16float3 direction;
};

void CalcPixelFromCamera(min16float3 worldPos, inout PixelFromCamera pixelFromCamera)
{
	pixelFromCamera.posFromCamera = worldPos - _WorldSpaceCameraPos;
	pixelFromCamera.distance = length(pixelFromCamera.posFromCamera);
	pixelFromCamera.direction = pixelFromCamera.posFromCamera / pixelFromCamera.distance;
}

#define _CLIP_START ((min16float)0.5)
#define _CLIP_END ((min16float)0.7)
#define _CLIP_BIAS ((min16float)0)

min16float4 ApplyNearClip(min16float4 color, PixelFromCamera pixelFromCamera)
{
	min16float clipAmount = saturate(((pixelFromCamera.distance + _CLIP_BIAS) - _CLIP_START) / (_CLIP_END - _CLIP_START));
	return min16float4(color.rgb * clipAmount, color.a);
}


float CalcVertClipAmount(float3 worldPos)
{
	float distance = length(worldPos - _WorldSpaceCameraPos);
	return saturate(((distance + _CLIP_BIAS) - _CLIP_START) / (_CLIP_END - _CLIP_START));
}

min16float4 ApplyVertClipAmount(min16float4 color, min16float clipAmount)
{
	return min16float4(color.rgb * clipAmount, color.a);
}