Shader "Unlit/ShpereMapping"
{
    Properties
    {
        _WorldRadius("World Radius", Float) = 1
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            float _WorldRadius;

            v2f vert (appdata v)
            {
                v2f o;
                 o.vertex = UnityObjectToClipPos(v.vertex);
                float d = distance(o.vertex, 0);
                o.vertex.x = o.vertex.x * _WorldRadius / d;
                o.vertex.y = o.vertex.y * _WorldRadius / d;
                o.vertex.z = o.vertex.z * _WorldRadius / d;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // fixed4 col = tex2D(_MainTex, i.uv);
                return 1;
            }
            ENDCG
        }
    }
}
