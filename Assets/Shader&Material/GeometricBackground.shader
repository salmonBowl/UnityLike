Shader "Custom/GeometricBackground"
{
    CGINCLUDE
    
    float distancePointToLineSegment(float px, float py, float x1, float y1, float x2, float y2)
    {
        float a = x2 - x1;
        float b = y2 - y1;
        float a2 = a * a;
        float b2 = b * b;
        float r2 = a2 + b2;
        float tt = -(a*(x1-px)+b*(y1-py));
        if( tt <= 0 )
        {
            return distance(float2(x1, y1), float2(px, py));
        }
        if( tt >= r2 )
        {
            return distance(float2(x2, y2), float2(px, py));
        }
        float f1 = a*(y1-py)-b*(x1-px);
        return sqrt((f1*f1)/r2);
    }
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
        
        
        float distance = distancePointToLineSegment(pos.x, pos.y, 0.3, -0.2, -0.2, -0.3);
        
        float bright = 0.004 / abs(distance * 1.9);

        //float bright = 0.01 / distanceFromCircle;

        //float brightFiltered = min(bright, 4) * clamp(1.4 - distanceFromCircle, 0, 1);

        bright = clamp(bright, 0, 1);

        float3 baseColor = float3(0, 1, 0.8) * bright;
        /*
        float t = _Time;

        float3 c;
        float l, z = t;
        for (int i = 0; i < 3; i++)
        {
            float2 p1 = pos;
            float2 p2 = pos;
            p1 -= 0.5;
            p1.x *= uv.x / uv.y;
            z += 0.7;
            l = length(p1);
            p2 += p1 / l * (sin(z) + 1) * abs(sin(l * 9 - z * 2));
            c[i] = 0.01 / length(fmod(uv, 1.0) - 0.5);
        }
        float3 baseColor = c / l;
        */

        float alpha = 1;

        return float4(baseColor, alpha);
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
