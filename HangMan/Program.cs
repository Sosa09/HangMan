namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //initializing an instance of Random to randomly pick up a work from List _words
            Random random = new Random();

            const char LETTER_NOT_FOUND_CHARACTER = '_';
            const int TOTAL_CHANCES = 10;
            const char EMPTY_CHAR_CHECK = '\0';

            //initialize an instance of collection List that holds strings
            List<string> words = new List<string>
            {
                "rakete",
                "menotring",
                "boolean",
                "training",
                "hangman",
                "hardwork",
                "success"
            };
            
            //starting game loop tht will keep running as long as the word is not found
            while (true)
            {

                //pick up a word from the list randomly
                string pickUpWord = words[random.Next(0, words.Count)];

                //initialzing userFoundChars array that will hold the chars that the end user has found
                char[] userFoundChars = new char[pickUpWord.Length];
                int charFoundCount = 0;
                int nrOfGuesses = 0;
                bool isWordFound = false;
                bool maxAttemptsReached = false;


                while(!isWordFound && !maxAttemptsReached)
                {
                    Console.Clear();
                    Console.WriteLine($"Attempts:    {nrOfGuesses}");
                    Console.Write("FOUND:\t\t\t");

                    //Update the console to display the evolution
                    foreach (char letter in userFoundChars)
                    {
                        if (letter != EMPTY_CHAR_CHECK)
                            Console.Write($"{letter} ");
                        else
                            Console.Write($"{LETTER_NOT_FOUND_CHARACTER} ");
                    }

                    Console.WriteLine("\n\nPLEASE ENTER A LETTER: ");

                    //Ask user to enter a character
                    char userInput = Console.ReadKey().KeyChar;


                    //looping through the random word to check if userinput matches any char of the word
                    for(int i = 0; i < pickUpWord.Length; i++)
                    {

                        if (pickUpWord[i] == userInput)
                        {
                            //Checking if a letter has already been placed at the index where a match was found (for words where letters appears twice or more)
                            userFoundChars[i] = userInput;
                            charFoundCount++;
                        }
              
                            
                    }

                    //Comparing the length of the Random word and User Guess if they are equal user has won
                    if (charFoundCount == pickUpWord.Length)
                    {
                 
                        Console.WriteLine($"Great you found the word {pickUpWord} after {nrOfGuesses} guesses.");
                        isWordFound = true; //HELP after updating the value from false to true the while loop still executes

                    }
                    else if(nrOfGuesses == TOTAL_CHANCES)
                    {
                        Console.WriteLine($"Oooh you lost {TOTAL_CHANCES} reached, the word was {pickUpWord}.");
                        maxAttemptsReached = true; //HELP after updating the value from false to true the while loop still executes
                        
                    }
                    nrOfGuesses++;
                    
                }

                Console.WriteLine("\n\npress any key to continue... ");
                Console.ReadKey();

            }
        }
    }
}