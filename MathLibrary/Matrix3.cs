using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float M00, M01, M02, 
                     M10, M11, M12, 
                     M20, M21, M22;
        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        public static Matrix3 Identity
        {
            get
            {
                //Gives it a default value for matrix 3
                return new Matrix3(1, 0, 0,
                                   0, 1, 0,
                                   0, 0, 1);
            }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        /// <returns></returns>
        public static Matrix3 CreateRotation(float radians)
        {
            Matrix3 rotation = new Matrix3();

            rotation.M00 = (float)Math.Cos(radians);
            rotation.M01 = -(float)Math.Sin(radians);
            rotation.M10 = (float)Math.Sin(radians);
            rotation.M11 = (float)Math.Cos(radians);

            return rotation;
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="x">The x position of the new matrix</param>
        /// <param name="y">The y position of the new matrix</param>
        /// <returns></returns>
        public static Matrix3 CreateTranslation(float x, float y)
        {
            Matrix3 translatedMatrix = new Matrix3(1, 0, x,
                                                   0, 1, y,
                                                   0, 0, 1);
            return translatedMatrix;                        
        }

        /// <summary>
        /// Creates a new matrix that has been scaled by teh given value
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis</param>
        /// <param name="y">The value to use to scale the matrix in the y axis</param>
        /// <returns></returns>
        public static Matrix3 CreateScale(float x, float y)
        {
            Matrix3 scaled = new Matrix3();

            scaled.M00 = x;
            scaled.M11 = y;

            return scaled;
        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return lhs + rhs;
        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return lhs - rhs;
        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            Matrix3 temp = new Matrix3();

            temp.M00 = (lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20);
            temp.M01 = (lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21);
            temp.M02 = (lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22);

            temp.M10 = (lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20);
            temp.M11 = (lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21);
            temp.M12 = (lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22);

            temp.M20 = (lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20);
            temp.M21 = (lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21);
            temp.M22 = (lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22);

            return temp;
        }
    }
}
