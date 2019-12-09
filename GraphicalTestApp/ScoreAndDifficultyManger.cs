using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class ScoreAndDifficultyManger: Actor
    {
        public ScoreAndDifficultyManger()
        {
            OnUpdate += scoreMult;
        }
        private int scorecap = 20;
        private void scoreMult(float deltaTime)
        {
            if(Game.score > scorecap)
            {
                Game.difficulty++;
                scorecap *= 2;
            }
        }
    }
}
