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
        public Star()
        {
            AddChild(_sprite);
        }
    }
}
