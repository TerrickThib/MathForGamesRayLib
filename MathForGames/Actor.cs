using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    struct Icon
    {
        public char Symbol;
        public ConsoleColor Color;
    }
    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;

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

        public Actor(char icon, float x, float y, string name = "Actor", ConsoleColor color = ConsoleColor.White)
            : this(icon, new Vector2 { X = x, Y = y}, name, color) {}
        
        public Actor(char icon, Vector2 position, string name = "Actor", ConsoleColor color = ConsoleColor.White)
        {
            _icon = new Icon { Symbol = icon, Color = color };
            _position = position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            Engine.Render(_icon, Position);
        }  

        public void End()
        {

        }

        public virtual void OnCollision(Actor actor)
        {

        }
    }
}
