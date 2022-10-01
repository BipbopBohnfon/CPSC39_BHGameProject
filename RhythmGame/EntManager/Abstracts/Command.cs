using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmGame
{
    /// <summary>
    /// Abstract Method that all commands inherit from
    /// </summary>
    public abstract class Command
    {
        public short originId;
        public short[] affectedIds;
        public abstract void Run();
        public abstract String Type();
    }
}
