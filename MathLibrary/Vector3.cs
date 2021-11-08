using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public float Magnitude
        {
            get
            {
                //The X squared plus Y squared plus Z squared
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3 Normalized
        {
            get
            {
                Vector3 value = this;
                return value.Normalize();
            }
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 Normalize()
        {
            if (Magnitude == 0)
                return new Vector3();

            return this /= Magnitude;
        }

        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z };
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z };
        }

        //VEctor * float
        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3 { X = lhs.X * scalar, Y = lhs.Y * scalar, Z = lhs.Z * scalar };
        }
        //float * vector
        public static Vector3 operator *(float scalar, Vector3 lhs)
        {
            return new Vector3 { X = lhs.X * scalar, Y = lhs.Y * scalar, Z = lhs.Z * scalar };
        }

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3 { X = lhs.X / scalar, Y = lhs.Y / scalar, Z = lhs.Z / scalar };
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X != rhs.X && lhs.Y != rhs.Y && lhs.Z != rhs.Z;
        }

        /// <summary>
        /// Finds the cross Product
        /// </summary>
        /// <param name="lhs">Left hand side of vector</param>
        /// <param name="rhs">Right hand side of vector</param>
        /// <returns>The perpendicular Vector</returns>
        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                               (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                               (lhs.X * rhs.Y) - (lhs.Y * rhs.X)); 
        }
    }
}
