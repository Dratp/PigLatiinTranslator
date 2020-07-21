using System;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Church";
            input = input.ToLower();
            int firstvowel = CheckVowel(input);
            Console.WriteLine(firstvowel);
            //MoveConsanants();
            //AddAy();


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
