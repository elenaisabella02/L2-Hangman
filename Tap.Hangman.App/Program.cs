// See https://aka.ms/new-console-template for more information

using Tap.Hangman.App;

var hangmanGame = new HangmanGame();

Console.WriteLine("---Hangman game---");
Console.WriteLine("Enjoy the game!");
Console.WriteLine();
Console.WriteLine("Your word:");
Console.WriteLine(hangmanGame.CurrentWord);

while (hangmanGame.GameState == GameState.InProgress)
{
    Console.WriteLine($"Lives left: {hangmanGame.RemainingLives}");

    Console.WriteLine("Your next letter is?");
    var letterInput = Console.ReadKey().KeyChar;
    hangmanGame.ApplyLetter(letterInput);

    Console.WriteLine();
    Console.WriteLine("Your word:");
    Console.WriteLine(hangmanGame.CurrentWord);
}
Console.WriteLine();
if (hangmanGame.GameState == GameState.Lost)
{
    Console.WriteLine("You lost! :(");
}

if (hangmanGame.GameState == GameState.Won)
{
    Console.WriteLine("You won! :)");
}