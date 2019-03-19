Shader "Tavio/Sprites/ConicalAlphaGradient" {
	Properties{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
        _Center("Center", Vector) = (0.5,0.5,0,0)
        _ColorCount("Color Count", int) = 3
		_AlphaCount("Alpha Count", int) = 3
		_InnerRadius("Inner Radius", float) = 0.0
		_OuterRadius("Outer Radius", float) = 0.7
        _iniAngle("Ini Angle", Range(0,360)) = 0
        _endAngle("End Angle", Range(0,360)) = 360
	}
	SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		Cull Off

		Blend SrcAlpha OneMinusSrcAlpha
		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

            sampler2D _MainTex;
            uniform fixed4 _Colors[32];
            uniform fixed _ColorAnchors[32];
            fixed4 _CurrentColor;
            fixed4 _NextColor;
            int _ColorCount = 0;

            half _OuterRadius = 0;
            half _InnerRadius;
            half _iniAngle;
            half _endAngle;

            uniform fixed _Alphas[32];
            uniform fixed _AlphaAnchors[32];
            fixed _CurrentAlpha;
            fixed _NextAlpha;
            int _AlphaCount = 0;
            float2 _Center;

		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv : TEXCOORD0;
		};

		v2f vert(appdata_base v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		fixed4 frag(v2f i) : COLOR
		{

            float2 delta = i.uv - _Center;
                
            float pos = atan2(delta.x, delta.y) * 0.15 + 0.5;

            float xdist = length(i.uv - float2(0.5, 0.5)) * 1.41421356237;

            clip(pos - _iniAngle/ 360 );
            clip((_endAngle / 360) - pos);

            clip(xdist - _InnerRadius);
            clip(_OuterRadius - xdist);

            fixed4 oricol = tex2D(_MainTex, i.uv);


            fixed colorAnchor;
            fixed nextColorAnchor;

            for (int j = 0; j < _ColorCount; j++) {
                colorAnchor = _ColorAnchors[j];
                nextColorAnchor = _ColorAnchors[j + 1];
                if (pos >= colorAnchor && pos < nextColorAnchor) {
                    _CurrentColor = _Colors[j];
                    _NextColor = _Colors[j + 1];
                    j = _ColorCount;
                }
            }
            
            fixed alphaAnchor;
            fixed nextAlphaAnchor;

            for (int k = 0; k < _AlphaCount; k++) {
                alphaAnchor = _AlphaAnchors[k];
                nextAlphaAnchor = _AlphaAnchors[k + 1];
                if (pos >= alphaAnchor && pos < nextAlphaAnchor) {
                    _CurrentAlpha = _Alphas[k];
                    _NextAlpha = _Alphas[k + 1];
                    k = _AlphaCount;
                }
            }

            fixed4 result = lerp(_CurrentColor, _NextColor, smoothstep(colorAnchor, nextColorAnchor, pos));
        
            result.w = lerp(_CurrentAlpha, _NextAlpha, smoothstep(alphaAnchor, nextAlphaAnchor, pos)) * oricol.w;
        

            return result;
		}

		ENDCG
	}
	}
		FallBack "Diffuse"
}