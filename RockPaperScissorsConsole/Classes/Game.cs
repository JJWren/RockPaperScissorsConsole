using RockPaperScissorsConsole.Classes.CustomExtensions;

namespace RockPaperScissorsConsole.Classes
{
    public class Game
    {
        public int UserScore { get; set; } = 0;
        public int ComputerScore { get; set; } = 0;
        public int NumberOfTies { get; set; } = 0;
        public int UserSelection { get; set; } = 0;
        public int ComputerSelection { get; set; } = 0;

        public void Run()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!".ToBannerString());

            UserSelection = GetUserSelection();
            ComputerSelection = GenerateComputerSelection();
            CompareSelections();

            PlayAgain();
        }

        public int GetUserSelection()
        {
            Console.WriteLine($"1. {Constants.Selection.Rock}" +
                $"\n2. {Constants.Selection.Paper}" +
                $"\n3. {Constants.Selection.Scissors}" +
                $"\nType the number of your selection from the three choices above:\n");
            string input = Console.ReadLine()!;

            int parsedInput = CheckUserSelectionIsValid(input);
            if (parsedInput == 0)
            {
                Console.WriteLine($"\"{input}\" is not a valid selection, please try again.\n");
                GetUserSelection();
            }
            return parsedInput;
        }

        public static int CheckUserSelectionIsValid(string input)
        {
            bool success = int.TryParse(input, out int UserSelection);

            if (!success)
            {
                return 0;
            }

            if (UserSelection < 1 || UserSelection > 3)
            {
                return 0;
            }

            return UserSelection;
        }

        public static int GenerateComputerSelection()
        {
            Random random = new();
            return random.Next(1, 4);
        }

        public static string ConvertSelection(int selection)
        {
            return ((Constants.Selection)selection).ToString();
        }

        public void CompareSelections()
        {
            // Print Selections
            Console.WriteLine($"\nYour selection: {ConvertSelection(UserSelection)}" +
                $"\nComputer's selection: {ConvertSelection(ComputerSelection)}\n");

            // Ties
            if (UserSelection == ComputerSelection)
            {
                Console.WriteLine("It's tie!\n");
                NumberOfTies += 1;
            }
            // User Wins
            else if ((UserSelection == 1 && ComputerSelection == 3)     // rock vs scissors
                || (UserSelection == 2 && ComputerSelection == 1)       // paper vs rock
                || (UserSelection == 3 && ComputerSelection == 2))      // scissors vs paper
            {
                Console.WriteLine("You win!\n");
                UserScore += 1;
            }
            // Computer Wins
            else
            {
                Console.WriteLine("You lose!\n");
                ComputerScore += 1;
            }

            // Print Scores
            Console.WriteLine("SCOREBOARD".ToBannerString());
            Console.WriteLine($"You: {UserScore}\tComputer: {ComputerScore}\t Ties: {NumberOfTies}");
        }

        public void PlayAgain()
        {
            Console.WriteLine("\nWould you like to play again? (Type \"Y\" or \"y\" if yes, anything else is no): ");
            string yesOrNo = Console.ReadLine()!.ToUpper();

            if (yesOrNo == "Y")
            {
                Console.WriteLine("");
                UserSelection = 0;
                ComputerSelection = 0;
                Run();
            }
            else
            {
                Console.WriteLine("\nGoodbye!");
                Environment.Exit(0);
            }
        }
    }
}
