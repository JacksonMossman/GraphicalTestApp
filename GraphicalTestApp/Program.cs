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
            game.Root = root;

            //## Set up game here ##//
            Player player = new Player(400,400);
            Astroid astroid = new Astroid(300, 300, 100, 100);
            
           

            root.AddChild(player);
            root.AddChild(astroid);
            
            
            //hard Coded Child must remain second Child Added
           
          
            

            game.Run();
        }
    }
}
