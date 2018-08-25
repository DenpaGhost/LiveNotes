namespace Constants
{
    public static class GameConstants
    {
        public const float DISPLAY_UPPER_END_Y = 400,JUDGE_LINE_Y = -375;
        public const float NOTES_AREA_HEIGHT = DISPLAY_UPPER_END_Y - JUDGE_LINE_Y;
        public static readonly int[] POSITION_DATA = {1, 2, 4, 8, 16, 32, 64};
        public static readonly float[] LANE_POSITION_DATA_X = {-168.5f, -112.5f, -56.25f, 0, 56.25f, 112.5f, 168.5f};
    }
}