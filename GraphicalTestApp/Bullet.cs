using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _sprite = new Sprite("Images/Bullet.png");
        private AABB _hitbox;
        
        public Bullet(float x, float y) : base(x,y)
        {
            
           
            X = x;
            Y = y;
           
            //make hitbox = to hitbox based off sprite
            AABB hitbox = new AABB(_sprite.Width, _sprite.Height);
            //fixed offset for hitboxes
            hitbox.X += 11;
            hitbox.Y += 11;
            
            //set hitbox to private hitbox
            _hitbox = hitbox;
            
           //add all children
            AddChild(hitbox);
            AddChild(_sprite);

            //add all update functions
            OnUpdate += BulletCollide;
            OnUpdate += BulletCleanUp;
            
        }
        //removes the bullet if it passes the game barriars
        private void BulletCleanUp(float deltaTime)
        {
            //checking left and right
            if (_hitbox.Right >= Game.windowsizeX + 100 || _hitbox.Left <= -100)
            {
                //remove bullet if passed
                Parent.RemoveChild(this);

            }
            //checking top and bottom
 
            if (_hitbox.Bottom >= Game.windowsizeY + 100|| _hitbox.Top <= -100)
            {
                //remove bullet if passed
                Parent.RemoveChild(this);
            }
        }
        //checks astroid collision
        private void BulletCollide(float deltatime)
        {
            //scan astroid list for collisions
            foreach (Astroid a in Game.AstroidList)
            {
                //remove astroid and bullet
                if (_hitbox.DetectCollision(a.Hitbox))
                {
            
                    //destroy astroid
                    Parent.RemoveChild(a);
                    //destroy bullet
                    Parent.RemoveChild(this);
                    //incrament score
                    Game.score += 10 * Game.difficulty;
                    
                }
            }
        }
    


    }
}
