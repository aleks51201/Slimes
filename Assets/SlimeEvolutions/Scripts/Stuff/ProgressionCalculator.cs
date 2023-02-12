namespace SlimeEvolutions.Stuff
{
    public static class ProgressionCalculator
    {
        public static int CalcTotalExpForLvl(int start, int stop, int step)
        {
            int result = 0;
            for(int i = start; i < stop; i ++)
            {
                 result += i * step;
            }
            return result;
        }

        public static int CalcTotalLvlForExp(int totalExp, int multiplier)
        {
            int result = 0;
            for(int i = 0; i <= totalExp; i += multiplier * result)
            {
                result++;
            }
            return result;
        }
    }
}
