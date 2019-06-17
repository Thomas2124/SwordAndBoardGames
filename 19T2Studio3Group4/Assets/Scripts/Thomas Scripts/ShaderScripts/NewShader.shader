Shader "Custom/NewShader"
{
	//stuff that can be seen in the inspector
	Properties
	{
		_Color("Tint", Color) = (0, 0, 0, 1) //Main colour of the texture
		_MainTex("Texture", 2D) = "white" {} //Texture
		_Smoothness("Smoothness", Range(0, 1)) = 0 //Roughness of the surface
		_Metallic("Metalness", Range(0, 1)) = 0 //if you want it to look like metal or not
		[HDR] _Emission("Emission", Color) = (0, 0, 0, 1) //if you want it to glow
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" "Queue" = "Geometry"}

		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows //#pragma (what kind of shader) (name of method) (what kind of lighting model)
		#pragma target 3.0 //uses higher precision values for better lighting and shadows

		sampler2D _MainTex;
		fixed4 _Color;
		half _Smoothness;
		half _Metallic;
		half3 _Emission;

		//Information that is needed to set the colour of the texture
		struct Input 
		{
			float2 uv_MainTex; //UV coordinates
		};

		//Method for surface related stuff
		void surf(Input i, inout SurfaceOutputStandard o) 
		{
			fixed4 col = tex2D(_MainTex, i.uv_MainTex);
			col *= _Color;
			o.Albedo = col.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Emission = _Emission;
		}
		ENDCG
	}
	FallBack "Standard" //"Standard" create shadows on other surfaces
}
