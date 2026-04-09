Shader "Custom/ColorBlind"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off

            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;

            float4 frag(v2f_img i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);

                // 적록 색약 (Deuteranopia)
                float3x3 m = float3x3(
                    0.625, 0.7, 0,
                    0.7, 0.625, 0,
                    0, 0.3, 0.7
                );

                col.rgb = mul(m, col.rgb);
                return col;
            }
            ENDCG
        }
    }
}