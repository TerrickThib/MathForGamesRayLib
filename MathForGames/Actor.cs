using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    struct Icon
    {
        public char Symbol;
        public Color Color;        
    }
    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;
        private Vector2 _forward = new Vector2(1, 0);
        private float _collisionRadius;
               
        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }  
        
        public Icon Icon
        {
            get { return _icon; }
        }
        
        public Vector2 Forward
        {
            get { return _forward; }    
            set { _forward = value; }
        }

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        public Actor(char icon, float x, float y, Color color, string name = "Actor")
            : this(icon, new Vector2 { X = x, Y = y}, color, name) {}
        
        public Actor(char icon, Vector2 position, Color color, string name = "Actor")
        {
            _icon = new Icon { Symbol = icon, Color = color };
            _position = position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            Console.WriteLine(_name + ": " + Position.X + ", " + Position.Y);

        }

        public virtual void Draw()
        {
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Position.X, (int)Position.Y, 50, Icon.Color);
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
            float combineRadii = other.CollisionRadius + CollisionRadius;
            float distance = Vector2.Distance(Position, other.Position);

            return distance <= combineRadii;
        }

    }
}
