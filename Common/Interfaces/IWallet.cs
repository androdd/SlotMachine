namespace Bede.SlotMachine.Common.Interfaces;

public interface IWallet
{
    float Balance { get; }
    void Withdraw(float amount);
    void Deposit(float amount);
}