using UnityEngine;

namespace Constants
{
    public static class GameConstants
    {
        public const float DISPLAY_UPPER_END_Y = 400,JUDGE_LINE_Y = -375;
        public const float NOTES_AREA_HEIGHT = DISPLAY_UPPER_END_Y - JUDGE_LINE_Y;
        public const long DEFAULT_OFFSET=30000000;
        public static readonly int[] POSITION_DATA = {1, 2, 4, 8, 16, 32, 64};
        public static readonly float[] LANE_POSITION_DATA_X = {-168.5f, -112.5f, -56.25f, 0, 56.25f, 112.5f, 168.5f};
    }

    public static class ConstantsColors
    {
        public static readonly Color KEY_COLOR_WHITE = new Color32(250,250,250 ,255);//#FAFAFA
        public static readonly Color KEY_COLOR_BLACK = new Color32(33,33,33 ,255);//#212121
        public static readonly Color KEY_COLOR_WHITE_PUSH = new Color32(239,154,154 ,255);//#ef9a9a
        public static readonly Color KEY_COLOR_BLACK_PUSH = new Color32(239,83,80 ,255);//#ef5350
        
    }
}