namespace Tap.Hangman.App
{
    internal class HangmanGame
    {
        private string word;
        private SortedSet<char> matchedCharacters;
        private char[] wordState;

        public HangmanGame()
        {
            word = "computer";
            RemainingLives = 5;
            matchedCharacters = new SortedSet<char>();
            wordState = word.ToCharArray();
            ClearWordState();
        }

        public int RemainingLives { get; set; }

        public GameState GameState
        {
            get
            {
                if (RemainingLives == 0)
                {
                    return GameState.Lost;
                }
                if (!wordState.Contains('_'))
                {
                    return GameState.Won;
                }
                return GameState.InProgress;
            }
        }

        public string CurrentWord => new string(wordState);

        public void ApplyLetter(char letter)
        {
            if (RemainingLives == 0 || matchedCharacters.Contains(letter))
            {
                return;
            }

            char[] wordLetters = word.ToCharArray();

            AdjustGameStateBasedOnLetter(letter, wordLetters);
        }

        private void AdjustGameStateBasedOnLetter(char letter, char[] wordLetters)
        {
            var foundLetter = false;
            for (int i = 0; i < wordLetters.Length; i++)
            {
                char wordLetter = wordLetters[i];
                if (wordLetter == letter)
                {
                    wordState[i] = letter;
                }
            }

            if (foundLetter == false)
            {
                RemainingLives--;
            }
        }

        private void ClearWordState()
        {
            for (int i = 0; i < wordState.Length; i++)
            {
                wordState[i] = '_';
            }
        }
    }
}
