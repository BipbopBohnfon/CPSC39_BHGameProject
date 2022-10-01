using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame
{
    class BulletSelfDestruct : EntManager.System
    {
        /// <summary>
        /// Decides when the bullet should be destroyed
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            if (TimeNBeat.currentTime > ((Bullet) list[originId]).deathTime)
            {
                commands.Enqueue(new RhythmGame.EntManager.Commands.Kill(originId));
            }
        }
    }
}
