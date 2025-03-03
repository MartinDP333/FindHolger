/*
Find Holger

Der skal laves et program der kan udskrive 40 rækker med 40 tilfældige bogstaver i hver række

Ét af bogstaverne skal erstattes med et @

Spillet handler om at finde @’et 
*/

Random random = new Random();
string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

while (true)
{

    int xRow = random.Next(1, 41);
    int zRow = random.Next(1, 41);

    int difficultyNumber = DifficultyNumber();

    Console.Clear();
    Console.Write("*  ");
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 1; i <= 40; i++)
    {
        if (i < 10)
        {
            Console.Write(i + "  ");
        }
        else
        {
            Console.Write(i + " ");
        }
    }
    Console.WriteLine("X -->");
    for (int i = 1; i <= 40; i++)
    {
        Console.ForegroundColor = ConsoleColor.White;
        if (i < 10)
        {
            Console.Write(i + "  ");
        }
        else
        {
            Console.Write(i + " ");
        }
        for (int j = 1; j <= 40; j++)
        {
            if (difficultyNumber >= 2)
            {
                LetterColor();
            }
            if (i == zRow && j == xRow)
            {
                if (difficultyNumber >= 3)
                {
                    LetterColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("@  ");
                Console.ResetColor();
            }
            else
            {
                char randomChar = letters[random.Next(letters.Length)];
                Console.Write(randomChar + "  ");
            }
        }
        Console.WriteLine();
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Z\n|\n|\nv");

    Console.WriteLine("Guess coordinate");
    Console.WriteLine("Guess X coordinate");
    string inputXAsString = Console.ReadLine();
    Console.WriteLine("Guess Z coordinate");
    string inputZAsString = Console.ReadLine();
    int X = Convert.ToInt32(inputXAsString);
    int Z = Convert.ToInt32(inputZAsString);

    if (X == xRow && Z == zRow)
    {
        Console.Clear();
        Console.WriteLine("You win!!!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("You lose");
        Console.WriteLine("The correct coordinate was at: ");
        Console.WriteLine("X: " + xRow + " Z:" + zRow);
    }
    Console.WriteLine("New game?");
    Console.WriteLine("Type 0 to exit, any key to continue");
    string playAgain = Console.ReadLine();
    PlayAgain(playAgain);
}

static void LetterColor() {
    Random random = new Random();
    int numberColor = random.Next(1, 8);
    switch (numberColor)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Green;
            break;
        case 4:
            Console.ForegroundColor = ConsoleColor.Magenta;
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.Cyan;
            break;
        case 6:
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case 7:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}

static bool PlayAgain(string playAgain)
{
    switch (playAgain)
    {
        case "0":
            return false;
        default:
            return true;
    }
}

static int DifficultyNumber()
{
    Console.WriteLine("Choose difficulty:");
    Console.WriteLine("Type 1 for easy");
    Console.WriteLine("Type 2 for medium");
    Console.WriteLine("Type 3 for hard");
    string difficultyNumberAsString = Console.ReadLine();
    int difficultyNumber = Convert.ToInt32(difficultyNumberAsString);
    return difficultyNumber;
}