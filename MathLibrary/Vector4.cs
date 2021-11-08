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

            return this / Magnitude;
        }

        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z };
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z };
        }

        public static Vector4 operator *(Vector4 lhs, float scalar)
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
    }
}
