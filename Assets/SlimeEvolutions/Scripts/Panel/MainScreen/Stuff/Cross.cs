namespace SlimeEvolutions.Panel.MainScreen.Stuff
{
    public class Cross
    {
        private Slime slime1;
        private Slime slime2;

        public Cross(Slime slime1, Slime slime2)
        {
            this.slime1 = slime1;
            this.slime2 = slime2;
        }

        public Slime Crossing()
        {
            bool[] genom1 = slime1.Genome.GetArrayIsDominantGene();
            bool[] genom2 = slime2.Genome.GetArrayIsDominantGene();
            int[] genesId1 = slime1.Genome.GetGenesId();
            int[] genesId2 = slime2.Genome.GetGenesId();
            Slime slimeResult = new();
            slimeResult.RandomSlimeWithoutGenome(slime1.Lvl, slime2.Lvl);
            int[] genesId = new int[genom1.Length];
            System.Random rnd = new();
            for (int i = 0; i < genom1.Length; i++)
            {
                if (genom1[i] && !genom2[i])
                {
                    int x = rnd.Next(0, 100);
                    if (x > 25)
                    {
                        genesId[i] = genesId1[i];
                    }
                    else
                    {
                        genesId[i] = genesId2[i];
                    }
                }
                else if (!genom1[i] && genom2[i])
                {
                    int x = rnd.Next(0, 100);
                    if (x > 25)
                    {
                        genesId[i] = genesId2[i];
                    }
                    else
                    {
                        genesId[i] = genesId1[i];
                    }
                }
                else
                {
                    int x = rnd.Next(2);
                    if (x == 0)
                    {
                        genesId[i] = genesId1[i];
                    }
                    else
                    {
                        genesId[i] = genesId2[i];
                    }
                }
            }
            slimeResult.Genome = new Genome(genesId);
            return slimeResult;
        }
    }
}
