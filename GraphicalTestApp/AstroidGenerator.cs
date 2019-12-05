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
        Stopwatch stopwatch = new Stopwatch();
        Random random = new Random();
        public AstroidGenerator()
        {
            //add on update events
            OnUpdate += Astroidgeneration;

            //start the timer for astroid spawning
            stopwatch.Start();
        }
  
        private void Astroidgeneration(float deltatime)
        {
            //check how long it has been since last astroid created
            if (stopwatch.ElapsedMilliseconds > 5000)
            {
               //generate all the values for new astroid 
                float XPos = random.Next(0, Game.windowsizeX);
                float YPos = random.Next(0, Game.windowsizeY);
                float XVel = random.Next(-260, 260);
                float YVel = random.Next(-260, 260);

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
                stopwatch.Restart();
            }
        }


    }
}

