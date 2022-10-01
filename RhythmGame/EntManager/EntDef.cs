using System;

namespace RhythmGame
{
    /// <summary>
    /// This is not going to stay if I reuse this.
    /// This is awful.
    /// This sucks.
    /// </summary>
    public struct EntDef
    {
        public String entName;
        public float posx;
        public float posy;
        public short[] miscInfo;

        /// <summary>
        /// Hardcoded constructor for the player and the background
        /// </summary>
        /// <param name="entName"></param>
        /// <param name="posx"></param>
        /// <param name="posy"></param>
        public EntDef(String entName, float posx, float posy)
        {
            this.entName = entName;
            this.posx = posx;
            this.posy = posy;
            miscInfo = null;
        }

        /// <summary>
        /// Hardcoded constructor for bullets
        /// </summary>
        /// <param name="entName">Boolit</param>
        /// <param name="posx">X Position</param>
        /// <param name="posy">Y Position</param>
        /// <param name="vels">Velocity [x, y] of bullet</param>
        public EntDef(String entName, float posx, float posy, short[] vels)
        {
            this.entName = entName;
            this.posx = posx;
            this.posy = posy;
            miscInfo = vels;
        }

        /// <summary>
        /// Hardcoded constructor for BulletSpawners and BulletWaves
        /// </summary>
        /// <param name="entName">Entity type name</param>
        /// <param name="posx">X Position of entity on spawn</param>
        /// <param name="posy">Y Position of entity on spawn</param>
        /// <param name="spray">An array with parameters for how a bulletspawner will shoot and move</param>
        public EntDef(String entName, short[] spray)
        {
            this.entName = entName;
            this.posx = 0;
            this.posy = 0;
            miscInfo = spray;
            /* Spray: |StartAngle, Angular Velocity, Number of beats, Shots per Beat, Pellets per Shot, Projectile Speed, Spread| */
            /* Wave: |Num Bullets, Starting Side 0:Top 1:Right 2:Bottom 3:Left| */
        }
    }
}
