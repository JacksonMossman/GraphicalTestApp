using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Turret : Entity
    {
         public Sprite _TurretSprite = new Sprite("Images/barrelBlack.png");

        public Turret(float x, float y) : base(x, y)
        {
            
            AddChild(_TurretSprite);
           
        }

    }
}
