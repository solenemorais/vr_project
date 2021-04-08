// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/SolarSystem/Star"
{
   Properties
    {
	
	   [HDR] _ColorCold ("Color Cold", Color) = (1,1,1,1)
       [HDR] _ColorHot ("Color Hot", Color) = (1,1,1,1)
        [HDR]_ColorFrenel ("Color Frenel", Color) = (1,1,1,1)

	    _FrenelPower ("Frenel Power", Range(0,10)) = 3
        _FrenelScale ("Frenel Scale", Range(0,5)) = 2

		_VertexDisplacement("Vertex Displacement", Range(0, 1)) = 0.045
		_VertexDisplacementSpeed("Vertex Displacement Speed", Range(0, 10)) = 0.84
		_VertexDisplacementFrequency("Vertex Displacement Frequency", Range(0, 50)) = 19.6
    }

    // no Properties block this time!
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
			#include "noiseSimplex.cginc"

            struct v2f {
                half3 localPos : TEXCOORD0;
                float4 pos : SV_POSITION;
				float frenel : TEXCOORD1;
            };

			float _FrenelPower;
			float _FrenelScale;
			float _VertexDisplacement;
			float _VertexDisplacementSpeed;
			float _VertexDisplacementFrequency;

            v2f vert (float4 vertex : POSITION, float3 normal : NORMAL)
            {
                v2f o;

								//Displacement
				float4 ns = float4(snoise(vertex.xy *_VertexDisplacementFrequency+_Time.y * _VertexDisplacementSpeed), snoise(vertex.yz *_VertexDisplacementFrequency+_Time.y * _VertexDisplacementSpeed), snoise(vertex.zx *_VertexDisplacementFrequency+_Time.y * _VertexDisplacementSpeed),-1) / 2 +0.5;
				float4 displacedVertex = vertex+ns * _VertexDisplacement;

                o.pos = UnityObjectToClipPos(displacedVertex);
                o.localPos = displacedVertex;

				float3 posWorld = mul(unity_ObjectToWorld, vertex).xyz;
				float3 normWorld = normalize(mul(unity_ObjectToWorld, normal));

				float3 I = normalize(posWorld - _WorldSpaceCameraPos.xyz);
				o.frenel = _FrenelScale * pow(1.0 + dot(I, normWorld), _FrenelPower);
				return o;
            }

			fixed4 _ColorHot;
			fixed4 _ColorCold;
			fixed4 _ColorFrenel;
            
            fixed4 frag (v2f i) : SV_Target
            {
			half distfromCenter = length(i.localPos);
			//Color by distance from center
				fixed4 col = lerp(_ColorHot,_ColorCold,smoothstep(0.5 - _VertexDisplacement,0.5+_VertexDisplacement, distfromCenter));

				//frenel
				col = lerp(col, _ColorFrenel,i.frenel);

                return col;
            }
            ENDCG
        }
    }
}
