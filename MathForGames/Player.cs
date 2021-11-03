﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        public Scene _scene;
        private float _cooldowntimer = 0.5f;
        private float _timesincelastshot = 0;        

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
          
        public Player( float x, float y, float speed,Scene scene, string name = "Actor", Shape shape = Shape.SPHERE) 
            : base(x, y, name, shape)
        {
            _speed = speed;
            _scene = scene;
        }

        public override void Update(float deltaTime)
        {
            //Sets time for cooldown timer
            _timesincelastshot += deltaTime;

            //GEts the player input direction
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));            
            int zDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            //To shot bullet
            int xDirectionofBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));
            int zDirectionofBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

            if (_timesincelastshot > _cooldowntimer)
            {
                if (xDirectionofBullet != 0 || zDirectionofBullet != 0)
                {
                    //Sets what a bullet is, sets scale sets bullet size, sets bullet hit box them adds bullet to scene, and resets time
                    Projectiles bullet = new Projectiles(LocalPosition.X, LocalPosition.Y, 200, xDirectionofBullet, zDirectionofBullet, _scene, "Bullet", Shape.SPHERE);                    
                    CircleCollider bulletCircleCollider = new CircleCollider(10, bullet);
                    bullet.Collider = bulletCircleCollider;
                    _scene.AddActor(bullet);
                    _timesincelastshot = 0;
                }
            }

            //Creat a vector that stores the move input            
            Vector3 moveDirection = new Vector3(xDirection,0, zDirection);
            Vector3 bulletDirection = new Vector3(xDirectionofBullet,0, zDirectionofBullet);
                                             
            //Velocity = moveDirection.Normalized * Speed * deltaTime;
            
            //Uses velocity with current Position
            LocalPosition += Velocity;

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
            {
                Engine.CloseApplication();
            }
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
