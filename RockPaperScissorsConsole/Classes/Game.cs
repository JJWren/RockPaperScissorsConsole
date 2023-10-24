namespace RockPaperScissorsConsole.Classes
{
    public class Game
    {
        public int UserScore { get; set; } = 0;
        public int ComputerScore { get; set; } = 0;
        public int NumberOfTies { get; set; } = 0;
        public string UserSelection { get; set; } = string.Empty;
        public string ComputerSelection { get; set; } = string.Empty;

        public void Run()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\n");

            int userSelection = GetUserSelection();
            int computerSelection = GenerateComputerSelection();
            CompareSelections(UserSelection, ComputerSelection);

            PlayAgain();
        }

        public int GetUserSelection()
        {
            Console.WriteLine($"1. {Constants.Selection.Rock}\n2. {Constants.Selection.Paper}\n3. {Constants.Selection.Scissors}\nType the number of your selection from the three choices above:\n");
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
            int userSelection;
            bool success = int.TryParse(input, out userSelection);

            if (!success)
            {
                return 0;
            }

            if (userSelection < 1 || userSelection > 3)
            {
                return 0;
            }

            return userSelection;
        }

        public static int GenerateComputerSelection()
        {
            Random random = new();
            return random.Next(1, 4);
        }

        public static string ConvertSelection(int selection)
        {
            if (selection == 1)
            {
                return Constants.Selection.Rock.ToString();
            }
            else if (selection == 2)
            {
                return Constants.Selection.Paper.ToString();
            }
            else
            {
                return Constants.Selection.Scissors.ToString();
            }
        }

        public void CompareSelections(int userSelection, int computerSelection)
        {
            // Print Selections
            Console.WriteLine($"\nYour selection: {ConvertSelection(userSelection)}");
            Console.WriteLine($"Computer's selection: {ConvertSelection(computerSelection)}");

            // Ties
            if (userSelection == computerSelection)
            {
                Console.WriteLine("It's tie!");
                NumberOfTies += 1;
            }
            // User Wins
            else if ((userSelection == 1 && computerSelection == 3)     // rock 🪨 vs scissors ✂
                || (userSelection == 2 && computerSelection == 1)       // paper 📄 vs rock 🪨
                || (userSelection == 3 && computerSelection == 2))      // scissors ✂ vs paper 📄
            {
                Console.WriteLine("You win!");
                UserScore += 1;
            }
            // Computer Wins
            else
            {
                Console.WriteLine("You lose!");
                ComputerScore += 1;
            }

            // Print Scores
            Console.WriteLine("\n## SCOREBOARD ##");
            Console.WriteLine($"You: {UserScore}\tComputer: {ComputerScore}\t Ties: {NumberOfTies}");
        }

        public void PlayAgain()
        {
            Console.WriteLine("\nWould you like to play again? (Type \"Y\" or \"y\" if yes, anything else is no): ");
            string yesOrNo = Console.ReadLine()!.ToUpper();

            if (yesOrNo == "Y")
            {
                Console.WriteLine("");
                Run();
            }
            else
            {
                Console.WriteLine("\nGoodbye!");
            }
        }
    }
}
