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

static int probabillityCheck(int nonwordCount)
{
    int probability = 0;

    probability =  Convert.ToInt32(Math.Pow(26, nonwordCount));

    return probability;
}

string[] possibleWords = new string[probabillityCheck(nonletterCount)];

for (int i = 0; i < probabillityCheck(nonletterCount); i++)
{
    possibleWords[i] = new string(word);
}

static string[] OneStar(char[] word, string[] possibleWords, char[] alphabet)
{
    int index;

        for (int i = 0; i < 26; i++)
        {
            word = possibleWords[i].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i];

            possibleWords[i] = new string(word);
        }
    
    return possibleWords;
}

static string[] TwoStar(char[] word, string[] possibleWords, char[] alphabet)
{
    int index, startPosition;

    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            startPosition = (26 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 676; i++)
    {
        word = possibleWords[i].ToCharArray();

        index = Array.IndexOf(word, '*');

        word[index] = alphabet[i % 26];

        possibleWords[i] = new string(word);
    }

    return possibleWords;
}

static string[] ThreeStar(char[] word, string[] possibleWords, char[] alphabet)
{
    int index, startPosition;

    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 676; j++)
        {
            startPosition = (676 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 676; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            startPosition = (26 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 17576; i++)
    {
        word = possibleWords[i].ToCharArray();

        index = Array.IndexOf(word, '*');

        word[index] = alphabet[i % 26];

        possibleWords[i] = new string(word);
    }

    return possibleWords;
}

static string[] FourStar(char[] word, string[] possibleWords, char[] alphabet)
{
    int index, startPosition;

    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 17576; j++)
        {
            startPosition = (17576 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 676; i++)
    {
        for (int j = 0; j < 676; j++)
        {
            startPosition = (676 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 17576; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            startPosition = (26 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 456976; i++)
    {
        word = possibleWords[i].ToCharArray();

        index = Array.IndexOf(word, '*');

        word[index] = alphabet[i % 26];

        possibleWords[i] = new string(word);
    }

    return possibleWords;
}

static string[] FiveStar(char[] word, string[] possibleWords, char[] alphabet)
{
    int index, startPosition;

    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 456976; j++)
        {
            startPosition = (456976 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 676; i++)
    {
        for (int j = 0; j < 17576; j++)
        {
            startPosition = (17576 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 17576; i++)
    {
        for (int j = 0; j < 676; j++)
        {
            startPosition = (676 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 456976; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            startPosition = (26 * i) + j;

            word = possibleWords[startPosition].ToCharArray();

            index = Array.IndexOf(word, '*');

            word[index] = alphabet[i % 26];

            possibleWords[startPosition] = new string(word);
        }
    }

    for (int i = 0; i < 11881376; i++)
    {
        word = possibleWords[i].ToCharArray();

        index = Array.IndexOf(word, '*');

        word[index] = alphabet[i % 26];

        possibleWords[i] = new string(word);
    }

    return possibleWords;
}

switch (nonletterCount)
{
    case 1:
        OneStar(emptyWord, possibleWords, alphabet);
    break;

    case 2:
        TwoStar(emptyWord, possibleWords, alphabet);
    break;

    case 3:
        ThreeStar(emptyWord, possibleWords, alphabet);
    break;

    case 4:
        FourStar(emptyWord, possibleWords, alphabet);
    break;

    case 5:
        FiveStar(emptyWord, possibleWords, alphabet);
    break;

    default:
        Console.WriteLine("Value didn't match earlier.");
    break;
}

for (int i = 0; i < probabillityCheck(nonletterCount); i++)
{
    Console.WriteLine(possibleWords[i]);
}

Console.WriteLine(probabillityCheck(nonletterCount));
Console.ReadLine();