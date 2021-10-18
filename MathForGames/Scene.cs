using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        /// <summary>
        /// Array that contains all actors in the scene
        /// </summary>
        private Actor[] _actors;

        public Scene()
        {
            _actors = new Actor[0];
        }


        /// <summary>
        /// Calls start for all actors in the actors array
        /// </summary>
        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
                
        }

        /// <summary>
        /// Calls update for every actor in the scene.
        /// Calls start for the actor if it hasn't already been called.
        /// </summary>
        public virtual void Update()
        {
            //Iterates through the actors
            for(int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                _actors[i].Start();

                _actors[i].Update();

                //Check for collision _actors[j] is the array going through actors
                for (int j = 0; j < _actors.Length; j++)
                {
                    if (_actors[i].Position == _actors[j].Position && j != i)
                        _actors[i].OnCollision(_actors[j]);
                    
                }
            }
        }
        
        /// <summary>
        /// Calls draw for every actor in the array
        /// </summary>
        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
        /// <summary>
        /// Adds an actor 
        /// </summary>
        /// <param name="actor"></param>
        public virtual void AddActor(Actor actor)
        {
            //Creats a temp array that is larger than the orignal array
            Actor[] tempArray = new Actor[_actors.Length + 1];

            //Clopy all the values from the orginal array into the temp array
            for (int i = 0; i < _actors.Length; i++)
            {
                tempArray[i] = _actors[i];
            }

            //Add the new actor to the end of the new array
            tempArray[_actors.Length] = actor;

            //Sets the old array to be the new array
            _actors = tempArray;
        }

        /// <summary>
        /// Removes the actor from the scene
        /// </summary>
        /// <param name="actor">The actor to remove</param>
        /// <returns>False if the actor was not in the scene array</returns>
        public virtual bool RemoveActor(Actor actor)
        {
            //Create a variable to store if the removal was successful
            bool actorRemoved = false;

            //Create a new array that is samller than the orignal
            Actor[] tempArray = new Actor[_actors.Length - 1];

            //Copy all values exept the actor we dont want into the new array
            int j = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                //If the actor that the loop is on is not the one to remove...
                if (_actors[i] != actor)
                {
                    //...add the actor into the new array and increment the temp array counter
                    tempArray[j] = _actors[i];
                    j++;
                }
                //Otherwise if this actor is the one to remove...
                else
                {
                    //...set actor removed to true
                    actorRemoved = true;                    
                }
            }

            if (actorRemoved)
            {
                _actors = tempArray;
            }
            
            return actorRemoved;
        }
    }
}
