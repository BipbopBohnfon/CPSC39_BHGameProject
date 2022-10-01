using System;
using static RhythmGame.EntManager.HelperClasses.AngleMath;

namespace RhythmGame
{
    /// <summary>
    /// An entity that rotates around the playing field and fires bullets at the player
    /// </summary>
    class BulletSpawner : Entity
    {
        private const int angleVariance = 4;
        private const float distance = 320;
        private const float length = 40;
        /// <summary>
        /// Current angle of bulletspawner >> **FROM CENTER** <<
        /// </summary>
        public float angle { private set; get; }
        /// <summary>
        /// Beat when the last bullet was fired from this spawner
        /// </summary>
        public float beatOfLastShot { private set; get; }
        /// <summary>
        /// The beat on which this spawner should be killed
        /// </summary>
        public int deathBeat { private set; get; }
        /// <summary>
        /// The number of times this spawner fires per beat
        /// </summary>
        public float beatsPerShot { private set; get; }
        /// <summary>
        /// The number of pellets this spawner fires per shot (UNFINISHED)
        /// </summary>
        public int pelletsPerShot { private set; get; }
        /// <summary>
        /// The angle of spread of the pellets fired when multiple are shot (UNFINISHED)
        /// </summary>
        public int spread { private set; get; }
        /// <summary>
        /// The speed of bullets fired
        /// </summary>
        public int projectileSpeed { private set; get; }
        /// <summary>
        /// Speed at which spawner rotates around the arena
        /// </summary>
        public short angularVelocity { private set; get; }
        
        /// <summary>
        /// Constructor for a bullet spawner
        /// </summary>
        /// <param name="sysList">Systems that will control the spawner</param>
        /// <param name="def">The spawners entity definition</param>
        public BulletSpawner(EntManager.System[] sysList, EntDef def) : base(sysList)
        {
            angle = def.miscInfo[0];
            angularVelocity = def.miscInfo[1];
            deathBeat = (int) TimeNBeat.currentBeat + def.miscInfo[2];
            beatsPerShot = 1f / (float) def.miscInfo[3];
            pelletsPerShot = def.miscInfo[4];
            projectileSpeed = def.miscInfo[5];
            spread = def.miscInfo[6];
            beatOfLastShot = 0;
        }

        /// <summary>
        /// Public facing interface for rotating the spawner
        /// </summary>
        /// <param name="angle">Degrees to rotate that frame</param>
        public void Rotate(float angle)
        {
            this.angle += angle;
        }

        /// <summary>
        /// Method to find the points of the trapezoidal form of the bullet spawner
        /// </summary>
        /// <returns>Points of the trapezoid as an array</returns>
        public System.Drawing.Point[] Points()
        {
            // Solving for unit vector pointing toward points
            float[] leftUnit = Angle2Vect(angle - angleVariance);
            float[] rightUnit = Angle2Vect(angle + angleVariance);
            System.Drawing.Point[] points = new System.Drawing.Point[4];

            // Multiplying the unit vectors by the distance to the point to get position of each point
            points[0] = new System.Drawing.Point((Int32)(leftUnit[0] * (distance + length)) + 400, (Int32)(leftUnit[1] * (distance + length)) + 400);
            points[3] = new System.Drawing.Point((Int32)(rightUnit[0] * (distance + length)) + 400, (Int32)(rightUnit[1] * (distance + length)) + 400);
            points[1] = new System.Drawing.Point((Int32)(leftUnit[0] * (distance)) + 400, (Int32)(leftUnit[1] * (distance)) + 400);
            points[2] = new System.Drawing.Point((Int32)(rightUnit[0] * (distance)) + 400, (Int32)(rightUnit[1] * (distance)) + 400);

            return points;
        }

        /// <summary>
        /// Distance from center to the spawner
        /// </summary>
        /// <returns></returns>
        public float QueryDist()
        {
            return distance;
        }

        /// <summary>
        /// Notifies Spawner that it has fired
        /// </summary>
        public void Fire()
        {
            beatOfLastShot = TimeNBeat.currentBeat;
        }
    }
}
