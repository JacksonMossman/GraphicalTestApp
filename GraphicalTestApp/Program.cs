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

            root.AddChild(astroidGenerator);
            //add player to the root
            root.AddChild(player);
           
            
            
            

            game.Run();
        }
    }
}
