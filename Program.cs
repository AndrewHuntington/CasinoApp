namespace CasinoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            double odds = 0.75;
            Guy player = new() { Name = "The player", Cash = 100 };

            Console.WriteLine("Welcome to the casino. The odds are " + odds);

            while (true)
            {
                player.WriteMyInfo();
                Console.Write("How much do you want to bet: ");
                string howMuch = Console.ReadLine();

                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    double roll = random.NextDouble();
                    if (roll > odds)
                    {
                        player.ReceiveCash(pot);
                        Console.WriteLine("You win " + pot);
                    } else
                    {
                        Console.WriteLine("Bad luck, you lose.");
                    }

                    if (player.Cash <= 0)
                    {
                        Console.WriteLine("The house always wins.");
                        return;
                    }
                }
            }

        }
    }
}
