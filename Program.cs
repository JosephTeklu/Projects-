using System;

namespace AssignmentFromWesAndDave2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int m_upperLimit = 0;
            Number_Data_Storing_And_Calculactions Calling;

            Console.WriteLine("Welcome to number guessing game!");
            Console.WriteLine();

            Console.WriteLine("In this game you will need to guess a number from 0 to another number larger than 10 \n that YOU get to decide,\n what would you like the highest number to be? ");
            string m_highestNumber = Console.ReadLine();

            while (true)
            {   // turns string value into int
                bool numbOrNot = Int32.TryParse(m_highestNumber, out m_upperLimit);
                if (numbOrNot == true && m_upperLimit > 10)
                {
                    // If you want to send a constroctor something, make an instence of it's class and send it through the argument.
                    Calling = new Number_Data_Storing_And_Calculactions(m_upperLimit);
                    break;
                }
                else if (numbOrNot == false | m_upperLimit <= 10)
                {
                    Console.WriteLine("Please enter in a number that is larger than 10.");
                    m_highestNumber = Console.ReadLine();
                    continue;
                }
            }

            Console.WriteLine("Alrigt, so now you have to guess the correct number between 0 and " + m_upperLimit);
            string m__guess = Console.ReadLine();

            bool high = false;
            bool low = false;
            bool correct = false;
            bool m_guessIsAboveUpperLimit = false;
            bool m_guessIsUpperLimit = false;

            int m_numberOfGuesses = 0;

            while (true)
            {
                int m_guess;
                bool m_numbOrnot = Int32.TryParse(m__guess, out m_guess);

                Calling.Guess = m_guess;

                    // the variable (m_numberOfGuesses) becomes what the property (NumberOfGuesses) returns
                    m_numberOfGuesses = Calling.NumberOfGuesses;

                    // sending the guess (m_guess) to 
                    high = Calling.CheckingHigh(m_guess);
                    low = Calling.CheckingLow(m_guess);
                    correct = Calling.CheckingCorrect(m_guess);
                    m_guessIsAboveUpperLimit = Calling.CheckingIfGuessIsAboveUpperLimit(m_guess);
                                  
                
                    m_guessIsUpperLimit = Calling.CheckingIfGuessIsUpperLimit(m_guess);

                if (m_numbOrnot == false)
                {
                    Console.WriteLine("Please enter in a number that is from 0 to " + m_upperLimit);
                    m__guess = Console.ReadLine();
                }
                else if (m_guessIsAboveUpperLimit)
                { 
                    Console.WriteLine("Ohh your gussed above the upper limit! Try again!");
                    m__guess = Console.ReadLine();
                }
                else if (high)
                {
                    Console.WriteLine("Ohh your guess is too high! Try again!");
                    m__guess = Console.ReadLine();
                }
                else if (low)
                {
                    Console.WriteLine("Ohh your guess is too low! Try again!");
                    m__guess = Console.ReadLine();
                }
                else if (m_guessIsUpperLimit)
                {
                    Console.WriteLine("Ohh you just guessed your upper limit! \n Try again!");
                    m__guess = Console.ReadLine();
                }
                else if (correct)
                {
                    Console.WriteLine("Correct! \n You have guessed correct with " + m_numberOfGuesses + " guesses.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter in a guess from 0 to " + m_upperLimit);
                    m__guess = Console.ReadLine();
                }
            }
        }          
    }

    /// <summary>
    /// A class for storing all number data and calculations
    /// </summary>
    public class Number_Data_Storing_And_Calculactions
    {
        // declaring the upper limit field
        public int m_upperLimit;
        // declaring the random number field
        public int m_randomNumber;
        // Instantiating the random class
        Random random = new Random();

        private int m_guess;
        public int m_numberOfGuesses = 0;

        public int Guess
        {
            get
            {
                // returns (m_guess)
                return m_guess;
            }
            set
            {
                // (m_guess) is equal to (value) which value is what is being sent down from the main method
                m_guess = value;

                // for every guess passed down, one more would be added to (m_numberOfGuesses)
                m_numberOfGuesses ++;
            }
        }

        public int NumberOfGuesses
        {
            get
            {
                // the total number of guesses is returned to the main method
                return m_numberOfGuesses;
            }
        }

        /// <summary>
        /// This constructor assigns the field (m_upperLimit)
        /// </summary>
        /// <param name="upperLimit"></param>
        public Number_Data_Storing_And_Calculactions(int upperLimit)
        {
            // assigning the field m_upperLimit
            m_upperLimit = upperLimit;

            // you need to call the method inside of the constructor for it to run
            CalculatingTheRandomNumber();
        }

        /// <summary>
        /// This method assigns the random number from 0 to the (m_upperLimit)
        /// </summary>
        public void CalculatingTheRandomNumber()
        {
            // assigning the field m_randomNumber
            m_randomNumber = random.Next(0, m_upperLimit);
            //Console.WriteLine(m_randomNumber);
        }

        public bool CheckingIfGuessIsAboveUpperLimit(int guess)
        {
            if (m_guess > m_upperLimit)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method checks if the guess is the upper limit set by the user.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public bool CheckingIfGuessIsUpperLimit(int guess)
        {
            if (m_guess == m_upperLimit)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method checks if the guess is higher than the random number. 
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public bool CheckingHigh(int guess)
        {
            if (m_guess > m_randomNumber) 
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method checks if the guess is lower than the random number.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public bool CheckingLow(int guess)
        {
            if (m_guess < m_randomNumber)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method checks if the guess is guessed right.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        public bool CheckingCorrect(int guess)
        {
            if (m_guess == m_randomNumber)
            {
                return true;
            }
            return false;
        }       
    }
}
