
namespace Game
{
    public class NotesData
    {
        public NotesData(int lanesPosition, long targetTime, NotesTimer timer)
        {
            LanesPosition = lanesPosition;
            TargetTime = targetTime;
            Timer = timer;
        }

        public int LanesPosition { get; private set; }
        public long TargetTime { get; private set; }
        public NotesTimer Timer { get; set; }
    }
}
