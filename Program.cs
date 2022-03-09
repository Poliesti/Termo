// See https://aka.ms/new-console-template for more information

using System;

int wordSize = 5, nonletterCount = 0, position, blueletterCount, yellowletterCount;

char letter; 

char[] word = {'*', '*', '*', '*', '*'};
char[] emptyWord = {'*', '*', '*', '*', '*'};
char[] yellowLetters = new char[5];
char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',};

Console.Write("How many letters are blue: ");
blueletterCount = Convert.ToInt32(Console.ReadLine());

if (blueletterCount != 0)
{
    for (int i = 0; i < blueletterCount; i++)
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
yellowletterCount = Convert.ToInt32(Console.ReadLine());

if (yellowletterCount != 0)
{
    for (int i = 0; i < yellowletterCount; i++)
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

static string[] BlueFilter(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount, char[] emptyWord)
{
    string[] bluefilteredWord = new string[possibleWords.Count()];

    static string[] FourRightLetters(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
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

    static string[] ThreeRightLetters(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
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

        return FourRightLetters(word, possibleWords, alphabet, nonletterCount);
    }

    static string[] TwoRightLetters(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
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

        return ThreeRightLetters(word, possibleWords, alphabet, nonletterCount);
    }

    static string[] OneRightLetter(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
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

        return TwoRightLetters(word, possibleWords, alphabet, nonletterCount);
    }

    static string[] NoRightLetters(char[] word, string[] possibleWords, char[] alphabet, int nonletterCount)
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

        return OneRightLetter(word, possibleWords, alphabet, nonletterCount);
    }

    switch (nonletterCount)
    {
        case 1:
            bluefilteredWord = FourRightLetters(emptyWord, possibleWords, alphabet, nonletterCount);
        break;

        case 2:
            bluefilteredWord = ThreeRightLetters(emptyWord, possibleWords, alphabet, nonletterCount);
        break;

        case 3:
            bluefilteredWord = TwoRightLetters(emptyWord, possibleWords, alphabet, nonletterCount);
        break;

        case 4:
            bluefilteredWord = OneRightLetter(emptyWord, possibleWords, alphabet, nonletterCount);
        break;

        case 5:
            bluefilteredWord = NoRightLetters(emptyWord, possibleWords, alphabet, nonletterCount);
        break;

        default:
            Console.WriteLine("Value didn't match earlier.");
        break;
}

    return bluefilteredWord;
}

if (blueletterCount < 5)
{
    possibleWords = BlueFilter(word, possibleWords, alphabet, nonletterCount, emptyWord);
}

if (yellowletterCount != 0)
{
    YellowFilter(possibleWords, yellowLetters, yellowletterCount);
}

static string[] YellowFilter(string[] possibleWords, char[] yellowLetters, int yellowletterCount)
{
    string[] yellowfilteredWords = new string[possibleWords.Count()]; 

    int k = 0, l = -1;

    for (int i = 0; i < possibleWords.Count(); i++)
    {
        k = 0;

        for (int j = 0; j < yellowLetters.Count(); j++)
        {
           if (possibleWords[i].Contains(yellowLetters[j]))
            {
                k++;
            }
        }

        if (k == yellowletterCount)
        {
            l++;

            yellowfilteredWords[l] = possibleWords[i];

            Console.WriteLine(yellowfilteredWords[l]);
        }
    }

    return yellowfilteredWords;
}

Console.WriteLine(probabillityCheck(alphabet, nonletterCount));
Console.ReadLine();

