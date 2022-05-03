namespace Bede.SlotMachine.Services;

using Bede.SlotMachine.Common.Interfaces;

public class Wallet : IWallet
{
    public float Balance { get; private set; }

    public void Withdraw(float amount)
    {
        Balance -= amount;

        //TODO: Validate for negative balance and send debt collectors
    }

    public void Deposit(float amount)
    {
        Balance += amount;
    }
}