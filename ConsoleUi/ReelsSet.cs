namespace Bede.SlotMachine.ConsoleUi;

public class ReelsSet
{
    private readonly IConfigurationManager _configurationManager;

    private readonly Random _random;

    private readonly Dictionary<string, int[]> _probabilityRanges;

    public ReelsSet(IConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;

        //TODO: Use cryptographic random number generator
        _random = new Random();

        _probabilityRanges = new Dictionary<string, int[]>();
    }

    public void Init()
    {
        var toPercentage = 0;

        foreach (var (symbol, percentage) in _configurationManager.GetProbabilityPercentages())
        {
            int fromPercentage = toPercentage;
            toPercentage += percentage;
            _probabilityRanges.Add(symbol, new[] { fromPercentage, toPercentage - 1 });
        }
    }

    public string[,] Spin()
    {
        if (!_probabilityRanges.Any())
        {
            throw new UninitializedReelsSetException();
        }

        var reels = new string[MachineConstants.SymbolsPerReel, MachineConstants.ReelsCount];

        for (int r = 0; r < MachineConstants.ReelsCount; r++)
        {
            for (int s = 0; s < MachineConstants.SymbolsPerReel; s++)
            {
                reels[s, r] = GetNextSymbol();
            }
        }

        return reels;
    }

    private string GetNextSymbol()
    {
        // I assume that configuration is valid and the sum of all percentages is 100.
        var randomInt = _random.NextInt64(100);

        foreach (var (symbol, range) in _probabilityRanges)
        {
            if (range[0] <= randomInt && randomInt <= range[1])
            {
                return symbol;
            }
        }

        throw new RandomSymbolException();
    }
}