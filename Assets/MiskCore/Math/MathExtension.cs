using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore.Math
{
    public static class MathExtension
    {
        /// <summary>
        /// 求二元一次方程式
        /// </summary>
        /// <returns></returns>
        public static float[] QuadraticEquation (float x, float a, float b, float c)
        {
            float discriminant = Mathf.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
                return new float[] { };

            if (discriminant == 0)
                return new float[] { -b / 2 / a };

            float root = Mathf.Pow(discriminant, 0.5f);
            return new float[] { (-b + root) / 2 / a, (-b - root) / 2 / a };
        }


        /// <summary>
        /// 回傳圓上隨機一點
        /// </summary>
        public static Vector2 RandomPointOnCircle (this CircleFormula formula)
        {
            float x = UnityEngine.Random.Range(formula.Center.x - formula.Randis, formula.Center.x + formula.Randis);
            float[] y = formula.Y(x);

            return new Vector2(x, y[UnityEngine.Random.Range(0, y.Length)]);
        }


        /// <summary>
        /// 求兩向量內角
        /// </summary>
        public static float InnerEulerAngle2Vector(Vector3 v1, Vector3 v2)
        {
            v1 = v1.normalized;
            v2 = v2.normalized;

            var cosX = Vector3.Dot(v1, v2);
            var x1 = Mathf.Acos(cosX) * Mathf.Rad2Deg;

            var x2 = 360 - x1;


            return x1 <= x2 ? x1 : x2;
        }

        /// <summary>
        /// 輸入一角度，回傳 0 ~ 360 的角度
        /// </summary>
        /// <param name="eulerAngle"></param>
        /// <returns></returns>
        public static float PositiveEulerAngle(float eulerAngle)
        {
            eulerAngle %= 360;
            return eulerAngle > 0 ? eulerAngle : 360 + eulerAngle;
        }


        /// <summary>
        /// 輸入兩個角度，回傳較近的方向
        /// </summary>
        public static RotationDirection GetDirectionBy2EularAngle(float from, float to)
        {
            float diff = to - from;
            if (diff < 0)
            {
                diff += 360;
            }

            if (diff >= 0 && diff <= 180)
            {
                return RotationDirection.CLOCKWISE;
            }
            else
            {
                return RotationDirection.COUNTER_CLOCKWISE;
            }
        }

        /// <summary>
        /// 輸入兩個向量，回傳較近的方向
        /// </summary>
        public static RotationDirection GetNearDirectionBy2Vector(Vector3 from, Vector3 to)
        {
            Vector3 cross = Vector3.Cross(from, to);
            if (cross.y > 0f)
            {
                return RotationDirection.COUNTER_CLOCKWISE;
            }
            else
            {
                return RotationDirection.CLOCKWISE;
            }
        }

        /// <summary>
        /// 輸入兩個角度，回傳較近的差值
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns></returns>
        public static float GetNearRotationDifference(float angle1, float angle2)
        {
            float diff = angle2 - angle1;

            if (diff < 0)
            {
                diff += 360;
            }

            if (diff > 180)
            {
                diff = 360 - diff;
            }

            return diff;
        }
    }


    public enum RotationDirection
    {
        CLOCKWISE,
        COUNTER_CLOCKWISE
    }
}

