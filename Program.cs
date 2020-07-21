using System;
using System.Collections;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "sdgthn";
            input = input.ToLower();
            string pigLatin = "";
            int firstvowel = 0;
            //Console.WriteLine($"The first vowel is at position {firstvowel}");
            //string almostPigLatin = MoveConsonants(input, firstvowel);
            //Console.WriteLine($"The first step in converting a word to pig latin is: {almostPigLatin}");

            firstvowel = CheckVowel(input);
            if (firstvowel == 0) // Is there a vowel or is the firt letter a vowel if so first vowel will be 0
            {
                pigLatin = AddWay(input);
            }
            else // If the word starts with a consonant firstvowel will not be 0
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

            // Putting all the letters first vowel till the end into the queue letters including the first vowel
            for (int i=vowelPosition; i < word.Length; i++)
            {
                letters.Enqueue(word[i]);
            }
            // Putting all the letters before the first vowel into the queue letters
            for(int i = 0; i < vowelPosition; i++)
            {
                letters.Enqueue(word[i]);
            }
            // Pulling all the letters out of the queue to make the new string
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

            //Loop looking for first 'y' in case thier are no vowels
            for (int i = 0; i < length; i++)
            {
                if (word[i] == 'y')
                {
                    yPosition = i;
                    break;
                }
            }

            // Return logic 
            // returning first vowel index
            // returning first 'y' index if no vowels
            // returning 0 if no vowels or y 
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
