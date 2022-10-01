using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RhythmGame.TimeNBeat;

namespace RhythmGame
{
    /// <summary>
    /// Hardcoded spawns for bullet spawners synched to some Carpenter Brut
    /// </summary>
    class GameTiming
    {
        bool[] sets = new bool[10]; // Booleans to tell if a wave has been spawned
        public GameTiming()
        {

        }

        /// <summary>
        /// Check if wave for the current beat has been spawned
        /// </summary>
        /// <param name="game"></param>
        public void Check(EntityManager game)
        {
            if (TimeNBeat.currentBeat > 8 && !sets[0])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 90, 10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 180, 10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 270, 10, 4, 1, 1, 100, 0 }));
                sets[0] = true;
            } else if (TimeNBeat.currentBeat > 12 && !sets[1])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 180, -10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 270, -10, 4, 1, 1, 100, 0 }));
                sets[1] = true;
            } else if(TimeNBeat.currentBeat > 16 && !sets[2])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 90, 10, 4, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 270, 10, 4, 1, 1, 100, 0 }));
                sets[2] = true;
            } else if (TimeNBeat.currentBeat > 20 && !sets[3])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 10, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 20, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 30, 2, 1, 1, 100, 0 }));
                sets[3] = true;
            } else if (TimeNBeat.currentBeat > 24 && !sets[4])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -10, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -20, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -30, 2, 1, 1, 100, 0 }));
                sets[4] = true;
            } else if (TimeNBeat.currentBeat > 28 && !sets[5])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 10, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 20, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 30, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -10, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -20, 2, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -30, 2, 1, 1, 100, 0 }));
                sets[5] = true;
            }
            else if (TimeNBeat.currentBeat > 32 && !sets[6])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -30, 8, 1, 1, 100, 0 }));
                sets[6] = true;
            }
            else if (TimeNBeat.currentBeat > 40 && !sets[7])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 30, 8, 1, 1, 100, 0 }));
                sets[7] = true;
            }
            else if (TimeNBeat.currentBeat > 48 && !sets[8])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -30, 8, 1, 1, 100, 0 }));
                sets[8] = true;
            }
            else if (TimeNBeat.currentBeat > 56 && !sets[9])
            {
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, -3, 8, 4, 1, 200, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 0, 30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 120, 30, 8, 1, 1, 100, 0 }));
                game.Spawn(new EntDef("bulletspawner", new short[7] { 240, 30, 8, 1, 1, 100, 0 }));
                sets[9] = true;
            }
        }
    }
}
