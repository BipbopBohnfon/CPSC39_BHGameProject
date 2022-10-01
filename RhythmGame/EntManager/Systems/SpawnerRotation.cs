using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame.EntManager.Systems
{
    class SpawnerRotation : EntManager.System
    {
        /// <summary>
        /// Adding to spawner angle based on rotation speed
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            BulletSpawner current = (BulletSpawner) list[originId];

            current.Rotate(current.angularVelocity * TimeNBeat.deltaTime / 360f);
        }
    }
}
