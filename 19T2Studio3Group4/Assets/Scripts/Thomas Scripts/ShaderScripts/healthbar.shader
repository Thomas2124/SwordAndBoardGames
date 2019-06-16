Shader "Custom/healthbar"
{
	//show values to edit in inspector
	Properties
	{
		_Color("Tint", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
	}

		Subshader
	{
		Pass
		{
		//the material is completely non-transparent and is rendered at the same time as the other opaque geometry
		Tags
		{
			"RenderType" = "Opaque"
			"Queue" = "Geometry"
		}

		CGPROGRAM
		#include "unityCG.cginc"

		#pragma vertex vert
		#pragma fragment frag
		//#pragma shaderFunction

		sampler2D _MainTex;
		fixed4 _Color;

		struct appdata 
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
		};

		struct v2f 
		{
			float4 position : SV_POSITION;
			float2 uv : TEXTCOORD0;
		};

		v2f vert(appdata v) 
		{
			v2f o;
			//calculate the position in clip space to render the object
			o.position = UnityObjectToClipPos(v.vertex);
			o.uv = v.uv;
			return o;
		}

		fixed4 frag(v2f i) : SV_TARGET
		{
			//Return the color the Object is rendered in
			fixed4 col = tex2D(_MainTex, i.uv);
			col *= _Color;
			return col;
		}
		ENDCG
		}
	}
}
