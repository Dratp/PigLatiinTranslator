using System;
using System.Collections;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Greetings";
            input = input.ToLower();
            string pigLatin = "";

            int firstvowel = CheckVowel(input);
            //Console.WriteLine($"The first vowel is at position {firstvowel}");
            //string almostPigLatin = MoveConsonants(input, firstvowel);
            //Console.WriteLine($"The first step in converting a word to pig latin is: {almostPigLatin}");

            if (firstvowel == 0)
            {
                pigLatin = AddWay(input);
            }
            else
            {
                pigLatin = AddAy(MoveConsonants(input, firstvowel));
            }
            Console.WriteLine($"The word in PigLatin is {pigLatin}");

        }

        static string AddWay(string word)
        {
            word = word + "way";
            return word;
        }

        static string AddAy(string word)
        {
            word = word + "ay";
            return word;
        }

        static string MoveConsonants(string word, int vowelPosition)
        {
            string changedWord = "";
            Queue<char> letters = new Queue<char>();
            for (int i=vowelPosition; i < word.Length; i++)
            {
                letters.Enqueue(word[i]);
            }
            for(int i = 0; i < vowelPosition; i++)
            {
                letters.Enqueue(word[i]);
            }
            int queueSize = letters.Count;
            for (int i = 0; i < queueSize; i++)
            {
                string letter = letters.Dequeue().ToString();
                changedWord += letter;
            }
            return changedWord;
        }

        static int CheckVowel(string word)
        {
            int length = word.Length;
            int vowelPosition = 0;
            int yPosition = 0;
            
            //Loop looking for first Vowel
            for (int i =0; i<length; i++)
            {
                if(word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    vowelPosition = i;
                    break;
                }
            }

            //Loop looking for first 'Y'
            for (int i = 0; i < length; i++)
            {
                if (word[i] == 'y')
                {
                    yPosition = i;
                    break;
                }
            }

            if (vowelPosition == 0)
            {
                return yPosition;
            }
            else
            {
                return vowelPosition;
            }

        }

    }
}
