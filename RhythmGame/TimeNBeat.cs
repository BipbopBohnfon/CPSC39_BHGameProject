using System;
using System.Diagnostics;

namespace RhythmGame
{
    /// <summary>
    /// Keeps track of the time in milliseconds and the current beat in the song
    /// </summary>
    class TimeNBeat
    {
        public const float millisPerBeat = (60f * 1000f) / 116f; // HEA is at 116 beats per minute
        /// <summary>
        /// Current beat in the song
        /// </summary>
        public static float currentBeat { get; private set; }
        /// <summary>
        /// Current millisecond in the song
        /// </summary>
        public static long currentTime { get; private set; }
        /// <summary>
        /// Time between current frame and last frame
        /// </summary>
        public static long deltaTime { get; private set; }
        
        private Stopwatch timer;
        private long lastFrame;


        /// <summary>
        /// Allows a timer to be created that can update the TimeNBeat static members
        /// </summary>
        public TimeNBeat ()
        {
            timer = new Stopwatch();
            timer.Start();
            lastFrame = 0;
        }

        /// <summary>
        /// Does what it says
        /// </summary>
        public void UpdateTime()
        {
            currentTime = timer.ElapsedMilliseconds;
            currentBeat = (currentTime / millisPerBeat);
        }
        /// <summary>
        /// Calculates time between last frame and current frame
        /// </summary>
        public void FixedUpdateTime()
        {
            deltaTime = currentTime - lastFrame;
            lastFrame = currentTime;
        }

        /// <summary>
        /// Broken...
        /// </summary>
        public void Reset()
        {
            timer.Restart();
            lastFrame = 0;
            currentTime = 0;
            currentBeat = 0;
        }
    }
}
