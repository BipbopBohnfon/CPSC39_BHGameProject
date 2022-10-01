using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmGame
{
    /// <summary>
    /// 2d Kinematic bodies. No collision detection on their own
    /// but other objects can detect them with their mask
    /// </summary>
    public class Bullet : KinematicBody
    {
        public const int lifetime = 8000;
        public long deathTime { private set; get; }
        public Bullet(EntManager.System[] sysList, EntDef def) : base(sysList)
        {
            posx = def.posx;
            posy = def.posy;
            velx = def.miscInfo[0];
            vely = def.miscInfo[1];
            deathTime = TimeNBeat.currentTime + lifetime;
        }

        public void Move(int delx, int dely)
        {
            posx += delx / 3;
            posy += dely / 3;
        }
    }
}
