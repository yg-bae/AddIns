using System.Diagnostics;

namespace CommonFunction
{
    public class StopWatch
    {
        private Stopwatch stopwatch;

        public StopWatch()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Start();
        }
        public void Stop(string frontMessage = null)
        {
            stopwatch.Stop();
            if(frontMessage == null)
            {
                Debug.WriteLine("{0}ms", stopwatch.ElapsedMilliseconds);
            }
            else
            {
                Debug.WriteLine("{0}, {1}ms", frontMessage, stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
