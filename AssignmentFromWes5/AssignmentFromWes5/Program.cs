using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFromWes5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Assignment Questions = new Assignment();

            ////Month(Questions);
            //LargestNumberInArray(Questions);
            //NumberOfVowelsInASentence(Questions);
            //MostFrequentLetterInASentence(Questions);
            //MostFrequentLetterInASentence2(Questions);
            //ReversingLowerAndUpperLetters(Questions);
            //ReversingSentences(Questions);

        }

        private static void ReversingSentences(Assignment Questions)
        {
            Console.WriteLine("Please enter in a sentence");
            string userInputSentence4 = Console.ReadLine();
            int numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence4);
            while (true)
            {
                if (numberOfVowels >= 1)
                {
                    string reversedSentence = Questions.ReversingSentences(userInputSentence4);
                    Console.WriteLine(reversedSentence);
                    break;
                }
                else
                {
                    Console.WriteLine("Try again:");
                    userInputSentence4 = Console.ReadLine();
                    numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence4);
                    continue;
                }
            }
        }

        private static void ReversingLowerAndUpperLetters(Assignment Questions)
        {
            Console.WriteLine("Please enter in a sentence");
            string userInputSentence3 = Console.ReadLine();
            int numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence3);
            while (true)
            {
                if (numberOfVowels >= 1)
                {
                    string reversedSentenceLetters = Questions.ReversingLowerAndUpperCaseLetters(userInputSentence3);
                    Console.WriteLine(reversedSentenceLetters);
                    break;
                }
                else
                {
                    Console.WriteLine("Try again:");
                    userInputSentence3 = Console.ReadLine();
                    numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence3);
                    continue;
                }
            }
        }

        private static void MostFrequentLetterInASentence2(Assignment Questions)
        {
            Console.WriteLine("Please enter in a sentence");
            string userInputSentence2 = Console.ReadLine();
            int numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence2);
            while (true)
            {
                if (numberOfVowels >= 1)
                {
                    char MostFrequentLetterInASentence2 = Questions.MostFrequentLetterInASentence2(userInputSentence2);
                    Console.WriteLine(MostFrequentLetterInASentence2 + " is the most reoccuring letter in the sentence: " + userInputSentence2);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter in a sentence with only letters");
                    userInputSentence2 = Console.ReadLine();
                    numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence2);
                    continue;
                }
            }
        }

        private static void MostFrequentLetterInASentence(Assignment Questions)
        {
            Console.WriteLine("Please enter in a sentence");
            string userInputSentence = Console.ReadLine();
            int numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence);
            while (true)
            {
                if ( numberOfVowels >= 1)
                {
                    Questions.MostFrequentLetterInASentence(userInputSentence);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter in a sentence with only letters");
                    userInputSentence = Console.ReadLine();
                    numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence);
                    continue;

                }
            }
        }

        private static void NumberOfVowelsInASentence(Assignment Questions)
        {
            Console.WriteLine("Please type in a sentence");
            string userInputSentence = Console.ReadLine();
            // if the user input is not a string, the program would return 0 because it is not a string.
            int numberOfVowels = Questions.NumberOfVowelsInASentence(userInputSentence);
            Console.WriteLine("There are " + numberOfVowels + " vowel(s) in your sentence");
            Console.WriteLine();
        }

        private static void LargestNumberInArray(Assignment Questions)
        {
            int[] arrayOfRandomNumbers = new int[10];
            Random random = new Random();
            // The Random class is called and a new instance of it is made that is put into (random).
            for (int i = 0; i < arrayOfRandomNumbers.Length; i++)
            {
                arrayOfRandomNumbers[i] = random.Next(0, 3284);
                // the array is populated using the (Random) class, with a minnium of (0), and a max of (3284).
                Console.WriteLine(arrayOfRandomNumbers[i]);
            }
            Console.WriteLine();
            int largestNumberInArray = Questions.LargestNumberInArray(arrayOfRandomNumbers);
            // the array (arrayOfRandomNmbers) is sent down to the method (LargestNumberInArray) and is put into a variable called (largestNumberInArray).
            // when the largest number in the array is sent up from the method (LargestNumberInarray) it is put into the variable (largestNumberInArray)
            Console.WriteLine("The largest number in the array is " + largestNumberInArray);
            Console.WriteLine();
        }

        private static void Month(Assignment Questions)
        {
            int year2;
            Console.WriteLine("Please enter in a year. ");
            while (true)
            {
                string year = Console.ReadLine();

                bool InYear = int.TryParse(year, out year2);
                if (InYear == false)
                {
                    Console.WriteLine("The value you have given is incorrect. Please enter in a year");
                    continue;
                }
                break;
            }
            int monthNumber2;
            Console.WriteLine("Please enter in the number associated with your month. ");

            while (true)
            {
                string monthNumber = Console.ReadLine();
                // the variable (monthNumber) has the user's input of the month number

                bool InMonth = int.TryParse(monthNumber, out monthNumber2);
                if (InMonth == true)
                {
                    int daysInMOnth = Questions.Month(monthNumber2, year2);
                    // the method called (Months) is called and passed the month number and year. Also anything sent from the method (Months) is put into the variable (daysInMOnth).

                    Console.WriteLine(daysInMOnth + " days");
                    // the days in the month sent from the mehtod (months) is outputed.
                }
                else
                {
                    Console.WriteLine("Please enter in a digit from 1 - 12");
                    continue;
                }
                break;
            }
            Console.ReadLine();
        }
    }

    /// <summary>
    /// This class holds the methods that answer the questions of the assignment.
    /// </summary>
    public class Assignment
    {
        /// <summary>
        /// This method called (Month) checks the number of the month and year that is passed down to it, and outputs how many days it has in that year.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int Month(int monthNumber, int year)
        {
            if (monthNumber == 2)
            {
                if (year % 4 == 0 & year % 100 != 0 & year % 400 != 0)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }

            }
            else if (monthNumber < 7 & monthNumber % 2 != 0)
            {        // the month number is less than 8 and is odd
                return 31;
            }
            else if (monthNumber < 7 & monthNumber % 2 == 0)
            {       // the month number is greater than 7 and is even
                return 30;
            }
            else if (monthNumber == 7)
            {
                return 31;
            }
            else if (monthNumber > 7 & monthNumber < 13 & monthNumber % 2 != 0)
            {       // the month number is greater than 8 and is odd
                return 30;
            }
            else if (monthNumber > 7 & monthNumber < 13 & monthNumber % 2 == 0)
            {
                return 31;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// This method checks for the largest number in the array it gets passed and returns it.
        /// </summary>
        /// <param name="arrayOfNumbers"></param>
        /// <returns></returns>
        public int LargestNumberInArray(int[] arrayOfRandomNumbers)
        {

            int largestNumberInArray = 0;
            for (int i = 0; i < arrayOfRandomNumbers.Length; i++)
            {
                if (arrayOfRandomNumbers[i] > largestNumberInArray)
                {   // if the array of numbers passed down are larger than the integer (largestNumberInArray)
                    largestNumberInArray = arrayOfRandomNumbers[i];
                    // largestNUmberInArray would then equal the number that was larger than it.
                    // then (largestNumberInArray) with its new value would be checked by all the other numbers in the array
                    // and the largest number would stay as the integer variable (largestNumberInArray)
                }
            }
            return largestNumberInArray;
        }

        /// <summary>
        /// This method checks for how many vowels are in the supplied sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public int NumberOfVowelsInASentence(string userInputSentence)
        {
            char[] charactersOf_UserInputSentence = userInputSentence.ToCharArray();
            // the array passed down is put into the char array (charactersOFsentence) while using the (ToCharArray()) method.

            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            // an array of vowels called (vowels)

            int numberOfVowelsInSentence = 0;
            foreach (char ch in charactersOf_UserInputSentence)                     
            {   // for each character named ch inside of (characterOfSentence)
                if (vowels.Contains(ch))
                {  // if vowels is equal to (ch) which is each character inside of (charactersOfSentence)

                    numberOfVowelsInSentence++;
                    // numberOfVowelsInASentence would equal one more, counting how many vowels there are
                }
            }
            return numberOfVowelsInSentence;
        }

        /// <summary>
        /// This method, when supplied a sentence, determines the letter that occurs most frequently and returns it.
        /// </summary>
        /// <param name="repetition"></param>
        /// <returns></returns>
        public string MostFrequentLetterInASentence(string userInputSentence)
        {
            int letter_a= 0;
            int letter_b= 0;
            int letter_c= 0;
            int letter_d= 0;
            int letter_e= 0;
            int letter_f= 0;
            int letter_g= 0;
            int letter_h= 0;
            int letter_i= 0;
            int letter_j= 0;
            int letter_k= 0;
            int letter_l= 0;
            int letter_m= 0;
            int letter_n= 0;
            int letter_o= 0;
            int letter_p= 0;
            int letter_q= 0;
            int letter_r= 0;
            int letter_s= 0;
            int letter_t= 0;
            int letter_u= 0;
            int letter_v= 0;
            int letter_w= 0;
            int letter_x= 0;
            int letter_y= 0;
            int letter_z= 0;

            int holdingNumber = 0;
            char holdingLetter = ' ';

            foreach (char ch in userInputSentence)
            {
                if (ch == 'a')
                {
                    letter_a++;
                    if (letter_a > holdingNumber)
                    {
                        holdingNumber = letter_a;
                        holdingLetter = 'a';
                    }
                }
                
                if (ch == 'b')
                {
                    letter_b++;
                    if (letter_b > holdingNumber)
                    {
                        holdingNumber = letter_b;
                        holdingLetter = 'b';
                    }
                }
                
                if (ch == 'c')
                {
                    letter_c++;
                    if (letter_c > holdingNumber)
                    {
                        holdingNumber = letter_c;
                        holdingLetter = 'c';
                    }
                    
                }

                if (ch == 'd')
                {
                    letter_d++;
                    if (letter_d> holdingNumber)
                    {
                        holdingNumber = letter_d;
                        holdingLetter = 'd';
                    }
                }

                if (ch == 'e')
                {
                    letter_e++;
                    if (letter_e> holdingNumber)
                    {
                        holdingNumber = letter_e;
                        holdingLetter = 'e';
                    }
                }

                if (ch == 'f')
                {
                    letter_f++;
                    if (letter_f> holdingNumber)
                    {
                        holdingNumber = letter_f;
                        holdingLetter = 'f';
                    }
                }

                if (ch == 'g')
                {
                    letter_g++;
                    if (letter_g> holdingNumber)
                    {
                        holdingNumber = letter_g;
                        holdingLetter = 'g';
                    }
                }

                if (ch == 'h')
                {
                    letter_h++;
                    if (letter_h> holdingNumber)
                    {
                        holdingNumber = letter_h;
                        holdingLetter = 'h';
                    }
                }

                if (ch == 'i')
                {
                    letter_i++;
                    if (letter_i> holdingNumber)
                    {
                        holdingNumber = letter_i;
                        holdingLetter = 'i';
                    }
                }

                if (ch == 'j')
                {
                    letter_j++;
                    if (letter_j> holdingNumber)
                    {
                        holdingNumber = letter_j;
                        holdingLetter = 'j';
                    }
                }

                if (ch == 'k')
                {
                    letter_k++;
                    if (letter_k> holdingNumber)
                    {
                        holdingNumber = letter_k;
                        holdingLetter = 'k';
                    }
                }

                if (ch == 'l')
                {
                    letter_l++;
                    if (letter_l> holdingNumber)
                    {
                        holdingNumber = letter_l;
                        holdingLetter = 'l';
                    }
                }

                if (ch == 'm')
                {
                    letter_m++;
                    if (letter_m> holdingNumber)
                    {
                        holdingNumber = letter_m;
                        holdingLetter = 'm';
                    }
                }

                if (ch == 'n')
                {
                    letter_n++;
                    if (letter_n> holdingNumber)
                    {
                        holdingNumber = letter_n;
                        holdingLetter = 'n';
                    }
                }

                if (ch == 'o')
                {
                    letter_o++;
                    if (letter_o> holdingNumber)
                    {
                        holdingNumber = letter_o;
                        holdingLetter = 'o';
                    }
                }

                if (ch == 'p')
                {
                    letter_p++;
                    if (letter_p> holdingNumber)
                    {
                        holdingNumber = letter_p;
                        holdingLetter = 'p';
                    }
                }

                if (ch == 'q')
                {
                    letter_q++;
                    if (letter_q> holdingNumber)
                    {
                        holdingNumber = letter_q;
                        holdingLetter = 'q';
                    }
                }

                if (ch == 'r')
                {
                    letter_r++;
                    if (letter_r> holdingNumber)
                    {
                        holdingNumber = letter_r;
                        holdingLetter = 'r';
                    }
                }

                if (ch == 's')
                {
                    letter_s++;
                    if (letter_s> holdingNumber)
                    {
                        holdingNumber = letter_s;
                        holdingLetter = 's';
                    }
                }

                if (ch == 't')
                {
                    letter_t++;
                    if (letter_t> holdingNumber)
                    {
                        holdingNumber = letter_t;
                        holdingLetter = 't';
                    }
                }

                if (ch == 'u')
                {
                    letter_u++;
                    if (letter_u> holdingNumber)
                    {
                        holdingNumber = letter_u;
                        holdingLetter = 'u';
                    }
                }

                if (ch == 'v')
                {
                    letter_v++;
                    if (letter_v> holdingNumber)
                    {
                        holdingNumber = letter_v;
                        holdingLetter = 'v';
                    }
                }

                if (ch == 'w')
                {
                    letter_w++;
                    if (letter_w> holdingNumber)
                    {
                        holdingNumber = letter_w;
                        holdingLetter = 'w';
                    }
                }

                if (ch == 'x')
                {
                    letter_x++;
                    if (letter_x> holdingNumber)
                    {
                        holdingNumber = letter_x;
                        holdingLetter = 'x';
                    }
                }

                if (ch == 'y')
                {
                    letter_y++;
                    if (letter_y> holdingNumber)
                    {
                        holdingNumber = letter_y;
                        holdingLetter = 'y';
                    }
                }

                if (ch == 'z')
                {
                    letter_z++;
                    if (letter_z> holdingNumber)
                    {
                        holdingNumber = letter_z;
                        holdingLetter = 'z';
                    }
                }
            }

            Console.WriteLine(holdingLetter + " is the most reoccuring letter, reoccuring " + holdingNumber + " times");
            Console.WriteLine();

            return "hi";

        }

        /// <summary>
        /// This method, when supplied a sentence, determines the letter that occurs most frequently and returns it.
        /// </summary>
        /// <param name="userInputSentence"></param>
        /// <returns></returns>
        public char MostFrequentLetterInASentence2(string userInputSentence)
        {
            char[] _userInputSentence = userInputSentence.ToCharArray();
            // takes the user input sentence and makes it into a char array called (_userInputSentence)

            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            // a char arry with the whole alphabet

            int[] numbForAlphabet = new int[26];
            // a blank integer array that can hold 26 numbers.
            
            for (int i = 0; i < _userInputSentence.Length; i++)
            {   // a for loop introducing the user input sentence
                for (int a = 0; a < alphabet.Length; a++)
                {   // a for loop introducing the alphabet array
                    if (alphabet[a] == _userInputSentence[i])
                    {   // if what is inside the index of the array (alphabet) is also the same as what is inside of the index of (_userInputSentence)
                        numbForAlphabet[a]++;
                        // then add one more to (numbForAlphabet) on the same index that alphabet was on.
                        break;
                    }
                }
            }

            int max = 0;
            char mostFrequentLetter = ' ';

            for (int i = 0; i < numbForAlphabet.Length; i++)
            {   // introduces the (numbForAlphabet) array
                if (numbForAlphabet[i] > max)
                {   // if the number that is inside of (numbForAlphabet) is larger than what maz  is
                    max = numbForAlphabet[i];           // max would equal what (numbForAlphabet) was
                    mostFrequentLetter = alphabet[i];   // (mostFrequentLetter) would equal what is inside of the array (alphabet) from the index that was used in (uumbForAlphabet)
                }
            }

            return mostFrequentLetter;

        }

        /// <summary>
        /// This method, when supplied a sentence, returns the sentence with it's upper and lower case letters reversed.
        /// </summary>
        /// <param name="userInputSentence"></param>
        /// <returns></returns>
        public string ReversingLowerAndUpperCaseLetters(string userInputSentence)
        {
            char[] _userInputSentence = userInputSentence.ToCharArray();
            char[] lowerCaseAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] upperCaseAlphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string output = null;
            // a strng variable that is equal to nothing.

            for (int ui = 0; ui < _userInputSentence.Length; ui++)
            {   // the character array of the user's input

                for (int lc = 0; lc < lowerCaseAlphabet.Length; lc++)
                {   // character array of lower case alphabet
                    if (_userInputSentence[ui] == lowerCaseAlphabet[lc])
                    {   // if the letter is lower case
                        output = output + _userInputSentence[ui].ToString().ToUpper();
                        // output would equal the letter, turned to a string, and turned into a lower character
                        break;
                    }
                }

                for (int uc = 0; uc < upperCaseAlphabet.Length; uc++)
                {   // charater array of upper case alphabet
                    if (_userInputSentence[ui] == upperCaseAlphabet[uc])
                    {   // if the letter is upper case
                        output = output + _userInputSentence[ui].ToString().ToLower();
                        // output would equal the letter, turned to a string, and turned into a lower character
                        break;
                    }
                }

                if (_userInputSentence[ui] == ' ')
                {
                    output = output + ' ';
                }
            }
             return output;
        }

        /// <summary>
        /// This method reverses the order of a sentence.
        /// </summary>
        /// <param name="userInputSentnce"></param>
        /// <returns></returns>
        public string ReversingSentences(string userInputSentnce)
        {
            char[] _userInputSentence = userInputSentnce.ToCharArray();
            // the user inputed sentence is divided using (ToCharArray())
            int letterCount = 0;    // an empty integer to hold (letterCount) in

            foreach (char letter in _userInputSentence)
            {
                letterCount++;
                // for each letter that is inside of the user input sentence, the letter counter would add by one
                // at the end (letterCount) would equal the number of letters in the user inputed sentence
            }

            string reversedSentence = "";   // an empty string to put reservedSentence in
            for (int i = letterCount; i > 0; i--)
            {   // the variable i is equal to (letterCount), as i is bigger than 0, i would count backwards
                reversedSentence = reversedSentence + _userInputSentence[i - 1];
                // the empty string would equal itself plus the letter from (_userInputsentence) with i-1 (since every array starts with 0)
            }
            return reversedSentence;
        }
    }     
}