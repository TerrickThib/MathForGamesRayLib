using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public float Magnitude
        {
            get
            {
                //The X squared plus Y squared plus Z squared
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector4 Normalized
        {
            get
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4 Normalize()
        {
            if (Magnitude == 0)
                return new Vector4();

            return this /= Magnitude;
        }

        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W);
        }

        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z, W = lhs.W - rhs.W };
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z, W = lhs.W + rhs.W };
        }

        //Vector * float
        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            return new Vector4 { X = lhs.X * scalar, Y = lhs.Y * scalar, Z = lhs.Z * scalar };
        }
        //float * vector
        public static Vector4 operator *(float scalar, Vector4 lhs)
        {
            return new Vector4 { X = lhs.X * scalar, Y = lhs.Y * scalar, Z = lhs.Z * scalar };
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4 { X = lhs.X / scalar, Y = lhs.Y / scalar, Z = lhs.Z / scalar };
        }

        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return lhs.X != rhs.X && lhs.Y != rhs.Y && lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Finds the cross Product
        /// </summary>
        /// <param name="lhs">Left hand side of vector</param>
        /// <param name="rhs">Right hand side of vector</param>
        /// <returns>The perpendicular Vector</returns>
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                               (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                               (lhs.X * rhs.Y) - (lhs.Y * rhs.X), 0);
        }

        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                (lhs.M00 * rhs.X) + (lhs.M01 * rhs.Y) + (lhs.M02 * rhs.Z) + (lhs.M03 * rhs.W),
                (lhs.M10 * rhs.X) + (lhs.M11 * rhs.Y) + (lhs.M12 * rhs.Z) + (lhs.M13 * rhs.W),
                (lhs.M20 * rhs.X) + (lhs.M21 * rhs.Y) + (lhs.M22 * rhs.Z) + (lhs.M23 * rhs.W),
                (lhs.M30 * rhs.X) + (lhs.M31 * rhs.Y) + (lhs.M32 * rhs.Z) + (lhs.M33 * rhs.W));
        }
    }
}
