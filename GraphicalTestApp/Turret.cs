using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Turret : Entity
    {
         public Sprite _TurretSprite = new Sprite("Images/gun08.png");

        public Turret(float x, float y) : base(x, y)
        {
            //add turret sprite to turret
            AddChild(_TurretSprite);
           
        }

    }
}
