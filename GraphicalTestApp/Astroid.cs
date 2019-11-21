using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Astroid : Entity
    {

        private AABB _hitbox;
        private Sprite _knifesprite = new Sprite("Images/Knife.png");
   
        public Astroid(float x, float y ,float velX,float velY ) : base(x, y)
        {
            
            _hitbox = new AABB(_knifesprite.Height, _knifesprite.Width);
            AddChild(_hitbox);
            AddChild(_knifesprite);
            OnUpdate += Bounce;
            OnUpdate += rotate;
            XVelocity = velX;
            YVelocity = velY;
            OnUpdate += AstroidCollision;
        }
        //remove this astroid when it exits the screen
        private void Bounce(float deltaTime)
        {
            if (_hitbox.Right >= Game.windowsizeX || _hitbox.Left <= 0)
            {
                XVelocity = -XVelocity;

            }
            if (_hitbox.Bottom >= Game.windowsizeY || _hitbox.Top <= 0)
            {

                YVelocity = YVelocity;

            }
            
        }
        //rotates the astroid
        private void rotate(float deltaTime)
        {
            Rotate(4 * deltaTime);
        }

        //private void playerCollide()
        //{
        //    if(_hitbox.DetectCollision())
        //    {

        //    }
        //}
        private void AstroidCollision(float deltaTime)
        {
            if (_hitbox.DetectCollision(Player.Instance._hitbox) == true)
            {
                Parent.RemoveChild(Player.Instance);
            }
        }
    }
}
