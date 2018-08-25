
namespace Game
{
    public class NotesData
    {
        public NotesData(int lanesPosition, long targetTime)
        {
            LanesPosition = lanesPosition;
            TargetTime = targetTime;
        }

        public int LanesPosition { get; private set; }

        public long TargetTime { get; private set; }
    }
}
