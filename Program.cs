using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            // a count that regulates what animal the program is on and what to print.
            int _count = 1;
            Console.WriteLine("For the Dog");
            while (_count < 3)
            {
                // asking the user what the name, height, weight, and color of each animal is
                Console.WriteLine("Name?");
                string _name = Console.ReadLine();

                double _height;
                Console.WriteLine("Height? (in)");
                string _inputHeight = Console.ReadLine();
                double.TryParse(_inputHeight, out _height);

                double _weight;
                Console.WriteLine("Weight? (oz)");
                string _inputWeight = Console.ReadLine();
                double.TryParse(_inputWeight, out _weight);

                string _color;
                Console.WriteLine("Color?");
                _color = Console.ReadLine();

                // if count = 1, then it's the dog's turn 
                // the user's input is sent to the dog class
                // the info is printed out and one more is added for the count
                // "For the cat?" is printed out and the loop is re done.
                if (_count == 1)
                {
                    Dog _dog = new Dog(_name, _height,_weight, _color);
                    string _printOut = _dog.PrintOutDetails();
                    Console.WriteLine(_printOut);
                    _count++;

                    Console.WriteLine();
                    Console.WriteLine("For the cat?");
                    continue;
                }
                else if (_count == 2)
                {
                    Cat _cat = new Cat(_name, _height, _weight, _color);
                    string _printOut = _cat.PrintOutDetails();
                    Console.WriteLine(_printOut);
                    break;
                }
            }           
        }

        /// <summary>
        /// The instructions for this assignment
        /// </summary>
        private void AssignmentInstructions()
        {
            /*
             * Create an animal class. Create a dog and a cat class that demonstrates inheritance. 
             * Animal class must implement name, height, weight, color. Implement bark volume as an enum in the dog class. Implement fur length as an enum in the cat class.
             * Create a specific method in the dog and cat class to determine amount of food eaten per day.
             * A cat will eat 1/4 oz of food for each pound they weigh. A dog will each 1 oz of food for each pound they weight. 
             * The method should be defined (made/created) in the animal class but implemented (has code inside to do work) in the cat and dog class.
             */

             // learn to read other peoples code
             // be multilingual in code for production
             // virtual method not intended to be overwritten but can be!
        }
    }

    /// <summary>
    /// The base class to the (Dog) and (Cat) classes.
    /// This class is abstract, when a class is abstract, you are not allowed to make an instance of it but only inherit it.
    /// </summary>
    abstract public class Animal
    {
        // implementation of the Name, Height, Weight, and Color for each animal
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// This method is abstract 
        /// when a method is abstract, that means that it must be implemented (code must be put inside of it) inside of the class that inherits it
        /// you do this by making the same method inside of the derived class but with the keywork (override) instead of abstract
        /// </summary>
        /// <returns></returns>
        public abstract double AnimalEats();
        /// <summary>
        /// This method is abstract 
        /// when a method is abstract, that means that it must be implemented (code must be put inside of it) inside of the class that inherits it
        /// you do this by making the same method inside of the derived class but with the keywork (override) instead of abstract
        /// </summary>
        /// <returns></returns>
        public abstract string PrintOutDetails();
        /// <summary>
        /// A virtual method that the (Dog) and (Cat) classes to use for computing.
        /// This method is virtual
        /// which means that the derived class can implement the method if they want
        /// </summary>
        public virtual string Computing() { return null; }
 
    }

    /// <summary>
    /// The derived class (Dog) has inherited the base class (Animal).
    /// </summary>
    public class Dog : Animal
    {
        public Dog(string dogName, double dogHeight, double dogWeight, string dogColor)
        {
            // assigning the properties inside of the base class 
            base.Name = dogName;
            base.Height = dogHeight;
            base.Weight = dogWeight;
            base.Color = dogColor;             
        }

        /// <summary>
        /// the implementation of the abstract method in the class (Animals) called (AnimalEats) 
        /// to implement, you make the same method inside of the derived class but using the word (override) instead
        /// </summary>
        /// <returns></returns>
        public override double AnimalEats()
        {
            double _dogEats = base.Weight;
            return _dogEats;
        }
        
        // anenum that hold the bark volumes for the (Dog) class;
        enum BarkVolume {high = 1, silent};

        // private string field to hold the bark volume
        private string m_barkVolume;
        public override string Computing()
        {
            if (base.Weight < 880)
            {
                // if the weight of the dog is less than 15oz then the method sets the second index to set as bark volume
                m_barkVolume = Enum.GetName(typeof(BarkVolume), 2);
                return m_barkVolume;
            }
            else if (base.Weight > 880)
            {
                // if the weight of the dog is above 15oz then the method sets either the first index as bark volume
                m_barkVolume = Enum.GetName(typeof(BarkVolume), 1);
            }
            return m_barkVolume;
        }

        /// <summary>
        /// the implementation of the abstract method in the class (Animals) called (PrintOutDetails) 
        /// </summary>
        /// <returns></returns>>
        public override string PrintOutDetails()
        {
            // what to print out at the end
            return "There is a new " + Color + " dog named " + Name + " that is " + Height + " inche(s) tall and weighs " + Weight + " ounces. " + Name + " barks in a " + Computing() + " way, and eats " + AnimalEats() + " ounces of food a day.";           
        }       
    }

    /// <summary>
    /// The derived class (Cat) has inherited the base class (Animal).
    /// </summary>
    public class Cat : Animal
    {
        public Cat(string _catName, double _catHeight, double _catWeight, string _catColor)
        {
            base.Name = _catName;
            base.Height = _catHeight;
            base.Weight = _catWeight;
            base.Color = _catColor;
        }

        /// <summary>
        /// the implementation of the abstract method in the class (Animals) called (AnimalEats) 
        /// </summary>
        /// <returns></returns>
        public override double AnimalEats()
        {
            double _catEats = Weight * .25;
            return _catEats;
        }
        
        // an enum that hold the fur length for the (Cat) class;
        enum FurLength {tall = 1, small};

        // private string to hold the fur length
        private string m_furLength;
        public override string Computing()
        {           
            if (base.Weight < 135)
            { 
                // if the weight of the cat is less than 15oz then the method gets the second index to set as fur length
                m_furLength = Enum.GetName(typeof(FurLength), 2);
                return m_furLength;
            }
            else if (base.Weight > 135)
            {
                // if the weight of the cat is above 15oz then the method gets the first index to set as fut length
                m_furLength = Enum.GetName(typeof(FurLength), 1);                
            }
            return m_furLength;
        }

        /// <summary>
        /// the implementation of the abstract method in the class (Animals) called (PrintOutDetails) 
        /// </summary>
        /// <returns></returns>>
        public override string PrintOutDetails()
        { 
            // what to print out at the end
            return "There is a new " + Color + " cat named " + Name + " that is " + Height + " inche(s) tall and weighs " + Weight + " ounces. " + Name + " and has a " + Computing() + " fur length, and eats " + AnimalEats() + " ounces of food a day.";            
        }          
    }
}
