using System;

namespace MathLibrary
{
    public struct Vector2
    {
        public float X;
        public float Y;

        /// <summary>
        /// Adds the x value of the second vector to the first, and addds the y value of the second vector to the first
        /// </summary>
        /// <param name="lhs">The vector that is increasing</param>
        /// <param name="rhs">The vector used to increase the 1st vector</param>
        /// <returns>The result of the vector addition</returns>
        public static Vector2 operator + (Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y };            
        }

        /// <summary>
        /// Subtracts the x value of the second vector to the first, and subtracts the y value of the second vector to the first
        /// </summary>
        /// <param name="lhs">The vector that is being subtracted from</param>
        /// <param name="rhs">The vector used to subtract from  the 1st vector</param>
        /// <returns>The result of the vector addition</returns>
        public static Vector2 operator - (Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y };
        }

        /// <summary>
        /// Multiplies the vectors x and y values by the scaler
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="scalar">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2 { X = lhs.X * scalar, Y = lhs.Y * scalar };
        }

        /// <summary>
        /// Divides the vector's x and y values by the scalar given
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="scalar">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2 { X = lhs.X / scalar, Y = lhs.Y / scalar };
        }
        
       /// <summary>
       /// Compares the x and y values of two vectors
       /// </summary>
       /// <param name="lhs">The left side of the comparison</param>
       /// <param name="rhs">The right side of the comparison</param>
       /// <returns>True if the x values of both vectors match and the y values match</returns>
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;            
        }

        /// <summary>
        /// Compares the x and y values of two vectors
        /// </summary>
        /// <param name="lhs">The left side of the comparison</param>
        /// <param name="rhs">The right side of the comparison</param>
        /// <returns>True if the values of X isnt equaled to the values of Y</returns>
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return lhs.X != rhs.X && lhs.Y != rhs.Y;           
        }

    }
}
