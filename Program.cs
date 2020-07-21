using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "sdgthn";
            //input = input.ToLower();
            string pigLatin = "";
            int firstvowel = 0;

            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.Write("\nEnter a line to be translated: ");
            input = Console.ReadLine().ToLower();
            string[] words = input.Split();

            for(int i = 0; i < words.Count(); i++)
            {
                string punctuation = CheckforPunctuation(words[i]); // Check for puncuation looks to see if there is puncuation and returns the puncuation if it exists else returns ""
                if (punctuation.Length > 0) 
                {
                    words[i] = RemoveEndChars(words[i], 1); // removing 1 char from the end of the word
                }
                if (IsItAWord(words[i]))
                {
                    firstvowel = CheckVowel(words[i]);
                    //Console.WriteLine($"The first vowel is at position {firstvowel}"); // Debugging Code
                    //string almostPigLatin = MoveConsonants(input, firstvowel); // Debugging Code
                    //Console.WriteLine($"The first step in converting a word to pig latin is: {almostPigLatin}"); // Debugging Code
                    if (firstvowel == 0) // Is there a vowel or is the firt letter a vowel if so first vowel will be 0
                    {
                        pigLatin = AddWay(words[i]);
                    }
                    else // If the word starts with a consonant firstvowel will not be 0
                    {
                        pigLatin = AddAy(MoveConsonants(words[i], firstvowel));
                    }
                    Console.Write($"{pigLatin + punctuation} ");
                }
                else
                {
                    Console.Write($"{words[i]} ");
                }
            }
            //Console.Write($"The word in PigLatin is {pigLatin}");
        }

        static string RemoveEndChars(string word, int amount)
        {
            int lastIndex = word.Length;
            int insertionPoint = lastIndex - amount;
            if (insertionPoint > 0)
            {
                word = word.Remove(insertionPoint, amount);
            }
            return word;
        }

        static string CheckforPunctuation(string word)
        {
            string punctuation = "";
            int lastCharIndex = word.Length -1;
            if (char.IsPunctuation(word[lastCharIndex]))
            {
                punctuation = word[lastCharIndex].ToString();
            }
            return punctuation;
        }

        static bool IsItAWord(string input)
        {
            bool validWord = false;
            for (int i=0; i<input.Length; i++)
            {
                validWord = char.IsLetter(input[i]);
                //Console.WriteLine($"{input[i]} is a letter {validWord}"); //Debugging Code
                if (validWord == false)
                {
                    break;
                }
            }
            if (input.Length == 0)
            {
                validWord = false;
            }
            return validWord;
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
