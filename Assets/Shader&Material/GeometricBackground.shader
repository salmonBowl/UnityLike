Shader "Custom/GeometricBackground"
{
    CGINCLUDE

    float4 paint(float2 uv)
    {
        return 1;
    }

    ENDCG

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            // �\���̂̒�`
            struct appdata // vert�֐��̓���
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
        
            struct fin // vert�֐��̏o�͂���frag�֐��̓��͂�
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            // float4 vert(float4 vertex : POSITION) : SV_POSITION ���火�ɕύX
            fin vert(appdata v) // �\���̂��g�p�������o��
            {
                fin o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            float4 frag(fin IN) : SV_TARGET // �\����fin���g�p��������
            {
                return 0;
            }
            ENDCG
        }
    }
}
