using System;
using Raylib;
using RL = Raylib.Raylib;
using System.Diagnostics;
using System.Collections.Generic;


namespace GraphicalTestApp
{
    class Game
    {
        //The current root Actor
        private Actor _root = null;
        //The next root Actor
        private Actor _next = null;
        //The Timer for the entire Game
        private Timer _gameTimer = new Timer();
        private Stopwatch stopwatch = new Stopwatch();
        public static int score;
        //window sizes to
        public static int windowsizeX;
        public static int windowsizeY;
        //list of all astroids in the scene
        public static List<Astroid> AstroidList = new List<Astroid>();
        //random number generator
        public static Random random = new Random();
        //difficulty
        public static int difficulty = 1;
        //game over
        public static bool gameover = false;

    

        //Creates a Game and new Scene instance as its active Scene
        public Game(int width, int height, string title)
        {
            windowsizeX = width;
            windowsizeY = height;
            RL.InitWindow(width, height, title);
            RL.SetTargetFPS(0);
        }
        
        //Run the game loop
        public void Run()
        {
           //start audio device
            RL.InitAudioDevice();
            
            stopwatch.Start();


            //Update and draw until the game is over
            while (!RL.WindowShouldClose())
            {
                

                //Change the Scene if needed
                if (_root != _next)
                {
                    _root = _next;
                }

                //Start the Scene if needed
                if (!_root.Started)
                {
                    _root.Start();
                }

                //Update the active Scene
                _root.Update(_gameTimer.GetDeltaTime());

               
                //Draw the active Scene
                RL.BeginDrawing();
                RL.ClearBackground(Color.BLACK);
                //make score counter
                RL.DrawText("Score: " + score, 0, 0, 20, Color.WHITE);
                //make lives counter
                RL.DrawText("Lives:" + Player.Instance.lives, 0, 30, 20, Color.WHITE);
                //Game Over Behavior
                if(gameover)
                {
                    RL.DrawText("GAME OVER\n Esc To Exit",windowsizeX/2 -150 ,windowsizeY/2 -100,50,Color.RED);
                }
                _root.Draw();
                RL.EndDrawing();
            }
       

            //End the game
            RL.CloseWindow();
            RL.CloseAudioDevice();
        }

        //The Actor we are currently running
        public Actor Root
        {
            get { return _root; }
            set
            {
                _next = value;
                if (_root == null) _root = value;
            }
        }



        //private void Astroidgeneration()
        //{
            
        //    if (stopwatch.ElapsedMilliseconds > 5000)
        //    {
        //        float astroidXPos = random.Next(0, windowsizeX);
        //        float astroidYPos = random.Next(0, windowsizeY);
        //        if (astroidXPos == Player.Instance.X && astroidYPos == Player.Instance.Y)
        //        {
        //            return;
        //        }
        //        Astroid astroid = new Astroid(astroidXPos, astroidYPos, random.Next(-260, 260), random.Next(-260, 260));

        //        Root.AddChild(astroid);
        //        AstroidList.Add(astroid);
        //        stopwatch.Restart();
        //    }
        //}

    }
}
