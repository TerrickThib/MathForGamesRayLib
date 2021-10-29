using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{    
    class Actor
    {        
        private string _name;        
        private bool _started;
        private Vector2 _forward = new Vector2(1, 0);
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;        
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;        
        private Sprite _sprite;


        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Position
        {
            get { return new Vector2(_transform.M02, _transform.M12); }
            set 
            { 
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }  
                
        public Vector2 Forward
        {
            get { return _forward; }    
            set { _forward = value; }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public Actor() { }

        public Actor(float x, float y, string name = "Actor", string path = "")
            : this (new Vector2 { X = x, Y = y}, name, path) {}
        
        public Actor(Vector2 position, string name = "Actor", string path = "")
        {            
            Position = position;
            _name = name;

            if (path != "")
            {
                _sprite = new Sprite(path);
            }
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            _transform = _translation * _rotation * _scale;
            Console.WriteLine(_name + ": " + Position.X + ", " + Position.Y);
        }

        public virtual void Draw()
        {
            if (_sprite != null)
            {
                _sprite.Draw(_transform);
            }
            
        }  

        public void End()
        {

        }
        public virtual void OnCollision(Actor actor)
        {

        }

        /// <summary>
        /// Checks if this actor collided with another actor
        /// </summary>
        /// <param name="other">The actor to check for a collision against</param>
        /// <returns>True if the distance between the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //Return false if either actor doesn't have a collider attached
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="translationX">The new x position</param>
        /// <param name="translationY">The new y position</param>
        public void SetTranslation(float translationX, float translationY)
        {
            _translation.M02 = translationX;
            _translation.M12 = translationY;
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="translationX"></param>
        /// <param name="translationY"></param>
        public void Translate(float translationX, float translationY)
        {

            _translation.M02 += translationX;
            _translation.M12 += translationY;
        }

        /// <summary>
        /// Set the rotation of the actor.
        /// </summary>
        /// <param name="radians">The angle in radians to turn.</param>
        public void SetRotation(float radians)
        {
            _rotation.M00 = (float)Math.Cos(radians);
            _rotation.M01 = -(float)Math.Sin(radians);
            _rotation.M10 = (float)Math.Sin(radians);
            _rotation.M11 = (float)Math.Cos(radians);
            
        }

        /// <summary>
        /// Adds a rotation to the current transform's rotation.
        /// </summary>
        /// <param name="radians">The angle in radians to turn.</param>
        public void Rotate(float radians)
        {
            _rotation.M00 += (float)Math.Cos(radians);
            _rotation.M01 += -(float)Math.Sin(radians);
            _rotation.M10 += (float)Math.Sin(radians);
            _rotation.M11 += (float)Math.Cos(radians);
        }

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void SetScale(float x, float y)
        {
            _scale.M00 = x;
            _scale.M11 = y;
        }

        /// <summary>
        /// Scales the actor by the given amount.
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis.</param>
        public void Scale(float x, float y)
        {
            _scale.M00 += x;
            _scale.M11 += y;
        }
    }
}
