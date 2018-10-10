
using System.Diagnostics;

namespace game
{
    public class NotesData
    {
        public NotesData(int lanesPosition, long targetTime, Stopwatch timer)
        {
            LanesPosition = lanesPosition;
            TargetTime = targetTime;
            Timer = timer;
        }

        public int LanesPosition { get; private set; }
        public long TargetTime { get; private set; }
        public Stopwatch Timer { get; private set; }
    }
}
