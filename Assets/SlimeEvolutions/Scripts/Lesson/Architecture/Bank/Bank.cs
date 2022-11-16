using System;

namespace SlimeEvolutions.Lesson.Architecture.Banks
{
    public static class Bank
    {
        private static BankInteractor bankInteractor;

        public static int Coins
        {
            get
            {
                CheckClass();
                return bankInteractor.Coins;
            }
        }
        public static bool IsInitialize { get; private set; }

        public static Action OnBankInitializedEvent;

        public static void Initialize(BankInteractor interactor)
        {
            bankInteractor = interactor;
            IsInitialize = true;
            OnBankInitializedEvent?.Invoke();
        }

        public static bool IsEnougthCoins(int value)
        {
            CheckClass();
            return bankInteractor.IsEnougthCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.AddCoins(sender, value);
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.SpendCoins(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialize)
                throw new Exception("Bank is't initialize");
        }

    }
}
