Shader "Sonic Ether/Particles/Additive ZTest Always" {
	Properties{
		_TintColor("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("Particle Texture", 2D) = "white" {}
		_InvFade("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_EmissionGain("Emission Gain", Range(0, 1)) = 0.3
		_ColorBlend("Color Blend", Range(0, 1)) = 0.0
		_SecondColor("Second Color", Color) = (0.0,0.0,1.0,1.0)
	}

		Category{
			Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			AlphaTest Greater .01
			ColorMask RGB
			Cull Off Lighting Off ZWrite On ZTest Always Fog { Color(0,0,0,0) }

			SubShader {
				Pass {
					CGPROGRAM
					#pragma vertex vert
					#pragma fragment frag
					#pragma multi_compile_particles

					#include "UnityCG.cginc"

					sampler2D _MainTex;
					fixed4 _TintColor;
					fixed4 _SecondColor;
					fixed _ColorBlend;

					struct appdata_t {
						float4 vertex : POSITION;
						fixed4 color : COLOR;
						float2 texcoord : TEXCOORD0;
					};

					struct v2f {
						float4 vertex : SV_POSITION;
						fixed4 color : COLOR;
						float2 texcoord : TEXCOORD0;
						#ifdef SOFTPARTICLES_ON
						float4 projPos : TEXCOORD1;
						#endif
					};

					float4 _MainTex_ST;

					v2f vert(appdata_t v)
					{
						v2f o;
						o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
						#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos(o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
						#endif
						o.color = v.color;
						o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
						return o;
					}

					sampler2D _CameraDepthTexture;
					float _InvFade;
					float _EmissionGain;

					fixed4 frag(v2f i) : SV_Target
					{
						#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos))));
						float partZ = i.projPos.z;
						float fade = saturate(_InvFade * (sceneZ - partZ));
						i.color.a *= fade;
						#endif

						fixed4 colorAux = _TintColor;
						colorAux.rgb = lerp(colorAux.rgb,_SecondColor.rgb,_ColorBlend);
						colorAux.a *= _SecondColor.a;

						colorAux = 2.0 * colorAux * tex2D(_MainTex, i.texcoord) * (exp(_EmissionGain * 5.0f));
						colorAux.rgb *= i.color.rgb;
						return colorAux;
					}
					ENDCG
				}
			}
		}
}
