﻿using System;

namespace GraphicalTestApp
{
  
 
    class AABB : Actor
    {
       
        public UpdateEvent On;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height /2; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height/2; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute -Width /2; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width /2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
            X = -width / 2;
            Y = -Height / 2;
            
        }
        //detect a collision with aabb
        public bool DetectCollision(AABB other)
        {
            return !( Top <= other.Top || Bottom <= other.Bottom ||
                Left > other.Left || Right > other.Right);
        }
     
        //detect collision with a point
        public bool DetectCollision(Vector3 point)
        {
            return !(point.x < Bottom || point.y < Left || point.x > Right || point.y > Top);
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(Left, Top, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 5, Raylib.Color.RED);
            base.Draw();
        }
    }
}