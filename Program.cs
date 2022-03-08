// See https://aka.ms/new-console-template for more information

using System;

int wordSize = 5, nonletterCount = 0, position, blueLetter, yellowLetter;

char letter; 

char[] word = {'*', '*', '*', '*', '*'};
char[] emptyWord = {'*', '*', '*', '*', '*'};
char[] wordwithYellow = {'*', '*', '*', '*', '*'};
char[] yellowLetters = new char[5];
char[] vogals = {'a', 'e', 'i', 'o', 'u'};
char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',};

Console.Write("How many letters are blue: ");
blueLetter = Convert.ToInt32(Console.ReadLine());

if (blueLetter != 0)
{
    for (int i = 0; i < blueLetter; i++)
    {
        Console.Write("Select the letter: ");
        letter = Convert.ToChar(Console.ReadLine());
        Console.Write("Select the letter position: ");
        position = Convert.ToInt32(Console.ReadLine());
        position--;

        word[position] = letter;
    }
}

Console.Write("How many letters are yellow: ");
yellowLetter = Convert.ToInt32(Console.ReadLine());

if (yellowLetter != 0)
{
    for (int i = 0; i < yellowLetter; i++)
    {
        Console.Write("Select the letter: ");
        letter = Convert.ToChar(Console.ReadLine());

        yellowLetters[i] = letter;
    }
}

for (int i = 0; i < wordSize; i++)
{
    if (word[i] == '*')
    {
        nonletterCount++;
    }
}

static int probabillityCheck(char[] alphabet,int nonletterCount)
{
    int probability = 0;

    probability =  Convert.ToInt32(Math.Pow(alphabet.Count(), nonletterCount));

    return probability;
}

string[] possibleWords = new string[probabillityCheck(alphabet ,nonletterCount)];

for (int i = 0; i < probabillityCheck(alphabet, nonletterCount); i++)
{
    possibleWords[i] = new string(word);
}

static string[] OneStar(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
{
    int index;

        for (int i = 0; i < probabillityCheck(alphabet, nonletterCount); i++)
        {
            word = possibleWords[i].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % alphabet.Count()];

            possibleWords[i] = new string(word);
        }
    
    return possibleWords;
}

static string[] TwoStar(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
{
    int index, startPosition;

    for (int i = 0; i < probabillityCheck(alphabet, nonletterCount - 1); i++)
    {
        for (int j = 0; j < alphabet.Count(); j++)
        {
            startPosition = (alphabet.Count() * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % alphabet.Count()];

            possibleWords[startPosition] = new string(word);
        }
    }

    return OneStar(word, possibleWords, alphabet, nonletterCount);
}

static string[] ThreeStar(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
{
    int index, startPosition;

    for (int i = 0; i < probabillityCheck(alphabet, nonletterCount - 2); i++)
    {
        for (int j = 0; j < Math.Pow(alphabet.Count(), 2); j++)
        {
            startPosition = Convert.ToInt32(Math.Pow(alphabet.Count(), 2) * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % alphabet.Count()];

            possibleWords[startPosition] = new string(word);
        }
    }

    return TwoStar(word, possibleWords, alphabet, nonletterCount);
}

static string[] FourStar(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
{
    int index, startPosition;

    for (int i = 0; i < probabillityCheck(alphabet, nonletterCount - 3); i++)
    {
        for (int j = 0; j < Math.Pow(alphabet.Count(), 3); j++)
        {
            startPosition = Convert.ToInt32(Math.Pow(alphabet.Count(), 3) * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % alphabet.Count()];

            possibleWords[startPosition] = new string(word);
        }
    }

    return ThreeStar(word, possibleWords, alphabet, nonletterCount);
}

static string[] FiveStar(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
{
    int index, startPosition;

    for (int i = 0; i < probabillityCheck(alphabet, nonletterCount - 4); i++)
    {
        for (int j = 0; j < Math.Pow(alphabet.Count(), 4); j++)
        {
            startPosition = Convert.ToInt32(Math.Pow(alphabet.Count(), 4) * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % alphabet.Count()];

            possibleWords[startPosition] = new string(word);
        }
    }

    return FourStar(word, possibleWords, alphabet, nonletterCount);
}

switch (nonletterCount)
{
    case 1:
        OneStar(emptyWord, possibleWords, alphabet, nonletterCount);
    break;

    case 2:
        TwoStar(emptyWord, possibleWords, alphabet, nonletterCount);
    break;

    case 3:
        ThreeStar(emptyWord, possibleWords, alphabet, nonletterCount);
    break;

    case 4:
        FourStar(emptyWord, possibleWords, alphabet, nonletterCount);
    break;

    case 5:
        FiveStar(emptyWord, possibleWords, alphabet, nonletterCount);
    break;

    default:
        Console.WriteLine("Value didn't match earlier.");
    break;
}

for (int i = 0; i < probabillityCheck(alphabet, nonletterCount); i++)
{
    Console.WriteLine(possibleWords[i]);
}

Console.WriteLine(probabillityCheck(alphabet, nonletterCount));
Console.ReadLine();