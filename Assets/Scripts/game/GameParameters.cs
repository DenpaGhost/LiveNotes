using System.Collections.Generic;

namespace Game
{
    public static class GameParameters
    {
        private static int _minListCount = 32;

        public static long Interval { get; set; }

        public static ushort Bpm { get; set; }

        public static ushort Num { get; set; }

        public static ushort Repeat { get; set; }

        public static byte Max { get; set; }

        public static byte Min { get; set; }
        
        public static byte Speed { get; set; }

        public static byte NoteLength { get; set; }

        public static int MinListCount
        {
            get { return _minListCount; }
            set { _minListCount = value; }
        }

        public static List<NotesData> NotesList { get; set; }
    }
}
