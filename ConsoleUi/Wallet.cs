namespace Bede.SlotMachine.ConsoleUi;

public class Wallet
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