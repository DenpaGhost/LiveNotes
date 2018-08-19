public class gameParameters{

    private static ushort bpm, num, repeat;
    private static byte max, min;

    public ushort Bpm
    {
        get { return bpm; }
        set { bpm = value; }
    }

    public ushort Num
    {
        get { return num; }
        set { num = value; }
    }

    public ushort Repeat
    {
        get { return repeat; }
        set { repeat = value; }
    }

    public byte Max
    {
        get { return max; }
        set { max = value; }
    }

    public byte Min
    {
        get { return min; }
        set { min = value; }
    }
}
