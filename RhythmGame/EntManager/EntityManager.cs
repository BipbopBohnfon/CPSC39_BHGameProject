using System;
using System.Collections.Generic;
using static RhythmGame.EntSpawner;

namespace RhythmGame
{
    /// <summary>
    /// The heart of the beast. This is the entity handler. It can be passed an entity definition
    /// and will spawn an entity into the game based off of that. It also processes all
    /// information stored by each entity such as layermask, position, velocity, movement, and what not.
    /// </summary>
    class EntityManager
    {
        /// <summary>
        /// holds all commands to be processed in EntManager
        /// </summary>
        Queue<Command> commands;
        /// <summary>
        /// Holds list of entities to be spawned in EntManager
        /// </summary>
        Queue<EntDef> spawnQueue;
        /// <summary>
        /// Holds all active entities in the game
        /// </summary>
        public List<Entity> entList { private set; get; }

        /// <summary>
        /// Constructor for EntityManager, Starts the game
        /// </summary>
        public EntityManager()
        {
            entList = new List<Entity>();
            commands = new Queue<Command>();
            spawnQueue = new Queue<EntDef>();

            Spawn(new EntDef("player", 400, 400));
        }

        /// <summary>
        /// Runs one tick of the game
        /// </summary>
        public void Update()
        {
            SpawnFromQueue();
            RunSystems();
            ProcCommands();
            SortList();
        }

        /// <summary>
        /// Spawns an entity and adds it to the list
        /// </summary>
        /// <param name="def"></param>
        public void Spawn(EntDef def)
        {
            //if (def.entName.Equals("bullet"))
            entList.Add(CreateEnt(def));
        }

        /// <summary>
        /// Runs systems and passes command queue to them
        /// </summary>
        private void RunSystems()
        {
            for (short i = 0; i < entList.Count; i++)
            {
                foreach(EntManager.System sys in entList[i].sysList)
                {
                    sys.Run(i, commands, entList);
                }
            }
        }

        /// <summary>
        /// Process all queued commands
        /// </summary>
        private void ProcCommands()
        {
            Queue<short> toDestroy;
            // Only processes
            if (commands.Count > 0) toDestroy = new Queue<short>();

            Command current;
            while (commands.Count > 0)
            { // Repeat until command queue is emptied
                current = commands.Dequeue();
                if ((current is RhythmGame.EntManager.Commands.Kill)) // If pattern matches the Kill type
                {
                    short kill = ((RhythmGame.EntManager.Commands.Kill)current).affectedIds[0];
                    if (kill <= entList.Count) entList.Remove(entList[kill]);
                } else if (current is RhythmGame.EntManager.Commands.Spawn) // If pattern matches the Spawn type
                {
                    spawnQueue.Enqueue(((RhythmGame.EntManager.Commands.Spawn)current).spawnedEnt);
                }
                else // Any other pattern
                {
                    current.Run(); // Shouldn't Be Technically Possible
                    throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Sort the list by moving all empty spaces past the index at Count()
        /// </summary>
        private void SortList()
        {
            short found = 0;
            while (found < entList.Count) 
            { // Iterates through entList until all Entities are found
                if (entList[found] != null) found++;
                else
                {
                    for (short i = found; entList[found] == null; i++)
                    { // Searches for next entity in the list
                        if (entList[i] != null)
                        {
                            // Replaces empty space at found
                            entList[found] = entList[i]; 
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if SpawnQueue has any entities and spawns all from the queue
        /// </summary>
        private void SpawnFromQueue()
        {
            while (spawnQueue.Count != 0)
            {
                Spawn(spawnQueue.Dequeue());
            }
        }
    }
}