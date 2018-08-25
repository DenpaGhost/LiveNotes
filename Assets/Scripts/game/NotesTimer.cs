using System.Diagnostics;

namespace Game
{
    public class NotesTimer
    {
        private Stopwatch _stopWatch;

        public NotesTimer()
        {
            _stopWatch = new Stopwatch();
        }
        
        public Stopwatch StopWatch
        {
            get { return _stopWatch; }
        }
        
    }
}