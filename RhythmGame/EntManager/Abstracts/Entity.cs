using System;
using System.Collections.Generic;
using System.Text;
using RhythmGame.EntManager.HelperClasses;

namespace RhythmGame
{
    /// <summary>
    /// Abstract class all Entities inherit from
    /// </summary>
    public abstract class Entity
    {
        public short mask;
        /// <summary>
        /// Contains systems used by this entity
        /// </summary>
        public EntManager.System[] sysList { get; private set; }

        public Entity(EntManager.System[] sysList)
        {
            this.sysList = sysList;
        }
    }
}
