using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random random = new Random();
        bool playAgain = true;
    
        while(playAgain)
    {
        int magicNumber = random.Next(1, 101);
        int guess = 0;
        int attempts = 0;

        Console.WriteLine("I have chosen a magic number between 1 and 100. Try to guess it?");
        while(guess != magicNumber)
        {
            Console.Write("What is your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if(guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine($"Congratulations! You guessed it! Yhe magic number in {attempts} attempts.");
            }
        }
        Console.Write("Do you want to play again? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        playAgain = response == "yes";
    }
    Console.WriteLine("Thank you for playing the game. Goodbye! Att. Diogo Rangel");
    }
}