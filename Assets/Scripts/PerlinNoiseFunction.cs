using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Custom implementation of the Perlin Noise algorithm
public class PerlinNoiseFunction : MonoBehaviour
{
    // Sets the size of the permutation and gradient arrays
    private const int GradientSizeTable = 256;

    // Holds the shuffled indices for gradient vector selection
    private static readonly int[] Permutations;

    // Holds the random 2D gradient vectors
    private static readonly Vector2[] Gradients2D;

    // Static constructor for PerlinNoiseFunction:
    static PerlinNoiseFunction()
    {
        Permutations = new int[GradientSizeTable * 2];
        Gradients2D = new Vector2[GradientSizeTable];

        // Create a random number generator
        System.Random rand = new System.Random();

        // Fill the Gradients2D and Permutations arrays:
        for (int i = 0; i < GradientSizeTable; i++)
        {
            // Generate random 2D gradient vectors
            Vector2 gradient;
            do
            {
                gradient = new Vector2((float)rand.NextDouble() * 2 - 1, (float)rand.NextDouble() * 2 - 1);
            } while (gradient.sqrMagnitude >= 1);
            gradient.Normalize();

            Gradients2D[i] = gradient;
            Permutations[i] = i;
        }

        // Shuffle the permutations array
        for (int i = 0; i < GradientSizeTable; i++)
        {
            int swapIndex = rand.Next(GradientSizeTable);
            (Permutations[swapIndex], Permutations[i]) = (Permutations[i], Permutations[swapIndex]);
        }

        // Duplicate the permutation array
        for (int i = 0; i < GradientSizeTable; i++)
        {
            Permutations[i + GradientSizeTable] = Permutations[i];
        }
    }

    // PerlinNoise function generates a Perlin noise value for the given 2D input (x, y)
    public static float PerlinNoise(float x, float y)
    {

        // Variables used in the Perlin noise algorithm:
        int ix0, iy0, ix1, iy1;
        float fx0, fy0, fx1, fy1;
        float s, t, nx0, nx1, n0, n1;

        // Calculate integer coordinates and fractional offsets
        ix0 = Mathf.FloorToInt(x) & (GradientSizeTable - 1);
        iy0 = Mathf.FloorToInt(y) & (GradientSizeTable - 1);
        fx0 = x - Mathf.FloorToInt(x);
        fy0 = y - Mathf.FloorToInt(y);
        fx1 = fx0 - 1;
        fy1 = fy0 - 1;
        ix1 = (ix0 + 1) & (GradientSizeTable - 1);
        iy1 = (iy0 + 1) & (GradientSizeTable - 1);

        // Compute smooth interpolation weights
        t = Smooth(fy0);
        s = Smooth(fx0);

        // Calculate noise contributions from four surrounding corners
        nx0 = Dot(Gradients2D[Permutations[ix0 + Permutations[iy0]]], new Vector2(fx0, fy0));
        nx1 = Dot(Gradients2D[Permutations[ix0 + Permutations[iy1]]], new Vector2(fx0, fy1));
        n0 = Mathf.Lerp(nx0, nx1, t);

        nx0 = Dot(Gradients2D[Permutations[ix1 + Permutations[iy0]]], new Vector2(fx1, fy0));
        nx1 = Dot(Gradients2D[Permutations[ix1 + Permutations[iy1]]], new Vector2(fx1, fy1));
        n1 = Mathf.Lerp(nx0, nx1, t);

        float rawValue = Mathf.Lerp(n0, n1, s) * 2.5f;
        float normalizedValue = (rawValue + Mathf.Sqrt(2)) / (2 * Mathf.Sqrt(2));

        // Returns a value between 0 and 1
        return normalizedValue;
    }

    private static float Dot(Vector2 g, Vector2 v)
    {
        return g.x * v.x + g.y * v.y;
    }
    private static float Smooth(float x)
    {
        return x * x * x * (x * (x * 6 - 15) + 10);
    }

}