Shader "Custom/RayMarching" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_PlanetTex("Planet (RGB)", 2D) = "white" {}
	}
		SubShader{
			Pass{
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#pragma target 3.0
				#include "UnityCG.cginc"
				sampler2D _MainTex;
				sampler2D _PlanetTex;



		#define rayEpsilon 0.0001
		#define rayMax 64.0
		#define rayStepMax 32
#define radiusSphere 0.5

		float3 front;
		float3 eye;
		float3 right;
		float3 up;
		float3 colorWhite = float3(1.0, 1.0, 1.0);
		float sphere(float3 p, float radius)
		{
			return length(p) - radius;
		}

		float3 repeat(float3 position, float cellSize)
		{
			return fmod(abs(position), cellSize) - 0.5 * cellSize;
		}

		float reflectance(float3 a, float3 b)
		{
			return dot(normalize(a), normalize(b)) * 0.5 + 0.5;
		}

		float3 rotateY(float3 v, float t)
		{
			float cost = cos(t);
			float sint = sin(t);
			return float3(v.x * cost + v.z * sint, v.y, -v.x * sint + v.z * cost);
		}

		float2 wrapUV(float2 uv)
		{
			return fmod(abs(uv), 1.0);
		}

		//Appelée pour chaque pixel de la Camera
		fixed4 frag(v2f_img i) : SV_Target
		{
			float2 uv = i.uv.xy * 2 - 1;
			uv.x *= _ScreenParams.x / _ScreenParams.y;
			float3 ray = normalize(front + right * uv.x + up * uv.y);

			float3 color = float3(0.0, 0.0, 0.0);

			float stepTotal = 0.0;
			for (int i = 0; i < rayStepMax; ++i)
			{
				//La position de l'avancement du ray
				float3 position = eye + ray * stepTotal;

				//Tourner
				position = rotateY(position, _Time * 0.1);

				//Avancer
				position.z += _Time;

				//Repetition
				position = repeat(position, 4.0);

				//Animation & Deformation Sphere
				//position.x += sin(position.y * 10.0 + iGlobalTime) * 0.1;



				float angleXY = atan2(position.y, position.x);
				float2 sphereUV = float2(angleXY / 3.14159, 1.0 - reflectance(position, eye));

				sphereUV = wrapUV(sphereUV);

				float3 tex = tex2D(_PlanetTex, sphereUV).rgb;

				float luminance = (tex.r, tex.g, tex.b) / 3.0;

				float planetDist = sphere(position, radiusSphere + luminance * 2.0);
				float satelitDist = sphere(position - float3(0, 0.5, 0), radiusSphere);

				planetDist = min(planetDist, planetDist);

				float isSatelit = step(satelitDist, planetDist);

				if (planetDist < rayEpsilon)
				{
					float3 c = lerp(tex, float3(1, 0, 0), isSatelit);
					color = lerp(c, color, float(i) / float(rayStepMax));
					color = lerp(color, float3(0, 0, 0), stepTotal / rayMax);
					break;
				}
				//On avance le ray
				stepTotal += planetDist;
			}
			return float4(color, 1.0);
		}
		ENDCG
	}
	}
}
