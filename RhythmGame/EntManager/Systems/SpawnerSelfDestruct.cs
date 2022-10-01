using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame.EntManager.Systems
{
    class SpawnerSelfDestruct : EntManager.System
    {
        /// <summary>
        /// Destroy spawner when lifetime is up
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            if (TimeNBeat.currentBeat > ((BulletSpawner)list[originId]).deathBeat)
            {
                commands.Enqueue(new RhythmGame.EntManager.Commands.Kill(originId));
            }
        }
    }
}
