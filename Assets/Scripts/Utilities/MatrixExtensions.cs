//Created by Jorik Weymans 2020
//https://math.stackexchange.com/questions/237369/given-this-transformation-matrix-how-do-i-decompose-it-into-translation-rotati
using UnityEngine;

namespace Jorik.Utilities
{
	public static class MatrixExtensions
	{
        public static Vector3 GetTranslation(this Matrix4x4 matrix)
        {
            return new Vector3(matrix.m03, matrix.m13, matrix.m23);
        }

        public static Vector3 GetScale(this Matrix4x4 matrix)
        {
            //the scale is always returned positive
            Vector3 theScale = Vector3.zero;
            
            theScale.x = new Vector3(matrix.m00, matrix.m10, matrix.m20).magnitude;
            theScale.y = new Vector3(matrix.m01, matrix.m11, matrix.m21).magnitude;
            theScale.z = new Vector3(matrix.m02, matrix.m12, matrix.m22).magnitude;
            return theScale;
        }

        public static Quaternion GetRotation(this Matrix4x4 m)
        {

            //zeroing the transformation
            //m.m03 = 0.0f;
            //m.m13 = 0.0f;
            //m.m23 = 0.0f;
            //
            //Vector3 scale = m.GetScale();
            //
            //m.m00 /= scale.x; m.m01 /= scale.y; m.m02 /= scale.z;
            //m.m10 /= scale.x; m.m11 /= scale.y; m.m12 /= scale.z;
            //m.m20 /= scale.x; m.m21 /= scale.y; m.m22 /= scale.z;


            return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));

            Quaternion q = new Quaternion();
            q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
            q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
            q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
            q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
            q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
            q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
            q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
            return q;

        }
    }
}