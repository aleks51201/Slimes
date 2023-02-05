namespace SlimeEvolutions.Stuff
{
    public static class ProgressionCalculator
    {
        public static int CalcProgress(int start, int stop, int step)
        {
            int result = 0;
            for(int i = start; i <= stop; i += step)
            {
                result += i * step;
            }
            return result;
        }
    }
}
