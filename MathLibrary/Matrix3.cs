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

        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="x">The x position of the new matrix</param>
        /// <param name="y">The y position of the new matrix</param>
        /// <returns></returns>
        public static Matrix3 CreateTranslation(float x, float y)
        {

        }

        /// <summary>
        /// Creates a new matrix that has been scaled by teh given value
        /// </summary>
        /// <param name="x">The value to use to scale the matrix in the x axis</param>
        /// <param name="y">The value to use to scale the matrix in the y axis</param>
        /// <returns></returns>
        public static Matrix3 CreateScale(float x, float y)
        {

        }

        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {

        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {

        }
    }
}
