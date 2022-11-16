namespace SlimeEvolutions.Lesson.Architecture.Banks
{
    public class BankInteractor : Interactor
    {
        private BankRepository bankRepository;

        public int Coins => bankRepository.Coins;

        public BankInteractor()
        {
        }

        public override void OnCreate()
        {

        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnougthCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
            bankRepository.Coins += value;
            bankRepository.Save();
        }
        public void SpendCoins(object sender, int value)
        {
            bankRepository.Coins -= value;
            bankRepository.Save();
        }
    }
}
