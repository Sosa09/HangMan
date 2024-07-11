namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //initializing an instance of Random to randomly pick up a work from List _words
            Random _random = new Random();

            const char LETTER_NOT_FOUND_CHARACTER = '_';
            const int TOTAL_CHANCES = 10;
            const char EMPTY_CHAR_CHECK = '\0';

            //initialize an instance of collection List that holds strings
            List<string> _words = new List<string>
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
                string _pickUpWord = _words[_random.Next(0, _words.Count)];

                //initialzing userFoundChars array that will hold the chars that the end user has found
                char[] _userFoundChars = new char[_pickUpWord.Length];
                int _charFoundCount = 0;
                int _nrOfGuesses = 0;
                bool _isWordFound = false;
                bool _maxAttemptsReached = false;


                while(!_isWordFound || !_maxAttemptsReached)
                {
                    Console.Clear();
                    Console.WriteLine($"Attempts:    {_nrOfGuesses}");
                    Console.Write("FOUND:\t\t\t");

                    //Update the console to display the evolution
                    foreach (char letter in _userFoundChars)
                    {
                        if (letter != EMPTY_CHAR_CHECK)
                            Console.Write($"{letter} ");
                        else
                            Console.Write($"{LETTER_NOT_FOUND_CHARACTER} ");
                    }

                    Console.WriteLine("\n\nPLEASE ENTER A LETTER: ");

                    //Ask user to enter a character
                    char _userInput = Console.ReadKey().KeyChar;


                    //looping through the random word to check if userinput matches any char of the word
                    for(int i = 0; i < _pickUpWord.Length; i++)
                    {
                        if (_pickUpWord[i] == _userInput)
                            //Checking if a letter has already been placed at the index where a match was found (for words where letters appears twice or more)
                            if (_userFoundChars[i] == EMPTY_CHAR_CHECK)
                            {
                                _userFoundChars[i] = _userInput;
                                _charFoundCount++;
                                break;
                            }
                    }

                    //Comparing the length of the Random word and User Guess if they are equal user has won
                    if (_charFoundCount == _pickUpWord.Length)
                    {
                 
                        Console.WriteLine($"Great you found the word {_pickUpWord} after {_nrOfGuesses} guesses.");
                        _isWordFound = true; //HELP after updating the value from false to true the while loop still executes

                    }
                    else if(_nrOfGuesses == TOTAL_CHANCES)
                    {
                        Console.WriteLine($"Oooh you lost {TOTAL_CHANCES} reached, the word was {_pickUpWord}.");
                        _maxAttemptsReached = true; //HELP after updating the value from false to true the while loop still executes
                        
                    }
                    _nrOfGuesses++;
                    
                }

                Console.WriteLine("\n\npress any key to continue... ");
                Console.ReadKey();

            }
        }
    }
}