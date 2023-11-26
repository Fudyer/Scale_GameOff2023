Shader "Custom/OceanShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaveDirection ("Wave Direction", Range(0, 360)) = 45
        _WaveLength ("Wave Length", Range(1, 10)) = 2
        _WaveAmplitude ("Wave Amplitude", Range(0, 1)) = 0.1
        _WaveSpeed ("Wave Speed", Range(0, 2)) = 0.5
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _WaveDirection;
            float _WaveLength;
            float _WaveAmplitude;
            float _WaveSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Calculate wave displacement based on time and parameters
                float time = _Time.y * _WaveSpeed;
                float2 waveDirection = normalize(float2(cos(_WaveDirection * 3.1415927 / 180), sin(_WaveDirection * 3.1415927 / 180)));
                float waveDisplacement = sin(dot(uv, waveDirection) * _WaveLength + time) * _WaveAmplitude;

                // Apply wave displacement to the fragment position
                uv += waveDirection * waveDisplacement;

                // Sample the texture with the modified UV
                half4 col = tex2D(_MainTex, uv);

                return col;
            }
            ENDCG
        }
    }
}
