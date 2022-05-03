namespace Bede.SlotMachine.Common.Interfaces;

public interface IWinCalculator
{
    float GetAmount(string[,] reels, float stake);
}