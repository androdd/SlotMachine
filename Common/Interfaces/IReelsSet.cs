namespace Bede.SlotMachine.Common.Interfaces;

public interface IReelsSet
{
    void Init();
    string[,] Spin();
}