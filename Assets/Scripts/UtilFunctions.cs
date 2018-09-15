using System;
using UnityEngine;

public static class UtilFunctions
{
    public static string ShowFps()
    {
        var fps = 1f / Time.deltaTime;
        return String.Format("{0:#,0} fps", fps);
    }

    public static string PutComma(long num)
    {
        return String.Format("{0:#,0}", num);
    }
}