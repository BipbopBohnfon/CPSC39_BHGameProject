using System;
using System.Collections.Generic;
using static RhythmGame.TimeNBeat;

namespace RhythmGame.EntManager
{
    /// <summary>
    /// Abstract class all Systems inherit from
    /// </summary>
    public abstract class System
    {
        public abstract void Run(short id, Queue<Command> coms, List<Entity> dict);
    }
}
