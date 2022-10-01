using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame.EntManager.Commands
{
    /// <summary>
    /// Command to Spawn an entity from provided definition
    /// </summary>
    class Spawn : Command
    {
        /// <summary>
        /// Definition of the entity that will be spawned
        /// </summary>
        public EntDef spawnedEnt { private set; get; }

        /// <summary>
        /// Create a spawn command given an entity definition
        /// </summary>
        /// <param name="def">Entity Definition to spawn the new entity</param>
        public Spawn(EntDef def)
        {
            spawnedEnt = def;
        }

        public override void Run()
        {
            
        }

        public override String Type()
        {
            return "Spawn";
        }
    }
}
