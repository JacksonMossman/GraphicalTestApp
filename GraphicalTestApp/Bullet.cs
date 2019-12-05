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
        private Sprite sprite = new Sprite("Images/Bullet.png");
        private AABB Hitbox;
        public Bullet(float x, float y) : base(x,y)
        {
            X = x;
            Y = y;
           
            //make hitbox = to hitbox based off sprite
            AABB hitbox = new AABB(sprite.Width, sprite.Height);
            //fixed offset for hitboxes
            hitbox.X += 11;
            hitbox.Y += 11;
            //set hitbox to private hitbox
            Hitbox = hitbox;
            
           //add all children
            AddChild(hitbox);
            AddChild(sprite);

            //add all update functions
            OnUpdate += BulletCollide;
            
        }
        //removes the bullet if it passes the game barriars
        private void BulletCleanUp()
        {
            //checking left and right
            if (Hitbox.Right >= Game.windowsizeX || Hitbox.Left <= 0)
            {
                //remove bullet if passed
                this.Parent.RemoveChild(this);

            }
            //checking top and bottom
 
            if (Hitbox.Bottom >= Game.windowsizeY || Hitbox.Top <= 0)
            {
                //remove bullet if passed
                this.Parent.RemoveChild(this);
            }
        }
        //checks astroid collision
        private void BulletCollide(float deltatime)
        {
            //scan astroid list for collisions
            foreach (Astroid a in Game.AstroidList)
            {
                //remove astroid and bullet
                if (Hitbox.DetectCollision(a.Hitbox))
                {
            
                    //destroy astroid
                    Parent.RemoveChild(a);
                    //destroy bullet
                    Parent.RemoveChild(this);
                    //incrament score
                    Game.score++;
                    
                }
            }
        }
    


    }
}
