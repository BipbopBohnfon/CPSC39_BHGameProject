using System;
using System.Collections.Generic;

namespace RhythmGame
{
    public class BulletMovement : EntManager.System
    {
        /// <summary>
        /// Processes bullet movement
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            Bullet current = (Bullet) list[originId];
            current.Move((int) (current.velx * TimeNBeat.deltaTime) / 1000, (int) (current.vely * TimeNBeat.deltaTime) / 1000);
        }
    }
}
