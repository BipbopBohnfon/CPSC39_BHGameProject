using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmGame
{
    /// <summary>
    /// Inherited by entities that use kinematic motion
    /// </summary>
    public class KinematicBody : Entity
    {
        public float posx { protected set; get; }
        public float posy { protected set; get; }
        public float velx { protected set; get; }
        public float vely { protected set; get; }
        public float angle { protected set; get; }

        public KinematicBody(EntManager.System[] sysList) : base(sysList)
        {
            
        }
    }
}
