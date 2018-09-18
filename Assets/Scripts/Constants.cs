using UnityEngine;

public static class GameConstants
{
    public const float DISPLAY_UPPER_END_Y = 400, JUDGE_LINE_Y = -375;
    public const float NOTES_AREA_HEIGHT = DISPLAY_UPPER_END_Y - JUDGE_LINE_Y;
    public const long DEFAULT_OFFSET = 30000000;
    public static readonly int[] POSITION_DATA = {1, 2, 4, 8, 16, 32, 64};
    public static readonly string[] KEY_NAME = {"KeyA","KeyAs","KeyB","KeyBs","KeyC","KeyCs","KeyD"};
    public static readonly float[] LANE_POSITION_DATA_X = {-168.5f, -112.5f, -56.25f, 0, 56.25f, 112.5f, 168.5f};
    public const long NOTE_IS_ON_LINE_WAIT_TIME = 1200000;
    public const long JUDGE_TEXT_INVISIBLE_TIME = 5000000;

    public const long JUDGE_MISS = 1200000;
    public const long JUDGE_GOOD = 600000;
    public const long JUDGE_GREAT = 400000;
    public const long JUDGE_PERFECT = 200000;

    public const ulong SCORE_PERFECT = 6;
    public const ulong SCORE_GREAT = 3;
    public const ulong SCORE_GOOD = 1;

    public const byte SPEED_MAX = 10, SPEED_MIN = 1;
        
    public enum Judge
    {
        Perfect,
        Great,
        Good,
        Miss
    }
    
}

public static class ConstantsColors
{
    public static readonly Color KEY_COLOR_WHITE = new Color32(250,250,250 ,255);//#FAFAFA
    public static readonly Color KEY_COLOR_BLACK = new Color32(33,33,33 ,255);//#212121
    public static readonly Color KEY_COLOR_WHITE_PUSH = new Color32(239,154,154 ,255);//#ef9a9a
    public static readonly Color KEY_COLOR_BLACK_PUSH = new Color32(239,83,80 ,255);//#ef5350
        
}

public static class UiConstants
{
    public const string QUICK_HIGHLIGHT_TRIGGER = "quickHighlight";
    public const string ARTIST_HIGHLIGHT_TRIGGER = "artistHighlight";
    public const string SETTING_HIGHLIGHT_TRIGGER = "settingsHighlight";
    public const string EXIT_HIGHLIGHT_TRIGGER = "exitHighlight";
    public const string SUBMIT_TRIGGER = "Submit";
    public const string EXIT_DIALOG_SHOW_TRIGGER = "exitDialogShow";
    public const string DIALOG_IDLE_TRIGGER = "idle";
}

public static class DialogTriggerConstants
{
    public const string SELECTED = "Selected";
    public const string NORMAL = "Normal";
}