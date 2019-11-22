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
            Game game = new Game(1600, 760, "Graphical Test Application");

            Actor root = new Actor();
            //set games Root to root
            game.Root = root;

            //## Set up game here ##//
            Player player = new Player(400,400);
            
            
           //add player to root

            root.AddChild(player);
           
            
            
            

            game.Run();
        }
    }
}
