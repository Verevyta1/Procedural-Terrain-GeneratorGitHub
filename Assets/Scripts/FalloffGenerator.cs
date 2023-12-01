using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloffGenerator 
{
    public static float[,] GenerateFalloffMap(int width, int height /*float falloffStart, float falloffEnd*/)
    {
        float[,] map = new float[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float x = i / (float)width * 2 - 1;
                float y = j / (float)height * 2 - 1;

                //custom falloffMap gen to controll where the falloff starts and ends
                //float t = Mathf.Max(Mathf.Abs(width), Mathf.Abs(height));
                //if (t < falloffStart)
                //{
                //    map[i, j] = 1;
                //}
                //else if (t > falloffEnd)
                //{
                //    map[i, j] = 0;
                //}
                //else
                //{
                //    map[i, j] = Mathf.SmoothStep(1, 0, Mathf.InverseLerp(falloffStart, falloffEnd, t));
                //}

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                map[i, j] = Evaluate(value);
            }
        }

        return map;
    }


    static float Evaluate(float value)
    {
        float a = 3f;
        float b = 2.2f;

            return Mathf.Pow(value, a) / (Mathf.Pow(value, a) + Mathf.Pow(b - b * value, a));
    }
}
