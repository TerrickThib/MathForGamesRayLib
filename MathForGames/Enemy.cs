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
        private Vector3 _velocity;
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
        public Vector3 Velocity
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

        public Enemy(float x, float y,float z, float speed, float maxSightDistance, float maxViewingAngle, Player player, string name = "Actor",Shape shape = Shape.SPHERE)
            : base(x, y, z, name, shape)
        {
            _speed = speed;
            _player = player;
            _maxViewingAngle = maxViewingAngle;
            _maxSightDistance = maxSightDistance;
        }
        public override void Update(float deltaTime)
        {
            //Inishalizes distance
            Vector3 distance = new Vector3();
            //Takes players position and eneme position to get differance
            distance = _player.LocalPosition - LocalPosition;
            distance.Normalize();
            //Velocity = distance * Speed * deltaTime;

            if(GetTargetInSight()&& GetTargetIndistance())
                LocalPosition += Velocity;

            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {            
            Vector3 directionOfTarget = (_player.LocalPosition - LocalPosition).Normalized;                      
            
            return Math.Acos(Vector3.DotProduct(directionOfTarget, Forward)) < _maxViewingAngle;                                            
        }
        public bool GetTargetIndistance()
        { 
            return Vector3.Distance(_player.LocalPosition, LocalPosition) < _maxSightDistance;
        }
        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Son done recked");
        }
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
