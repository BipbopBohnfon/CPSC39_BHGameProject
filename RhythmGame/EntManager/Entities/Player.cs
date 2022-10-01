using System;
using System.Collections.Generic;
using System.Text;
using static RhythmGame.EntManager.HelperClasses.AngleMath;

namespace RhythmGame
{
    class Player : KinematicBody
    {
        const int playableRadius = 400;
        const float playerSpeed = 0.4f;
        /// <summary>
        /// Determines whether the player is alive or dead
        /// </summary>
        public bool isDead { private set; get; }

        /// <summary>
        /// Player's constructor
        /// </summary>
        /// <param name="sysList">Array of systems</param>
        /// <param name="def">The player's unit definition</param>
        public Player(EntManager.System[] sysList, EntDef def) : base(sysList)
        {
            posx = 400;
            posy = 400;
            angle = 0;
            velx = 0;
            vely = 0;
            isDead = false;
        }

        /// <summary>
        /// Moves the player the passed in distance and ensures the player stays in the arena's radius
        /// </summary>
        /// <param name="delx"></param>
        /// <param name="dely"></param>
        public void Move(int delx, int dely)
        {
            posx += delx * playerSpeed;
            posy += dely * playerSpeed;

            double dist = Math.Sqrt(((playableRadius - posx)*(playableRadius - posx)) + ((playableRadius - posy) *(playableRadius - posy)));
            if (dist > 285)
            {
                float[] vects = lerpUnit((int)posx, (int)posy, 400, 400);
                posx -= ((float)dist - 285f) * vects[0];
                posy -= ((float)dist - 285f) * vects[1];
            }
        }

        /// <summary>
        /// Kill the player
        /// </summary>
        public void Kill()
        {
            isDead = true;
        }
    }
}
