Shader "Custom/Unlit/HorizontalGradient"
{
    Properties
    {
		[PerRendererData] _MainTex("Texture", 2D) = "white" {}
		_ColorTop("Top Color", Color) = (1,1,1,1)
		_ColorMid("Middle Color", Color) = (1,1,1,1)
		_ColorBot("Bottom Color", Color) = (1,1,1,1)
		_ValueMid("Middle Value", Range(0.001, 0.999)) = .5
    }
    SubShader
    {
		Tags {"Queue" = "Background" "IgnoreProjector" = "True"}
		LOD 100
		ZWrite On

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			fixed4 _ColorTop;
			fixed4 _ColorMid;
			fixed4 _ColorBot;
			float  _ValueMid;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float4 texcoord : TEXTCOORD0;
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.texcoord = v.texcoord;
				return o;
			}

			fixed4 frag(v2f i) : COLOR
			{
				fixed4 c = lerp(_ColorBot, _ColorMid, i.texcoord.y / _ValueMid) * step(i.texcoord.y, _ValueMid);
				c += lerp(_ColorMid, _ColorTop, (i.texcoord.y - _ValueMid) / (1 - _ValueMid)) * step(_ValueMid, i.texcoord.y);
				c.a = 1;
				return c;
			}
			ENDCG
		}
    }
}
