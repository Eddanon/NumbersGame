namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Edvard B.
            // NET26
            // 2026-09-20
            // Lab 2: Gissa Numret

            // This loop exist so that the player can continue playing several rounds
            while (true)
            {
                // Generate a random number between 1 and 20
                Random random = new Random();
                int randomNumber = random.Next(1, 21);

                // Greet the user
                string greeting = "Välkommen! Jag tänker på ett nummer mellan 1-20. Kan du gissa vilket? Du får fem försök.";
                Console.WriteLine(greeting);

                // Set the start values
                int guessCounter = 0;
                int numberGuess = 0;

                // End this loop when guessCounter is at 5
                while (guessCounter <= 4)
                {
                    // The user gets to guess
                    string userInput = Console.ReadLine() ?? "";

                    if (!string.IsNullOrWhiteSpace(userInput))
                    {
                        // If userInput is an integer, set numberGuess to the int value
                        if (int.TryParse(userInput, out numberGuess))
                        {
                            // Send the parameters to the method
                            CheckGuess(numberGuess, randomNumber);

                            // Exit the loop if right answer
                            if (numberGuess == randomNumber)
                            {
                                break;
                            }
                            else
                            {
                                // Add one round to the counter and go to next round
                                guessCounter += 1;
                                continue;
                            }
                        }
                        // If userInput is not an integer, ask again
                        else
                        {
                            Console.WriteLine("Skriv in ett heltal.");
                            continue;
                        }
                    }
                    // If user pressed Enter without entering anything, ask again
                    else
                    {
                        Console.WriteLine("Skriv in ett heltal.");
                        continue;
                    }
                }

                // If user guessed 5 times and didn't get the right answer
                if (guessCounter >= 5 && numberGuess != randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                }

                // Define variable to make it exist in the loop and if statement below
                string playAgain;

                while (true) // Ask the user if he wants to play again until he answers yes or no
                {
                    Console.WriteLine("Vill du spela igen? (ja/nej)");
                    playAgain = Console.ReadLine() ?? "";
                    playAgain = playAgain.ToLower(); // Make input lowercase

                    if (playAgain == "ja")
                    {
                        Console.WriteLine("Nästa runda startar...");
                        break;
                    }
                    else if (playAgain == "nej")
                    {
                        Console.WriteLine("Spelet avslutas...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Svara ja/nej");
                        continue;
                    }

                }

                // Exit or restart the game depending on the answer
                if (playAgain == "ja")
                {
                    continue;
                }
                else if (playAgain == "nej")
                {
                    break;
                }

            }

        }

        // Method that checks the user's guess
        public static void CheckGuess(int userNumber, int randomNumber)
        {
            // Two arrays with different answers to give
            string[] guessTooLow = ["Tyvärr, du gissade för lågt!", "Haha! Det var för lågt!", "Gissa högre nästa gång!", "Det är högre än så."];
            string[] guessTooHigh = ["Tyvärr, du gissade för högt!", "Haha! Det var för högt!", "Gissa lägre nästa gång!", "Det är lägre än så."];

            Random random = new Random();

            // Generate a random number to represent an index in guessTooLow
            // This works for guessTooHigh too
            int answerChooser = random.Next(guessTooLow.Length);

            if (userNumber < randomNumber)
            {
                Console.WriteLine(guessTooLow[answerChooser]);
            }
            else if (userNumber > randomNumber)
            {
                Console.WriteLine(guessTooHigh[answerChooser]);
            }
            // If the number is correct
            else
            {
                Console.WriteLine("Wohoo! Du klarade det!");
            }

        }

    }
}
