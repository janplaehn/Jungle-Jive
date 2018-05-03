Shader "Custom/DizzyShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ScreenSplitMin("Screen Split Minimum Percentage", float) = 0
		_ScreenSplitMax("Screen Split Maximum Percentage", float) = 0
		_SineWaveHeight("Sine Wave Height", float) = 0
		_WobInt("Wobble Intensity", float) = 0
		_WaveLengthDiv("Wave Length Divisor", float) = 0
		_IsInverted("Is inverted", float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _ScreenSplitMax;
			float _ScreenSplitMin;
			float _SineWaveHeight;
			float _WobInt;
			float _WaveLengthDiv;
			float _IsInverted;

			fixed4 frag (v2f i) : SV_Target
			{
				if (i.vertex.x >= _ScreenParams.x * _ScreenSplitMin && i.vertex.x <= _ScreenParams.x * _ScreenSplitMax){
					fixed4 col = tex2D(_MainTex, i.uv + float2(0, sin(i.vertex.x/ _WaveLengthDiv + _Time[0] * _WobInt) * _SineWaveHeight / 10));
					col = abs(1 * _IsInverted - col);
					return col;
				}
				fixed4 col = tex2D(_MainTex, i.uv);

				return col;
			}
			ENDCG
		}
	}
}
