using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class AstroidGenerator : Actor
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private Random _random = new Random();
        public AstroidGenerator()
        {
            //add on update events
            OnUpdate += Astroidgeneration;

            //start the timer for astroid spawning
            _stopwatch.Start();
        }
  
        private void Astroidgeneration(float deltatime)
        {
            //check how long it has been since last astroid created
            if (_stopwatch.ElapsedMilliseconds > 5000 / Game.difficulty)
            {
               //generate all the values for new astroid 
                float XPos = _random.Next(0, Game.windowsizeX);                
                float YPos = _random.Next(0, Game.windowsizeY);
                float XVel = _random.Next(-260, 260);
                float YVel = _random.Next(-260, 260);

                //randomly generate new astroid with random position and velocity
                Astroid astroid = new Astroid(XPos,YPos, XVel, YVel);

                //checks if astroid will spawn on player
                if (astroid.Hitbox.DetectCollision(Player.Instance.hitbox))
                { 
                    return;
                }
                //add astroid to root
                Parent.AddChild(astroid);
                //add to the astroid list
                Game.AstroidList.Add(astroid);
                //restart astroid timer
                _stopwatch.Restart();
            }
        }


    }
}

