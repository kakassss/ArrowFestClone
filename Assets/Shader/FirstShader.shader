Shader "Holistic/Hey"{

Properties{
		myColour("Example Colour",Color) = (1,1,1,1)
		myEmission("Example Emission",Color) = (1,1,1,1)
		myNormal("Example Normal",Color) = (1,1,1,1)
}
SubShader{
	CGPROGRAM
	#pragma surface surf Lambert

	struct Input {
		float2 uvMainText;
	};
fixed4 myColour;
fixed4 myEmission;
fixed4 myNormal;

void surf(Input IN, inout SurfaceOutput o) {
	o.Emission = myColour.rgb;
	o.Albedo = myEmission.rgb;
	o.Normal = myNormal.rgb;
}
ENDCG


	}
	FallBack "Diffuse"
}