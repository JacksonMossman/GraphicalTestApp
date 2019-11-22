using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
   
    class Astroid : Entity
    {
        
        public AABB Hitbox;
        //generate a new astroid with a random sprite
        private Sprite _knifesprite = new Sprite("Images/Astroid"+ Game.random.Next(2,9) +".png");
   
        public Astroid(float x, float y ,float velX,float velY ) : base(x, y)
        {
            //draw hitbox based off selected sprtie
            Hitbox = new AABB(_knifesprite.Height, _knifesprite.Width);
            AddChild(Hitbox);
            //fix hitbox off set
            Hitbox.X = -5;
            Hitbox.Y = -5;
            //add the sprite of the astroid
            AddChild(_knifesprite);
            //add bouncing on update
            OnUpdate += Bounce;
            //add roate
            //OnUpdate += rotate;
            //set velocity based of randomly generated values
            XVelocity = velX;
            YVelocity = velY;

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
            //bounce astroids off eachother
            //foreach(Astroid A in Game.AstroidList)
            //{
            //    //check collision between astroids
            //    if (Hitbox.DetectCollision(A.Hitbox))
            //    {
            //        XVelocity = -XVelocity;
            //        YVelocity = -YVelocity;
            //        A.XVelocity = -A.XVelocity;
            //        A.YVelocity = -A.YVelocity;
            //    }
            //}
            
        }
        //rotates the astroid
        private void rotate(float deltaTime)
        {
            Rotate(2 * deltaTime);
        }


        private void playerCollide(float deltatime)
        {
            if (Hitbox.DetectCollision(Player.Instance.HitBox()))
            {
                //Parent.RemoveChild(Player.Instance);
            }
        }
        //private void AstroidCollision(float deltaTime)
        //{
        //    if (_hitbox.DetectCollision(Player.Instance._hitbox) == true)
        //    {
        //        Parent.RemoveChild(Player.Instance);
        //    }
        //}
    }
}
