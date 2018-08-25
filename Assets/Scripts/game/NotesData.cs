
namespace Game
{
    public class NotesData
    {
        public NotesData(int position, long targetTime)
        {
            Position = position;
            TargetTime = targetTime;
        }

        public int Position { get; private set; }

        public long TargetTime { get; private set; }
    }
}
