using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame.EntManager.Systems
{
    class PlayerCollision : EntManager.System
    {
        /// <summary>
        /// Determines whether or not the player has made physical contact with a bullet
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            Player player = (Player) list[originId];
            for (short i = 0; i < list.Count; i++)
            {
                if (list[i] is Bullet)
                {
                    Bullet bullet = (Bullet)list[i];

                    if (Math.Sqrt(((player.posx - bullet.posx)*(player.posx - bullet.posx))+((player.posy - bullet.posy) *(player.posy - bullet.posy))) < 15)
                    {
                        player.Kill();
                    }
                }
            }
        }
    }
}
