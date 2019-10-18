using System;

namespace AssignmentFromWesAndDave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Assignment Questions = new Assignment();
            Questions.MovingLetterA();
            Questions.UpperAndLowerCase();
            Questions.RandomNumbers();
        }
    }

    public class Assignment
    {
        /// <summary>
        /// This method replaces the position of the letter A to the next index from where it was.
        /// </summary>
        /// <returns></returns>
        public void MovingLetterA()
        {
            char[] Letters = new char[10] { 'A', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' };
            // A char array with 10 letters

            for (int i = 0; i < Letters.Length; i++)
            {
                Console.WriteLine(Letters[i]);
                // the original char array would be outputed.
            }
            Console.WriteLine();

            int count = 0;  // an int variable to have as a counter
            while (count != 9)
            {   // since arrays start on zero.
                for (int e = 0; e < Letters.Length; e++)
                {
                    if (Letters[e] == 'A')
                    {   // if one of the indexes inside of the char array (Letters) has a char ('A') inside of it.

                        Letters[e] = 'X';   // that index that had ('A') would then have ('X').
                        e = e + 1;          // the index that had ('A') would equal the next index.
                        Letters[e] = 'A';   // that index would then become ('A')

                        for (int k = 0; k < Letters.Length; k++)
                        {
                            Console.WriteLine(Letters[k]);
                            // the new char array with the new position of ('A') is outputed.
                        }
                        Console.WriteLine();

                        count++;
                        // count +=
                    }
                }
            }
        }
        /// <summary>
        /// This method converts uppercase letters to the letter 'U', lowercase letters to the letter 'L' and other characters that are not space marks to the question mark (?)
        /// 
        /// Create an array with 10 random numbers. Find the number of times that each digit occurs in all of the numbers. Find the median number based upon the digit occurrences.
        /// </summary>
        public void UpperAndLowerCase()
        {
            string sampleSentence = "My Monthly Balance Is 78 Dollars %^&**(&^%%";
            char[] _sampleSentence = sampleSentence.ToCharArray();

            char[] upperCaseAlphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lowerCaseAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] otherCharacters = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '[', '{', ']', '}' };
            // array of charaters that are not letters called (otherCharacters)

            for (int i = 0; i < _sampleSentence.Length; i++)
            {   // introduces the array of the sample sentence

                for (int u = 0; u < upperCaseAlphabet.Length; u++)
                {   // introduces the array with all capital alphabet letters
                    if (_sampleSentence[i] == upperCaseAlphabet[u])
                    {   // if inside of the index (i) of (_sampleSentence) if that matches with what is inside of the index (u) from the array (upperCaseAlphabet)
                        _sampleSentence[i] = 'U';   // that letter would become the character 'U'
                        break;
                    }
                }

                for (int l = 0; l < lowerCaseAlphabet.Length; l++)
                {   // introduces the array with all lower case alphabet letters
                    if (_sampleSentence[i] == lowerCaseAlphabet[l])
                    {   // if inside of the index (i) inside of the array (_sampleSentence) if that matches with what is inside of the index (l) inside of the array (lowerCaseAlphabet)
                        _sampleSentence[i] = 'L';   // that letter would become the character 'L'
                        break;
                    }
                }

                if (_sampleSentence[i] != 'U' && _sampleSentence[i] != 'L' & _sampleSentence[i] != ' ')
                {   // if what is inseide of the index (i) is not a 'U', an 'L' or a space 
                    _sampleSentence[i] = '?';
                }
                Console.WriteLine(_sampleSentence[i]);
            }
        }

        public void RandomNumbers()
        {
            Random random = new Random();
            // the random class is called and is given the name (random)

            int[] randomNumbers = new int[10];
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };
            int[] countingArray = new int[100];

            for (int r = 0; r < randomNumbers.Length; r++)
            {
                randomNumbers[r] = random.Next(0, 345);
                // Whastever is inside of the index (i) from the array (randomNumbers) it equal a random number from 0 to 345 (0, 345)
            }
        }
    }
}