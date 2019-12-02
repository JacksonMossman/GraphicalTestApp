using System;

namespace GraphicalTestApp
{
  
 
    class AABB : Actor
    {
        Raylib.Color color = Raylib.Color.RED;
        public UpdateEvent On;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height/ 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute - Width / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
            X = -Width / 2;
            Y = -Height / 2;
            
        }
        //detect a collision
        public bool DetectCollision(AABB other)
        {
            //float[] sides = { other.Right, other.Left, other.Bottom, other.Top };
            //foreach (var side in sides)
            //{
            //    if (inRange(side, Left, Right, Top, Bottom))
            //    {
            //        color = Raylib.Color.BLUE;
            //        return true;
            //    }

            //}
            //return !(Top <= other.Bottom || Bottom >= other.Top ||
            //    Left <= other.Right || Right <= other.Right);
            if(Right >= other.Left && Bottom >= other.Top && Left <= other.Right && Top <= other.Bottom)
            {
                color = Raylib.Color.BLUE;
                return true;
            }
            
            return false;
        }
        public bool inRange(float val, float Xmin, float Xmax,float Ymin, float Ymax)
        {
            if((val > Xmin && val<Xmax) && (val>Ymin && val< Ymax))
            {
                return true;
            }
            return false;
        }

        public bool DetectCollision(Vector3 point)
        {
            return !(point.x < Bottom || point.y < Left || point.x > Right || point.y > Top);
        }
       
        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(Left, Top, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 5, color);
            base.Draw();
        }
    }
}
