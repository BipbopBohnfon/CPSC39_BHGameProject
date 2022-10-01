using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmGame.EntManager.Commands
{
    /// <summary>
    /// Command to remove an entity from the entlist
    /// </summary>
    class Kill : Command
    {
        /// <summary>
        /// Constructor for a Kill Command
        /// </summary>
        /// <param name="id">ID Of the Entity to be Killed</param>
        public Kill (short id)
        {
            affectedIds = new short[] { id };
        }

        /// <summary>
        /// There's no reason to run this
        /// </summary>
        public override void Run()
        {

        }

        public override string Type()
        {
            return "Kill";
        }
    }
}
