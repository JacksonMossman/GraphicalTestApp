using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;

namespace GraphicalTestApp
{
   
    class Astroid : Entity
    {
        
        public AABB Hitbox;
        //astroid number
        
        //generate a new astroid with a random sprite
        private Sprite _astroidSprite = new Sprite("Images/Astroid"+ Game.random.Next(2,9) +".png");
   
        public Astroid(float x, float y ,float velX,float velY ) : base(x, y)
        {
            //draw hitbox based off selected sprtie
            Hitbox = new AABB(_astroidSprite.Height, _astroidSprite.Width);
           
            // add children of astroid
            AddChild(Hitbox);
            AddChild(_astroidSprite);
            //fix hitbox off set
            Hitbox.X = -5;
            Hitbox.Y = -5;
            //set velocity of astroid to fed values
            XVelocity = velX;
            YVelocity = velY;
            
          
            //add bouncing on update
            OnUpdate += Bounce;


            //add roate
            //OnUpdate += rotate;

           //add update functions
            OnUpdate += playerCollide;
        }
        //remove this astroid when it exits the screen
        private void Bounce(float deltaTime)
        {
            //bounce astroids off left and right of screen
            if (Hitbox.Right >= Game.windowsizeX || Hitbox.Left <= 0)
            {
                
                XVelocity = -XVelocity;

            }
            //bounce astroids off top and bottom
            if (Hitbox.Bottom >= Game.windowsizeY || Hitbox.Top <= 0)
            {

                YVelocity = -YVelocity;

            }
            

        }
        
        //checks if there is a collision with the player 
        private void playerCollide(float deltatime)
        {
            //check player collision
            if (Hitbox.DetectCollision(Player.Instance.HitBox()))
            {
                
                //trigger player hit behavior
                Player.Instance.Playerhit();      
            }
        }
    }
}
