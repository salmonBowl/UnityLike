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
        // 座標を 0～1 → -1～1 のスケールに
        float2 pos = uv * 2 - 1;
        
        // ずらす
        //pos.y -= -0.2;
        /*
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
        */
	    uv.x -= 0.5;
	    uv.y -= 0.5;
	    
	    float3 baseColor = float3(0, 0, 0);
	    for(float i = 0.0; i < 10.0; i++)
	    {
		    float t = (0.11) * -15;
	    
		    uv.y += sin(uv.x * (i + 1.0) + t + i / 2.0) * 0.1;
		    float fTemp = abs(1.0 / uv.y / 100.0);
		    baseColor += float3(fTemp * (10.0 - i) / 10.0, fTemp * i / 10.0, pow(fTemp,0.99) * 1.5);
	    }

        float alpha = 1;

        return float4(baseColor, alpha);
    }


    float flower(float2 p, float n, float radius, float angle, float waveAmp)
    {
        float theta = atan2(p.y, p.x);
        float d = length(p) - radius + sin(theta*n + angle) * waveAmp;
        float b = 0.006 / abs(d); // 光の強さをちょっと強くした
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

            // 構造体の定義
            struct appdata // vert関数の入力
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };
        
            struct fin // vert関数の出力からfrag関数の入力へ
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            // float4 vert(float4 vertex : POSITION) : SV_POSITION から↓に変更
            fin vert(appdata v) // 構造体を使用した入出力
            {
                fin o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            float4 frag(fin IN) : SV_TARGET // 構造体finを使用した入力
            {
                return paint(IN.texcoord.xy);
            }
            ENDCG
        }
    }
}
