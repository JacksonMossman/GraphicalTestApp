using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    
    class Star:Actor
    {

        private Sprite _sprite = new Sprite("Images/star_0" + Game.random.Next(1,9)+".png");

        private Sprite _sprite2 = new Sprite("Images/planet" + Game.random.Next(1, 20)+".png");
        
        public Star()
        {

            int Num = Game.random.Next(1, 12);
            if(Num <11)
            {
                AddChild(_sprite);
            }
            else
            {
                AddChild(_sprite2);
            }

            
        }
    }
}
