namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            HangmanGame hangman = new HangmanGame();
            List<string> words = new List<string>();
            words = ListOfWords();
            hangman.Init(SelectWord(words));
            DisplayWord(hangman.guessedWord);
            bool victory = PlayHangman(hangman);
            if (victory)
                Console.WriteLine("You guessed the word!");
            else
                Console.WriteLine($"Too bad, you did not guess the word ({hangman.secretWord})");
        }
        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = 8;

            while (attempts != 0)
            {
                char letter = ReadLetter(enteredLetters);
                enteredLetters.Add(letter);
                DisplayLetters(enteredLetters);
                if (hangman.ContainsLetter(letter))
                {
                    hangman.ProcessLetter(letter);
                }
                else
                    attempts--;
                Console.WriteLine($"Attempts left: {attempts}");
                Console.WriteLine();
                DisplayWord(hangman.guessedWord);
                if (hangman.IsGuessed())
                {
                    return true;
                }
            }
            return false;
        }
        List<String> ListOfWords()
        {
            List<string> secretWords = new List<string>();
            secretWords.Add("airplane");
            secretWords.Add("kitchen");
            secretWords.Add("building");
            secretWords.Add("incredible");
            secretWords.Add("funny");
            secretWords.Add("trainstation");
            secretWords.Add("neighbour");
            secretWords.Add("different");
            secretWords.Add("department");
            secretWords.Add("planet");
            secretWords.Add("presentation");
            secretWords.Add("embarrassment");
            secretWords.Add("integration");
            secretWords.Add("scenario");
            secretWords.Add("discount");
            secretWords.Add("management");
            secretWords.Add("understanding");
            secretWords.Add("registration");
            secretWords.Add("security");
            secretWords.Add("language");
            return secretWords;
        }
        string SelectWord(List<string> words)
        {
            Random random = new Random();
            return words[random.Next(0, 20)];
        }
        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }
        char ReadLetter(List<char> blacklistLetters)
        {
            char letter;
            do
            {
                Console.Write("Enter a letter: ");
                letter = Convert.ToChar(Console.ReadLine());
            }
            while(blacklistLetters.Contains(letter));
            return letter;
        }
        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }
    }
}
