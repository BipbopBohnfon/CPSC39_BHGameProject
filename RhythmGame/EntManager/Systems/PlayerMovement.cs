using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RhythmGame.KeyHandler;

namespace RhythmGame.EntManager.Systems
{
    class PlayerMovement : EntManager.System
    {
        /// <summary>
        /// Processes play movement based on user input
        /// </summary>
        /// <param name="originId"></param>
        /// <param name="commands"></param>
        /// <param name="list"></param>
        public override void Run(short originId, Queue<Command> commands, List<Entity> list)
        {
            Player player = (Player) list[originId];
            int moveX = 0;
            int moveY = 0;
            if (KeyHandler.W) moveY++;
            if (KeyHandler.A) moveX--;
            if (KeyHandler.S) moveY--;
            if (KeyHandler.D) moveX++;
            if (moveX != 0 && moveY != 0)
            {
                moveX = (int) ((float) moveX * 0.707 * (float) TimeNBeat.deltaTime);
                moveY = (int) ((float) moveY * 0.707 * (float) TimeNBeat.deltaTime);
                player.Move(moveX, -moveY);
            } else
            {
                player.Move((int) (moveX * TimeNBeat.deltaTime), (int) -(moveY * TimeNBeat.deltaTime));
            }
        }
    }
}
