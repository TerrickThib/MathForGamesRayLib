using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Called to Begin the application
        /// </summary>
        public void Run()
        {
            //Called to start the entir application
            Start();

            //For stop watch and Delta time
            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loop until the application is told to close
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                //Gets how much time has passed since the application started
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Sets delta time to be the differance in time from the last time recorded to the current time
                deltaTime = currentTime - lastTime;

                //Update the application
                Update(deltaTime);
                //Draw all items
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currentTime;
            }

            //Call end for the entire application
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            //creates stop watch and starts count
            _stopwatch.Start();

            //Create a window using raylib
            Raylib.InitWindow(800, 450, "Math For Games");          
            Raylib.SetTargetFPS(60);

            Scene scene = new Scene();
            //Actor actor = new Actor('A', 5, 5, Color.RED, "Actor");           
            Player player = new Player('@', 5, 10, 150, Color.DARKPURPLE, "Player");
            player.CollisionRadius = 20;
            Enemy enemy = new Enemy('E', 100, 5, 1, 100, 1, Color.RED, player, "Eneme");
            enemy.CollisionRadius = 20;
            //UI Text Section
            UIText text = new UIText(10, 10, "TestTextBox", Color.BLUE, 70, 70, 15, "Taco Bell Makes me yell");
            
            
            //scene.AddActor(actor);            
            scene.AddActor(player);
            scene.AddActor(enemy);
            scene.AddActor(text);

            _currentSceneIndex = AddScene(scene);
            _scenes[_currentSceneIndex].Start();

            //Makes curser go bye bye
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);
            
            //While there is a key in the input bufer read it
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            // _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a scene to the engine's scene array
        /// </summary>
        /// <param name="scene">The scene that will  be added to the scene array</param>
        /// <returns>The index where the new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy all values from old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //Return the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {
            //If there is no key being pressed...
            if (!Console.KeyAvailable)
                //... return
                return 0;

            //Return the current key being pressed
            //And (true) makes it so it doesnt show the key displayed
            return Console.ReadKey(true).Key;
        }
      
        /// <summary>
        /// Ends the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }        
    }
}
