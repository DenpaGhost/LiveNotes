using UnityEngine;

public class ModuleData
{
    private readonly string clipName;

    public string ClipName => clipName;

    public string ClipPath => path;

    private readonly string path;

    public ModuleData(string clipName, string path)
    {
        this.clipName = clipName;
        this.path = path;
    }
}