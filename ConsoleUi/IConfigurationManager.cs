namespace Bede.SlotMachine.ConsoleUi;

using System.Collections.ObjectModel;

public interface IConfigurationManager
{
    ReadOnlyDictionary<string, float> GetCoefficients();
    ReadOnlyDictionary<string, int> GetProbabilityPercentages();
}