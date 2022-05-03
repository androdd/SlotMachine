namespace Bede.SlotMachine.ConsoleUi;

internal class Program
{
    static void Main(string[] args)
    {
        IConfigurationManager configurationManager = new ConfigurationManager();
        Wallet wallet = new Wallet();
        ReelsSet reelsSet = new ReelsSet(configurationManager);
        WinCalculator winCalculator = new WinCalculator(configurationManager);

        reelsSet.Init();

        Console.WriteLine("Please deposit money you would like to play with:");
        var depositString = Console.ReadLine();
        if (!float.TryParse(depositString, out float deposit) || deposit <= 0)
        {
            Console.WriteLine("Invalid deposit. Try again later.");
            return;
        }

        wallet.Deposit(deposit);

        Console.WriteLine("Enter stake amount:");
        var stakeString = Console.ReadLine();
        if (!float.TryParse(stakeString, out float stake) || stake <= 0 || stake > wallet.Balance)
        {
            Console.WriteLine("Invalid stake. Try again later.");
            return;
        }
        
        wallet.Withdraw(stake);

        Console.WriteLine();

        var reels = reelsSet.Spin();

        for (int r = 0; r < MachineConstants.ReelsCount; r++)
        {
            for (int s = 0; s < MachineConstants.SymbolsPerReel; s++)
            {
                Console.Write(reels[s, r]);
            }

            Console.WriteLine();
        }

        var win = winCalculator.GetAmount(reels, stake);
        wallet.Deposit(win);

        Console.WriteLine();
        Console.WriteLine($"You have won: {win:F}");
        Console.WriteLine($"Current balance is: {wallet.Balance:F}");
    }
}

