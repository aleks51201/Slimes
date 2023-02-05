namespace SlimeEvolutions.Stuff
{
    public static class ProgressionCalculator
    {
        public static int CalcProgress(int start, int stop, int step)
        {
            int result = 0;
            for(int i = start; i <= stop; i ++)
            {
                result += i * step;
            }
            return result;
        }
    }
}
