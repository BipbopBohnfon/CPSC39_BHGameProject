using System;

namespace RhythmGame.EntManager.HelperClasses
{
    public static class AngleMath
    {
        /// <summary>
        /// Takes in an angle and returns a unit vector pointing in that direction
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Unit Vector pointing in angle direction</returns>
        public static float[] Angle2Vect(float angle)
        {
            double radians = Math.PI * angle / 180f;
            float[] vector2 = { (float)Math.Cos(radians), (float)Math.Sin(radians) };
            return vector2;
        }

        /// <summary>
        /// Takes in a vector and returns the angle the vector is pointing toward
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Angle of Vector</returns>
        public static double Vect2Angle(int x, int y)
        {
            double angle = Math.Atan2(y, x);
            //if (angle < 0) angle += 360;

            return angle*180f/Math.PI;
        }

        /// <summary>
        /// A method used for linear interpolation between two points
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <returns>A unit vector pointing toward the target</returns>
        public static float[] lerpUnit(int[] origin, int[] target)
        {
            return Angle2Vect((float)Vect2Angle((int)(origin[0] - target[0]), (int)(origin[1] - target[1])));
        }

        /// <summary>
        /// A method used for linear interpolation between two points
        /// </summary>
        /// <param name="originx"></param>
        /// <param name="originy"></param>
        /// <param name="targetx"></param>
        /// <param name="targety"></param>
        /// <returns>Two components of a unit vector pointing to target</returns>
        public static float[] lerpUnit(int originx, int originy, int targetx, int targety)
        {
            return Angle2Vect((float)Vect2Angle((int)(originx - targetx), (int)(originy - targety)));
        }
    }
}
