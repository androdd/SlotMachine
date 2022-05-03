namespace Bede.SlotMachine.ConsoleUi;

using Bede.SlotMachine.Common;
using Bede.SlotMachine.Common.Extensions;
using Bede.SlotMachine.Common.Interfaces;
using Bede.SlotMachine.Services;

internal class Program
{
    static void Main()
    {
        IConfigurationManager configurationManager = new ConfigurationManager();
        IWallet wallet = new Wallet();
        IReelsSet reelsSet = new ReelsSet(configurationManager);
        IWinCalculator winCalculator = new WinCalculator(configurationManager);
        
        reelsSet.Init();

        Game game = new(wallet, reelsSet, winCalculator);

        game.Play();
    }
}

public class Game
{
    private readonly IWallet _wallet;
    private readonly IReelsSet _reelsSet;
    private readonly IWinCalculator _winCalculator;

    public Game(IWallet wallet, IReelsSet reelsSet, IWinCalculator winCalculator)
    {
        wallet.NotNullArgument(nameof(wallet));
        reelsSet.NotNullArgument(nameof(reelsSet));
        winCalculator.NotNullArgument(nameof(winCalculator));

        _wallet = wallet;
        _reelsSet = reelsSet;
        _winCalculator = winCalculator;
    }

    public void Play()
    {
        Console.WriteLine("Please deposit money you would like to play with:");
        var depositString = Console.ReadLine();

        // Invalid deposit amount ends the game
        // TODO: Loop validation until correct amount is entered
        if (!float.TryParse(depositString, out float deposit) || deposit <= 0)
        {
            Console.WriteLine("Invalid deposit. Try again later.");
            return;
        }

        _wallet.Deposit(deposit);

        while (_wallet.Balance > 0)
        {
            Console.WriteLine("Enter stake amount:");
            var stakeString = Console.ReadLine();

            // Invalid stake amount ends the game
            // TODO: Loop validation until correct amount is entered
            if (!float.TryParse(stakeString, out float stake) || stake <= 0 || stake > _wallet.Balance)
            {
                Console.WriteLine("Invalid stake. Try again later.");
                return;
            }

            _wallet.Withdraw(stake);

            Console.WriteLine();

            var reels = _reelsSet.Spin();

            for (int r = 0; r < MachineConstants.ReelsCount; r++)
            {
                for (int s = 0; s < MachineConstants.SymbolsPerReel; s++)
                {
                    Console.Write(reels[s, r]);
                }

                Console.WriteLine();
            }

            var win = _winCalculator.GetAmount(reels, stake);
            _wallet.Deposit(win);

            Console.WriteLine();
            Console.WriteLine($"You have won: {win:F}");
            Console.WriteLine($"Current balance is: {_wallet.Balance:F}");

            Console.WriteLine();
            Console.WriteLine("Press any key for next stake...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

