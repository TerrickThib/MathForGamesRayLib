using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Eneme : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public Player _player;

        
        //Allows us to give _ speed a value
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        //Allows us to give Velocity a value
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
        public Eneme(char icon, float x, float y, float speed,Player player, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _player = player;
        }
        public override void Update(float deltaTime)
        {
            //Inishalizes distance
            Vector2 distance = new Vector2();
            //Takes players position and eneme position to get differance
            distance = _player.Position - Position;
            distance.Normalize();
            Velocity = distance * Speed;

            Position += Velocity * deltaTime;

            base.Update(deltaTime);
        }

    }
}
