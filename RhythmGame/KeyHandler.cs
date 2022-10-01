using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmGame
{
    /// <summary>
    /// A hacky static class to allow the player entity to know if a button was pushed
    /// </summary>
    public static class KeyHandler
    {
        public static bool W { private set; get; }
        public static bool A { private set; get; }
        public static bool S { private set; get; }
        public static bool D { private set; get; }

        public static void wChange(bool tf)
        {
            W = tf;
        }
        public static void aChange(bool tf)
        {
            A = tf;
        }
        public static void sChange(bool tf)
        {
            S = tf;
        }
        public static void dChange(bool tf)
        {
            D = tf;
        }
    }
}
