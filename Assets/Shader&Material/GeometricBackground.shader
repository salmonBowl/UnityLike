Shader "Custom/GeometricBackground"
{
    CGINCLUDE

    float4 paint(float2 uv)
    {
        // ���W�� 0�`1 �� -1�`1 �̃X�P�[����
        float2 pos = uv * 2 - 1;

        // ���炷
        //pos.y -= -0.2;

        float l = length(pos);
        float distanceFromCircle = abs(l - 0.5);
        float theta = atan2(pos.y, pos.x);

        float freq = 6;
        float waveIntensity = 0.05;
        float waveRadius = 0.33;

        float distanceFromWave = l - waveRadius + sin(theta * freq) * waveIntensity;
        float bright = 0.004 / abs(distanceFromWave);

        //float bright = 0.01 / distanceFromCircle;

        //float brightFiltered = min(bright, 4) * clamp(1.4 - distanceFromCircle, 0, 1);

        float3 color = (0, 0.2, 1) * min(bright, 1);

        float alpha = 1;

        return float4(color, alpha);
    }

    float flower(float2 p, float n, float radius, float angle, float waveAmp)
    {
        float theta = atan2(p.y, p.x);
        float d = length(p) - radius + sin(theta*n + angle) * waveAmp;
        float b = 0.006 / abs(d); // ���̋�����������Ƌ�������
        return b;
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
                return paint(IN.texcoord.xy);
            }
            ENDCG
        }
    }
}
