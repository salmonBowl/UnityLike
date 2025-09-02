Shader "Custom/OutLineShader"
{
    Properties
    {
		_MainTex("Base (RGB)", 2D) = "white" { }
		_MainColor("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline Width", Range(0, 0.1)) = .005
    }

	CGINCLUDE
	#include "UnityCG.cginc"
	
	struct Input
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct Output
	{
		float4 pos : SV_POSITION;
		fixed4 color : TEXCOORD0;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;
	uniform float4 _MainColor;
	uniform float _Outline;
	uniform float4 _OutlineColor;

	ENDCG

    SubShader
    {
        //Tags { "RenderType"="Opaque" }
        LOD 100
        Pass
        {
			Name "OUTLINE" //アウトライン部分を描画するパスの名前

			Cull Front //表面をカリング（描画しない）

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			Output vert(Input i)
			{
				Output o;

				// 法線方向に頂点を押し出し
				i.vertex.xyz += normalize(i.normal) * _Outline;
				o.pos = UnityObjectToClipPos(i.vertex);
				o.color = _OutlineColor;
				return o;
			}
			
			fixed4 frag(Output o) : SV_Target
			{
				return o.color;
			}
            ENDCG
        }
    }
}