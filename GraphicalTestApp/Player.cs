using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Raylib;
using RL = Raylib.Raylib;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        Random random = new Random();
        
        //generate sprite of player
        private Sprite _sprite = new Sprite("Images/player.png");
        //generate sprites of the three levels of sheild
        private Sprite _shield2 = new Sprite("Images/shield2.png");
        private Sprite _shield = new Sprite("Images/shield1.png");
        private Sprite _shield3 = new Sprite("Images/shield3.png");

        private Sprite _engineSprite = new Sprite("Images/Engine.png");
        //Generate Turrets at offset of wings
        private Turret _turret = new Turret(28,0);
        private Turret _turret2 = new Turret(-28, 0);
        //turret list
        private List<Turret> turrets = new List<Turret>();
        //public hitbox
        public AABB hitbox;
        //set player as a static instance
        public static Player Instance;
        
        private Stopwatch stopwatch = new Stopwatch();
        private Stopwatch invinsibilityStopWactch = new Stopwatch();
        //speedCap
        public int SpeedCap= 200;
        //player lifes
        public int lives = 3;
        //powerup
        public int powerupcount = 0;        
        //current state of invinsibility
        private bool invincibility = false;
        //load deathsound
        private Sound deathSound = RL.LoadSound("Sounds/sfx_lose.ogg");
        

        public Player(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            
            stopwatch.Start();
            //generate a new hitbox based of sprite
            AABB HitBox = new AABB(_sprite.Height, _sprite.Width);
            //fix hitbox offset
            hitbox = HitBox;
            hitbox.X = -5;
            hitbox.Y = -5;
            //fix engine offset

            _engineSprite.Y = 20;

            //add all children
            AddChild(_sprite);
            AddChild(hitbox);
            AddChild(_turret);
            AddChild(_turret2);
            AddChild(_engineSprite);
          
      
            //add all update functions
            OnUpdate += speedcheck;
            OnUpdate += BounceCheck;
            OnUpdate += Movement;           
            OnUpdate += Rotation;
            OnUpdate += TurretRotation;
            OnUpdate += Fire;
            OnUpdate += InvinsibilityTimer;

            //addTurrets To TurretList
            turrets.Add(_turret);
            turrets.Add(_turret2);


            Instance = this;

            

        }
        public AABB HitBox()
        {
            return hitbox;
        }
        private void Movement(float deltaTime)
        {
            
            //move up input w
            if (Input.IsKeyDown(87))
            {
                XAcceleration = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 400 ;
                YAcceleration = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 400 ;
                _engineSprite.Y = 20;
            }
            ////move Down input s
            //else if (Input.IsKeyDown(83))
            //{
            //    YAcceleration = 150;
            //}
            ////move left input a 
            //else if (Input.IsKeyDown(68))
            //{
            //    XAcceleration = 150;
            //}
            ////move right input d
            //else if (Input.IsKeyDown(65))
            //{
            //    XAcceleration = -150;
            //}
            //slows down the ship if no input
            else
            {
                //move engine sprite out of sight
                _engineSprite.Y = -10000;
                //set acceleration to zero
                XAcceleration = 0;
                YAcceleration = 0;
                //slow down ship
                if(XVelocity >0)
                {
                    XVelocity -= 100 * deltaTime;
                }
                else if(XVelocity < 0 )
                {
                    XVelocity += 100 * deltaTime;
                }
               
                if (YVelocity > 0)
                {
                    YVelocity -= 100 * deltaTime;
                }
                else if(YVelocity < 0)
                {
                    YVelocity += 100 * deltaTime;
                }


            }
        }
        //players rotations
        private void Rotation(float deltaTime)
        {
            //rotate left input q
            if (Input.IsKeyDown(68))
            {
                Rotate(2f * deltaTime);
                
                
            }
            //rotate right input e
            else if (Input.IsKeyDown(65))
            {
                Rotate(-2f * deltaTime);
            }
        }
        //rotate  both turrets
        private void TurretRotation(float deltaTime)
        {
            //rotate turrret right input R
            if (Input.IsKeyDown(69))
            {
               
                    _turret.Rotate(3f * deltaTime);
                    
                
            }
            //rotate turret left input f
            else if (Input.IsKeyDown(81))
            {
               
                 _turret2.Rotate(-3f * deltaTime);
                 
              
            }
        }
        //bounce player off of sides of screens
        private void BounceCheck(float deltaTime)
        {
            //check left and right sides of window
            if (hitbox.Right >= Game.windowsizeX || hitbox.Left <= 0)
            {
                XVelocity = -XVelocity  ;
         
            }
            //bounce of left and right of window
            if (hitbox.Bottom >= Game.windowsizeY || hitbox.Top <= 0)
            {

                YVelocity = -YVelocity;
                
            }
        }
        //checks speed to speedcap and sets value back if its passed
        private void speedcheck(float deltatime)
        {
            //check movement right
            if (XVelocity > SpeedCap)
            {
                XVelocity = SpeedCap;
            }
            //check movment left
            if(XVelocity < -SpeedCap)
            {
                XVelocity = -SpeedCap;
            }
            //check movment down
            if (YVelocity > SpeedCap)
            {
               YVelocity = SpeedCap;
            }
            //check movment up
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
                if(stopwatch.ElapsedMilliseconds > 300)
                {
                   foreach(Turret t in turrets)
                   {
                        t.fire();
                   }
                    stopwatch.Restart();
                }
                
            }

        }
        private void InvinsibilityTimer(float deltaTime)
        {
            //checks if players shield has run out
            if(invinsibilityStopWactch.ElapsedMilliseconds > 5000)
            {
                //turns off invinsibility
                invincibility = false;
                //chooses shield based off current lives
                if (lives == 0)
                {
                    RemoveChild(_shield);
                    return;
                }
                else if (lives == 1)
                {
                    RemoveChild(_shield2);
                    return;
                }
                
                else if (lives == 2)
                {
                    RemoveChild(_shield3);
                }
            }
        }
        public void Playerhit()
        {
            if(invincibility == true)
            {
                return;
            }
            if (lives > 0)
            {
                RL.PlaySound(deathSound);
                lives--;
                X = Game.windowsizeX /2;
                Y = Game.windowsizeY/2;
                
                invincibility = true;

                if (lives == 0)
                {
                    AddChild(_shield);
                }
                else if (lives == 1)
                {
                    AddChild(_shield2);
                }
                else if (lives == 2)
                {
                    AddChild(_shield3);
                }
                invinsibilityStopWactch.Restart();
                    
                    return;
            }
                Parent.RemoveChild(Instance);
                Game.gameover = true;
                
           
        }

    }
}
