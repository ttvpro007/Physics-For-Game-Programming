Shader "Custom/Unlit/CustomUnlitShader"
{
	Properties
	{
		_MainTexture("Main Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
		SubShader
		{
			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				sampler2D _MainTexture;
				fixed4 _Color;

				struct appdata
				{
					float3 position : POSITION;
					float2 uv : TEXCOORD0;
					float3 normal : NORMAL;
				};

				struct v2f
				{
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
					float3 normal : NORMAL;
				};

				v2f vert(appdata i)
				{
					v2f o;
					float4 homogenousPos = float4(i.position, 1);
					o.position = UnityObjectToClipPos(homogenousPos);
					o.uv = i.uv;
					o.normal = i.normal;
					return o;
				}

				float4 frag(v2f i) : SV_TARGET
				{
					//return _Color;
					//return float4(i.uv, 0, 1);
					//return float4(i.normal, 1);
					return tex2D(_MainTexture, i.uv) * _Color;
				}

			ENDCG
		}
	}
}
