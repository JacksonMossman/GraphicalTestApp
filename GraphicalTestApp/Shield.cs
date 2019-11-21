using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Shield : Entity
    {
        public Shield(float x, float y) : base(x, y)
        {
            AABB Hitbox = new AABB(0,0);
            AddChild(Hitbox);

        }
    }
}
