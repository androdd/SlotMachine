namespace Bede.SlotMachine.ConsoleUi;

using System.Collections.ObjectModel;

public class ConfigurationManager : IConfigurationManager
{
    //TODO: Load from file
    //TODO: Validate that percentages add up to 100

    public ReadOnlyDictionary<string, float> GetCoefficients() => new(new Dictionary<string, float>
        { { "A", 0.4f }, { "B", 0.6f }, { "P", 0.8f }, { "*", 0f } });

    public ReadOnlyDictionary<string, int> GetProbabilityPercentages() => new(new Dictionary<string, int>
        { { "A", 45 }, { "B", 35 }, { "P", 15 }, { "*", 5 } });
}