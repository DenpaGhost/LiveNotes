namespace game
{
    public abstract class BaseComposer
    {
        private byte max;
        private byte min;

        public abstract int[] GeneratePhrase(ushort length, byte max, byte min);
    }
}