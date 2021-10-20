using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{    
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public Player _player;
        private float _maxViewingAngle;
        private float _maxSightDistance;

        
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

        public float MaxViewingAngle
        {
            get { return _maxViewingAngle; }
            set { _maxViewingAngle = value; }
        }

        public float MaxSightDistance
        {
            get { return _maxSightDistance; }
            set { _maxSightDistance = value; }
        }

        public Enemy(char icon, float x, float y, float speed, float maxSightDistance, float maxViewingAngle, Color color, Player player, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _player = player;
            _maxViewingAngle = maxViewingAngle;
            _maxSightDistance = maxSightDistance;
        }
        public override void Update(float deltaTime)
        {
            //Inishalizes distance
            Vector2 distance = new Vector2();
            //Takes players position and eneme position to get differance
            distance = _player.Position - Position;
            distance.Normalize();
            Velocity = distance * Speed * deltaTime;

            if(GetTargetInSight()&& GetTargetIndistance())
                Position += Velocity;

            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {            
            Vector2 directionOfTarget = (_player.Position - Position).Normalized;                      
            
            return Math.Acos(Vector2.DotProduct(directionOfTarget, Forward)) < _maxViewingAngle;                                            
        }
        public bool GetTargetIndistance()
        { 
            return Vector2.Distance(_player.Position, Position) < _maxSightDistance;
        }
        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Son done recked");
        }
    }
}
