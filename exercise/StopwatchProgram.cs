using System;

namespace ClassExercise 
{
    public class Stopwatch 
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private TimeSpan _duration;
        private bool _isStart;

        public void Run()
        {

            while (true)
            {
                Console.Write("Start or Stop (q to exit): ");
                var inputStr = Console.ReadLine().ToLower();

                if (inputStr == "start")
                {
                    this.Start();
                }
                else if (inputStr == "stop")
                {
                    this.Stop();
                }
                else if (inputStr == "q")
                {
                    break;
                }
            }
        }

        private void Start()
        {
            if (_isStart)
                throw new InvalidOperationException("Stopwatch is already running!");

            _startTime = DateTime.Now;
            _isStart = true;
        }

        private void Stop()
        {
            if (!_isStart)
                throw new InvalidOperationException("Stopwatch is not running!");

            _endTime = DateTime.Now;
            _duration = _endTime - _startTime;

            Console.WriteLine($"Duration is {this._duration}");

            _isStart = false;
        }
    }

    class StopwatchProgram
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Run();
        }
    }
}