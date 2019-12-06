using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class StarGenerator : Actor
    {
        private int count = 100;

        public StarGenerator()
        {
            OnUpdate += Generator;
        }
        private void Generator(float deltatime)
        {
            //generate 100 stars
            while (count > 0)
            {
                //generate all the values for new astroid 
                float XPos = Game.random.Next(0, Game.windowsizeX);
                float YPos = Game.random.Next(0, Game.windowsizeY);


                Star star = new Star();
                star.X = XPos;
                star.Y = YPos;
                

                AddChild(star);
                count--;
            }
        }
    }
}

