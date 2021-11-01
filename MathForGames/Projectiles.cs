using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Projectiles : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Player _player;
        public int _xdirection;
        public int _ydirection;
        public Scene _scene;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Projectiles(float x, float y, float speed, int xdirection, int ydirection, Scene scene, string name = "Actor", string path = "")
            : base(x, y, name, path)
        {
            _speed = speed;
            _xdirection = xdirection;
            _ydirection = ydirection;
            _scene = scene;
        }

        public override void Update(float deltaTime)
        {
            //Creat a vector that stores the move input            
            Vector2 moveDirection = new Vector2(_xdirection, _ydirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            //Uses velocity with current Position
            LocalPosition += Velocity;

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
            {
                _scene.RemoveActor(actor);
            }
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
