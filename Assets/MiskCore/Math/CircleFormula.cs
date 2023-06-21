using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Math
{
    /// <summary>
    /// 圓方程式
    /// 參照 (x - a) ^ 2 + (y - b) ^ 2 = r ^ 2
    /// </summary>
    public class CircleFormula
    {
        public Vector2 Center { get; set; }

        public float Randis { get; set; }

        public float A => Center.x;

        public float B => Center.y;


        public CircleFormula (float randis)
        {
            Randis = randis;
        }
        public CircleFormula (float randis, Vector2 center) : this(randis)
        {
            Center = center;
        }


        public float[] Y (float x)
        {
            return MathExtension.QuadraticEquation(x, 1, -2 * B, Mathf.Pow(x, 2) + Mathf.Pow(A, 2) + Mathf.Pow(B, 2) - Mathf.Pow(Randis, 2) - 2 * x * A);
        }

        public bool InCircle (Vector2 point)
        {
            return (point - Center).magnitude < Randis;
        }

        public bool OutCircle (Vector2 point)
        {
            return (point - Center).magnitude > Randis;
        }
    }
}

