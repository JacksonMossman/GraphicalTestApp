using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
            Game game = new Game(1400,1000, "Astroids but worse");

            Actor root = new Actor();
            //set games Root to root
            game.Root = root;

            //## Set up game here ##//
            Player player = new Player(Game.windowsizeX/2,Game.windowsizeY/2);
            AstroidGenerator astroidGenerator = new AstroidGenerator();
            StarGenerator starGenerator = new StarGenerator();
            ScoreAndDifficultyManger scoreAndDifficultyManger = new ScoreAndDifficultyManger();
            //add astroid generator
            root.AddChild(astroidGenerator);
            //add star generator
            root.AddChild(starGenerator);
            //add player to the root
            root.AddChild(player);
            //add score and difficulty mult
            root.AddChild(scoreAndDifficultyManger);
            //run Game
            game.Run();
        }
    }
}
