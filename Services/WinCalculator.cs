namespace Bede.SlotMachine.Services;

using System.Collections.ObjectModel;

using Bede.SlotMachine.Common;
using Bede.SlotMachine.Common.Extensions;
using Bede.SlotMachine.Common.Interfaces;

public class WinCalculator : IWinCalculator
{
    private readonly IConfigurationManager _configurationManager;

    public WinCalculator(IConfigurationManager configurationManager)
    {
        configurationManager.NotNullArgument(nameof(configurationManager));

        _configurationManager = configurationManager;
    }

    public float GetAmount(string[,] reels, float stake)
    {
        //TODO: Store in memory instead of getting them every time
        ReadOnlyDictionary<string, float> coefficients = _configurationManager.GetCoefficients();

        var coefficient = 0f;

        for (int r = 0; r < MachineConstants.ReelsCount; r++)
        {
            // First meaningful symbol
            var symbol = string.Empty;
            var reelCoefficient = 0f;

            for (int s = 0; s < MachineConstants.SymbolsPerReel; s++)
            {
                if (reels[s, r] == "*")
                {
                    continue;
                }

                if (symbol == string.Empty)
                {
                    // Store first meaningful symbol to compare with others
                    symbol = reels[s, r];
                }
                else if (symbol != reels[s, r])
                {
                    // Symbols are not equal - not a Win combination
                    reelCoefficient = 0f;
                    break;
                }

                reelCoefficient += coefficients[reels[s, r]];
            }

            coefficient += reelCoefficient;
        }

        return coefficient * stake;
    }
}