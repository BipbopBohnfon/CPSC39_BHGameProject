using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RhythmGame.EntManager.HelperClasses.AngleMath;

namespace RhythmGame.EntManager.Systems
{
    class SpawnerFire : EntManager.System
    {
        /// <summary>
        /// Spawns bullets based on spawner position and angle, as well as current beat and spawner fire rate
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            BulletSpawner current = (BulletSpawner) list[originId];

            if (current.beatOfLastShot + current.beatsPerShot < TimeNBeat.currentBeat)
            {
                // calculating vector pointing toward spawner
                float[] vectors = Angle2Vect(current.angle);

                // Finding position of the spawner
                int posx = (int)(400f - (-vectors[0] * 300f));
                int posy = (int)(400f - (-vectors[1] * 300f));

                // Finding unit vector from spawner to center
                float[] centerVels = lerpUnit(posx, posy, 400, 400);
                centerVels[0] = -centerVels[0] * current.projectileSpeed * 5;
                centerVels[1] = -centerVels[1] * current.projectileSpeed * 5;

                // Spawning bullet firing toward center
                commands.Enqueue(new RhythmGame.EntManager.Commands.Spawn(new EntDef("bullet", posx, posy, 
                                 new short[] { (short) centerVels[0], (short) centerVels[1] })));
                current.Fire(); // Notify spawner a bullet was fired
            }

        }
    }
}
