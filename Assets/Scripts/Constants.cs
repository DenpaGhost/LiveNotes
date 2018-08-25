namespace Constants
{
    public static class GameConstants
    {
        public const byte MIN_NOTES_COUNT = 32;
        public const long WAIT_FOR_START_TIME = 10000000;
        public const float DISPLAY_UPPER_END_Y = 400,JUDGE_LINE_Y = -375;
        public const float NOTES_AREA_HEIGHT = DISPLAY_UPPER_END_Y - JUDGE_LINE_Y;
        public static readonly int[] POSITION_DATA = {1, 2, 4, 8, 16, 32, 64};
        public static readonly float[] LANE_POSITION_DATA_X = {-168.5f, -112.5f, -65.25f, 0, 65.25f, 112.5f, 168.5f};
    }
}