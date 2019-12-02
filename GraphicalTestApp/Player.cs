using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sprite _sprite = new Sprite("Images/player.png");
        private Turret _turret = new Turret(40,0);
        private Turret _turret2 = new Turret(-40, 0);
      
        public AABB _hitbox;
        public static Player Instance;
        private Stopwatch stopwatch = new Stopwatch();
        public int SpeedCap= 200;
        
        
        public Player(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            stopwatch.Start();
            AABB HitBox = new AABB(_sprite.Height, _sprite.Width);
            _hitbox = HitBox;
            _hitbox.X = -5;
            _hitbox.Y = -5;
            AddChild(_sprite);
            
            AddChild(HitBox);
            AddChild(_turret);
            AddChild(_turret2);
          
      

            OnUpdate += speedcheck;
            OnUpdate += BounceCheck;
            OnUpdate += Movement;           
            OnUpdate += Rotation;
            OnUpdate += TurretRotation;
            OnUpdate += Fire;
            


            Instance = this;

        }
        public AABB HitBox()
        {
            return _hitbox;
        }
        private void Movement(float deltaTime)
        {
            
            //move up input w
            if (Input.IsKeyDown(87))
            {
                YAcceleration = -150;
            }
            //move Down input s
            else if (Input.IsKeyDown(83))
            {
                YAcceleration = 150;
            }
            //move left input a 
            else if (Input.IsKeyDown(68))
            {
                XAcceleration = 150;
            }
            //move right input d
            else if (Input.IsKeyDown(65))
            {
                XAcceleration = -150;
            }
            //slows down the ship if no input
            else
            {
                XAcceleration = 0;
                YAcceleration = 0;
                if(XVelocity >0)
                {
                    XVelocity -= .01f;
                }
                else if(XVelocity < 0 )
                {
                    XVelocity += 0.1f;
                }
               
                if (YVelocity > 0)
                {
                    YVelocity -= .01f;
                }
                else if(YVelocity < 0)
                {
                    YVelocity += .01f;
                }


            }
        }
        //players rotations
        private void Rotation(float deltaTime)
        {
            //rotate left input q
            if (Input.IsKeyDown(69))
            {
                Rotate(1f * deltaTime);
                
            }
            //rotate right input e
            else if (Input.IsKeyDown(81))
            {
                Rotate(-1f * deltaTime);
            }
        }
        //rotate  both turrets
        private void TurretRotation(float deltaTime)
        {
            //rotate turrret right input R
            if (Input.IsKeyDown(82))
            {
               
                    _turret.Rotate(1f * deltaTime);
                    _turret2.Rotate(1f * deltaTime);
                
            }
            //rotate turret left input f
            else if (Input.IsKeyDown(70))
            {
               
                    _turret.Rotate(-1f * deltaTime);
                _turret2.Rotate(-1f * deltaTime);
              
            }
        }
        //bounce player off of sides of screens
        private void BounceCheck(float deltaTime)
        {
            //check left and right sides of window
            if (_hitbox.Right >= Game.windowsizeX || _hitbox.Left <= 0)
            {
                XVelocity = -XVelocity  ;
         
            }
            //bounce of left and right of window
            if (_hitbox.Bottom >= Game.windowsizeY || _hitbox.Top <= 0)
            {

                YVelocity = -YVelocity;
                
            }
        }
        private void speedcheck(float deltatime)
        {
            if (XVelocity > SpeedCap)
            {
                XVelocity = SpeedCap;
            }
            if(XVelocity < -SpeedCap)
            {
                XVelocity = -SpeedCap;
            }
            if (YVelocity > SpeedCap)
            {
               YVelocity = SpeedCap;
            }
            if (YVelocity < -SpeedCap)
            {
                YVelocity = -SpeedCap;
            }
            
        }
        private void Fire(float deltatime)
        {
            //fires it the X button is pressed
            if (Input.IsKeyDown(88))
            {
                //checks if a half a secound has elapsed since last shot
                if(stopwatch.ElapsedMilliseconds > 500)
                {
                    //generates new bullet based off turrets position
                    Bullet bulletOne = new Bullet(_turret.XAbsolute, _turret.YAbsolute);
                    Bullet bulletTwo = new Bullet(_turret2.XAbsolute, _turret2.YAbsolute);
                    bulletOne.Rotate(_turret.GetRotation());
                    bulletTwo.Rotate(_turret2.GetRotation());
                    bulletOne.XVelocity = (float)Math.Cos(_turret.GetRotation() - Math.PI * .5f) * 100;
                    bulletOne.YVelocity = (float)Math.Sin(_turret.GetRotation() - Math.PI * .5f) * 100;
                    this.Parent.AddChild(bulletOne);
                    this.Parent.AddChild(bulletTwo);
                    bulletTwo.XVelocity = (float)Math.Cos(_turret2.GetRotation() - Math.PI * .5f) * 100;
                    bulletTwo.YVelocity = (float)Math.Sin(_turret2.GetRotation() - Math.PI * .5f) * 100;
                    stopwatch.Restart();
                }
                
            }

        }

    }
}
