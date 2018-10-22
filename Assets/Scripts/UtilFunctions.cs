using System;
using UnityEngine;

public static class UtilFunctions
{
    public static string PutComma(long num)
    {
        return $"{num:#,0}";
    }
}