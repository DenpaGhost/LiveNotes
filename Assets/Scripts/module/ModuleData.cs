using UnityEngine;

public class ModuleData
{
    public string ClipName { get; }

    public string ClipPath { get; }

    public ModuleData(string clipName, string path)
    {
        this.ClipName = clipName;
        this.ClipPath = path;
    }
}