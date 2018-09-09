using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game
{
    public static class GameParameters
    {
        private static int _minListCount = 32;
        private static List<GameObject>[] _laneQueueList = new List<GameObject>[7];

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

        public static List<GameObject>[] LaneQueue
        {
            get { return _laneQueueList; }
        }
        
        public static AudioSource JudgeLineSpeaker { get; set; }
        public static GameObject JudgeTextObject { get; set; }

        public static GameObject PerfectTextView { get; set; }
        public static GameObject GreatTextView { get; set; }
        public static GameObject GoodTextView { get; set; }
        public static GameObject MissTextView { get; set; }

        public static ulong Perfect { get; set; }
        public static ulong Great { get; set; }
        public static ulong Good { get; set; }
        public static ulong Miss { get; set; }
        public static ulong NotesCount { get; set; }
    }
}
