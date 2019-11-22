using System;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Timer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        private long _currentTime = 0;
        private long _previousTime = 0;

        private float _deltaTime = 0.005f;

        public Timer()
        {
            _stopwatch.Start();
        }
        //restart stopwatch
        public void Restart()
        {
            _stopwatch.Restart();
        }

        //The time in seconds
        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }
        //get the delta time
        public float GetDeltaTime()
        {
            _previousTime = _currentTime;
            _currentTime = _stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _previousTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
