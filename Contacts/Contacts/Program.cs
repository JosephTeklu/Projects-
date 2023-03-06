using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{                                                                                                                                  
    class Program
    {
        static void Main(string[] args)
        {
            ErrorChecking _errorChecking = new ErrorChecking();
            People _people = new People();
            bool _saveComplete = false;

            while (true)
            {
                {
                    // changing the text color to be greenl
                    Console.ForegroundColor = ConsoleColor.Green;

                    // asking the user for what they would like to do
                    Console.WriteLine( 
                    "Would you like to...\n " +
                    "1.) Display the people in your contact list\n " +
                    "2.) Display a specific person from your contact list\n " +
                    "3.) Add a person to your contact list\n " +
                    "4.) Edit a person from your contact list\n " +
                    "5.) Delete a person from your contact list\n " +
                    "6.) Save your contacts\n " +
                    "7.) Exit\n" +
                    "Please enter the number that corresponds with your choice or enter 'exit' to exit the program.");

                    // Reseting the text color
                    Console.ResetColor();
                }

                /// what the user types in is sent to (ErrorChecking) to check if the right data type has been given by the user
                /// (ErrorChecking) returns (0) if the user's input is not a number from 1-6
                /// (ErrorChecking) returns the user's input if the user's input is a number from 1-6
                int _userInput = _errorChecking.EvaluateUserInput(Console.ReadLine());
                
                if (_userInput == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // Outputing error message.
                    Console.WriteLine("Error: Please enter in a number that corresponds with the choices provided or enter 'exit' to exit.");
                    Console.ResetColor();
                    continue;
                }
                else if (_userInput == 1)
                {
                    // if there are no contacts in the list (ContactList)
                    if (_people.NumberOfContacts() == false)
                    {
                        // restart the loop
                        continue;
                    }

                    // calls the method that displays the people inside of the contact list
                    _people.DisplayPeople();
                }
                else if (_userInput == 2)
                {
                    // if there are no contacts in the list (ContactList)
                    if (_people.NumberOfContacts() == false)
                    {
                        // restart the loop
                        continue;
                    }

                    // if there are people inside of the contact list then call this method
                    _people.DisplaySpecificPeople();
                }
                else if (_userInput == 3)
                {
                    // call the (AddAPerson) method first to get the user's information
                    _people.AddAPerson();
                    // call the (Computation) method to save their information
                    _people.Computation();
                }
                else if (_userInput == 4)
                {
                    // checking if the user has any contacts first
                    // if there are no contacts in the list (ContactList)
                    if (_people.NumberOfContacts() == false)
                    {
                        // restart the loop
                        continue;
                    }

                    // calls the (EditAPerson) method to edit the info of a person
                    _people.EditAPerson();
                }
                else if (_userInput == 5)
                {
                    // if there are no contacts in the list (ContactList)
                    if (_people.NumberOfContacts() == false)
                    {
                        // restart the loop
                        continue;
                    }

                    // calls the (RemoveAPerson) method to remove a person
                    _people.RemovingAPerson();
                }
                else if (_userInput == 6)
                {
                    // if there are no contacts in the list (ContactList)
                    if (_people.NumberOfContacts() == false)
                    {
                       // restart the loop
                        continue;
                    }

                    // call the save class to save to the USER'S file
                    _people.SaveToUserFile();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Your contacts have been saved on you desktop to a file named '{_people.m_userFileName}'");

                    _saveComplete = true;

                   // call the method so that the contacts are saved to the file (DevSave)
                    _people.SaveToDevFile();
                }
                else if (_userInput == 7)
                {
                    if (_saveComplete == true)
                    {
                        System.Environment.Exit(0);
                    }
                    _people.Exit();
                }
            }
        }
        void Assignment()
        {
            //Create an App to display and edit a list of people
            //Create a Person class that stores a persons first name, last name and date of birth
            //Create an array that stores a list of people(person class)

            //On the screen prompt a user to (ask a person if they wnat to)
            //1.	Display list of people
            //2.	Display a specific person
            //3.	Add a person                                      //> all of their info would come out.
            //4.	Edit a person
            //5.	Delete a person                             /////// saving the data from before when the user goes again

            //When displaying all people or a specific person…
            //All on one line, show the first name, last name, birthday and also display the calculated age of the person.
        }
    }  

    public class People
    {
        // making instances of the classes nedded to be used for this class
        ErrorChecking m_errorChecking = new ErrorChecking();
        Person m_person = new Person();
        StreamWriter DevSave;
        StreamWriter Contact_List;

        // creating the variables needed to create a new contact
        string m_firstName; string m_lastName; public int m_monthBorn; public int m_dayBorn; public int m_yearBorn;

        // creating the variables that the user gives
        int m_userChoice; string m_answer;

        string m_folderLocation = @"C:/Contacts"; string m_devFileLocation = @"C:/Contacts/DevSave.txt"; public string m_userFileName; string m_userFileLocation = @"C:/users/" + System.Environment.UserName + "/desktop/"; 

        public static bool ChangeMade;

        // the list that holds the people inside of the Contact List                       
        public List<Person> ContactList = new List<Person>();

        /// <summary>
        /// This method checks if the folder that holds the DevSave file exists
        /// if the folder does not exist then the folder and the DevSave file are created
        /// </summary>
        public People()
        {
            // if the folder that holds the DevSave file does not exist
            if (!Directory.Exists(m_folderLocation))
            {                
                // create the folder
                Directory.CreateDirectory(m_folderLocation);
                // create the file                                                                                      
                DevSave = new StreamWriter(m_devFileLocation);
                DevSave.Close();
            }

            // if the folder and DevSave file exists then load the contacts that are inside of it
            LoadContacts();
        }
    
        /// <summary>
        /// This method grabs all of the data needed to create a new contact from the user
        /// It then assigns the given data to the variables in the class field
        /// </summary>
        public void AddAPerson()
        {
            // Getting the information from the user
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What is the person's first name?");
            Console.ResetColor();
            m_firstName = m_errorChecking.EvaluatingFirstAndLastName(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("What is the person's last name?");
            Console.ResetColor();
            m_lastName = m_errorChecking.EvaluatingFirstAndLastName(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What year was the person born?");
            Console.ResetColor();
            m_yearBorn = m_errorChecking.EvaluatingYearBorn(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What number of the month was the person born?");                                                           
            Console.ResetColor();
            m_monthBorn = m_errorChecking.EvaluatingMonthBorn(Console.ReadLine());
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("On what day was the person born?");
            Console.ResetColor();
            m_dayBorn = m_errorChecking.EvaluatingDayBorn(Console.ReadLine(), m_yearBorn);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"    {m_firstName} {m_lastName} has been added to your contact list!");
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// This method creates a new instance of the person class and fills in the properties inside with the information provided by the user
        /// It then adds that person into (ContctList)
        /// </summary>
        public void Computation()
        {
            Person person = new Person();

            // Assigning the properties for each person that is created inside of the class (person)
            person.FirstName = m_firstName;
            person.LastName = m_lastName;
            person.MonthBorn = m_monthBorn;
            person.DayBorn = m_dayBorn;
            person.YearBorn = m_yearBorn;
            person.DOB = new DateTime(person.YearBorn, person.MonthBorn, person.DayBorn);

            // subtracting the year now from the year supplied by the user
            person.Age = DateTime.Now.Year - int.Parse(person.DOB.Year.ToString());

            if (DateTime.Now.DayOfYear < person.DOB.DayOfYear)
            {
                person.Age = int.Parse(person.Age.ToString()) - 1;
            }

            // the new person created is added to the list (ContactList)
            ContactList.Add(person);

            //since a new person was added the change made property is set to true
            ChangeMade = true;
        }

        /// <summary>
        /// Returns the number of contacts inside of the list (ContactsList)
        /// </summary>
        /// <returns></returns>
        public bool NumberOfContacts()
        {
            if (ContactList.Count == 0 )
            {
                // Changing the text color to red.
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Outputing error message.
                Console.WriteLine();
                Console.WriteLine("Unfortunately, you have no contacts to perform this action.");
                Console.WriteLine();

                // Reseting the text color
                Console.ResetColor();
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method loops through (ContactList) and outputs each person's first and last name with thir DOB and Age
        /// </summary>
        public void DisplayPeople()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your contacts:");
            
            // looping through the contact list named (people) for instances of the class (Person)
            foreach (Person item in ContactList)
            {
                Console.WriteLine();
                // prints out the first name, last name, DOB, and age of the person
                Console.WriteLine($"    {item.FirstName} {item.LastName}, Born on: {item.DOB.Date.ToString("d")} Age: {item.Age}");
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// This class loops through (ContactList) and outputs a person's name attached with a number
        /// When the user picks a number, their information is outputed into the screen.
        /// If the user would like they can repeat the process.
        /// </summary>
        public void DisplaySpecificPeople()                                                                     
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                // looping through (ContactList) and outputing the contact's first name with their index plus one
                for (int i = 0; i < ContactList.Count; i++)
                {
                    Console.WriteLine($"    { (i + 1)}.) { ContactList[i].FirstName}");
                }
                Console.WriteLine();

                Console.WriteLine("Please enter in the number that is associated with the person whose information you would like to access.");
                Console.ResetColor();
                m_userChoice = m_errorChecking.BoundsOfList(Console.ReadLine(), ContactList.Count);

                Console.ForegroundColor = ConsoleColor.Green;

                // printing out the information of the contact that the user asked for
                Console.WriteLine($"    {ContactList[m_userChoice].FirstName} {ContactList[m_userChoice].LastName}, Born on: {ContactList[m_userChoice].DOB.Date.ToString("d")} Age: {ContactList[m_userChoice].Age}");

                Console.WriteLine("\nWould you like to output another person's information again? [y/n]) \nOr type in 'exit' to exit the program.");
                if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 1)
                {
                    continue;
                }
                else if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 9)
                {
                    Exit();
                }
                return;          
            }
        }

        /// <summary>
        /// This method loops through (ContactList) with a number attached to each contact.
        /// When the user enters in a number, the user can pick what to edit about that person.
        /// The user can repeat the process if they would like.
        /// </summary>
        public void EditAPerson()
        {
            int _editChoice;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                // looping through (ContactList) and outputing the contact's first name with their index plus one
                for (int i = 0; i < ContactList.Count; i++)
                {
                    Console.WriteLine($"    { (i + 1)}.) {ContactList[i].FirstName} {ContactList[i].LastName}");
                }
                Console.WriteLine();


                // asking the user whose information they would like to change
                Console.WriteLine("Please enter in the number that is associated with the person whose information you would like edit.");
                Console.ResetColor();
                m_userChoice = m_errorChecking.BoundsOfList(Console.ReadLine(), ContactList.Count);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(
                    "Would you like to....\n" +
                    "1) Edit the first name?\n" +
                    "2) Edit the last name?\n" +
                    "3) Edit the date of birth?\n"
                    );
                Console.ResetColor();
                Console.WriteLine();
                // The user gives a number for what they want to edit, the user's input is checked to see if it's an integer
                int.TryParse(Console.ReadLine(), out _editChoice);
                while (true)
                {
                    if (_editChoice == 1 || _editChoice == 2 || _editChoice == 3)
                    {
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter in a number from 1-3");                   
                    Console.ResetColor();

                    int.TryParse(Console.ReadLine(), out _editChoice);
                    continue;
                }
                Console.WriteLine();
                switch (_editChoice)
                {
                    case 1:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("What would you like to change the first name to?");

                        Console.ResetColor();
                        ContactList[m_userChoice].FirstName = m_errorChecking.EvaluatingFirstAndLastName(Console.ReadLine());

                        // since the FirstName was changed the change made property is made true
                        ChangeMade = true;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your changes have been made.\n");
                        Console.WriteLine();
                        break;

                    case 2:

                        Console.WriteLine("What would you like to change the last name to?");

                        Console.ResetColor();
                        ContactList[m_userChoice].LastName = m_errorChecking.EvaluatingFirstAndLastName(Console.ReadLine());

                        // since the LastName was changed the change made propery is made true
                        ChangeMade = true;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your changes have been made.\n");
                        Console.WriteLine();
                        break;

                    // Asing the user for the values for DOB, checking the values then assigning the values
                    case 3:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("What year was the person born?");
                        Console.ResetColor();
                        ContactList[m_userChoice].YearBorn = m_errorChecking.EvaluatingYearBorn(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("What number of the month was the person born?");
                        Console.ResetColor();
                        ContactList[m_userChoice].MonthBorn = m_errorChecking.EvaluatingMonthBorn(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("On what day was the person born?");
                        Console.ResetColor();
                        ContactList[m_userChoice].DayBorn = m_errorChecking.EvaluatingDayBorn(Console.ReadLine(), ContactList[m_userChoice].YearBorn);

                        // assigning the DOB of the person
                        ContactList[m_userChoice].DOB = new DateTime(ContactList[m_userChoice].YearBorn, ContactList[m_userChoice].MonthBorn, ContactList[m_userChoice].DayBorn);

                        // calculating the age of the person
                        ContactList[m_userChoice].Age = DateTime.Now.Year - int.Parse(ContactList[m_userChoice].DOB.Year.ToString());

                        if (DateTime.Now.DayOfYear < ContactList[m_userChoice].DOB.DayOfYear)
                        {
                            ContactList[m_userChoice].Age = int.Parse(ContactList[m_userChoice].Age.ToString()) - 1;
                        }

                        // since the DOB was changed the change made property is made true
                        ChangeMade = true;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your changes have been made.\n");
                        Console.WriteLine();
                        break;                     
                    
                }

                Console.WriteLine("Would you like to change another person's details? [y/n] \nOr enter 'exit' to exit the program.");
                m_answer = Console.ReadLine();
                if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 1)
                {
                    continue;
                }
                else if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 9)
                {
                    Exit();
                }
                else
                {
                    return;
                }
            }           
        }

        /// <summary>
        /// This method loops through (ContactList) and outputs each person with a number attached to them.
        /// When the user enter's in a number, the person associated with that number is removed from (ContactList).
        /// The user may repeat this process if they still have contacts in (ContactList).
        /// </summary>
        public void RemovingAPerson()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPlease enter in the number that is associated with the person whom you would like to remove.");

                // looping through (ContactList) and outputing the contact's first name with their index plus one
                for (int i = 0; i < ContactList.Count; i++)
                {
                    Console.WriteLine($"    {(i + 1)}.) {ContactList[i].FirstName} {ContactList[i].LastName}, Born on: {ContactList[i].DOB.Date.ToString("d")} Age: {ContactList[i].Age}");
                }
                Console.WriteLine();
                Console.ResetColor();
                //m_userChoice = Console.ReadLine();
                // checks that the number given by the user is an actual number that is between the bounds of the list indexes
                m_userChoice = m_errorChecking.BoundsOfList(Console.ReadLine(), ContactList.Count);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Are you sure you want to delete { ContactList[m_userChoice].FirstName} {ContactList[m_userChoice].LastName}? [y/n]");
                m_answer = Console.ReadLine();
                if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 1)
                {
                    // removing the person the user has chosen
                    ContactList.RemoveAt(m_userChoice);

                    // since a contact was removed teh change made property is made true
                    ChangeMade = true;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour changes have been made.\n");
                }
                else if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 2)
                {

                }
                else if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 9)
                {
                    Exit();
                }

                // checks if there are any more contacts inside of (ContactList)
                if (ContactList.Count ==  0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You have no more contacts to remove.\n");
                    return;
                }

                Console.WriteLine("Would you like to remove another contact from your contact list? [y/n] \nOr enter 'exit' to exit the program.");
                m_answer = Console.ReadLine();
                if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 1)
                {
                    continue;
                }
                else if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 9)
                {
                    Exit();
                }
                return;
            }
        }

        /// <summary>
        /// This method saves the contacts as they currently are to the user's file that contains all of the contacts.
        /// </summary>
        public void SaveToUserFile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What would you like to name the file that will save the contacts as you have them now?");
            m_userFileName = Console.ReadLine();

            while (string.IsNullOrEmpty(m_userFileName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("A name is required for the file.");
                m_userFileName = Console.ReadLine();
                continue;
            }

            m_userFileLocation += m_userFileName + ".txt";
            Contact_List = new StreamWriter(m_userFileLocation);
           
            //loops through(ContactList) and outputs the users information to the file.
            for (int i = 0; i < ContactList.Count; i++)
            {
                Contact_List.WriteLine($"{i + 1}.) {ContactList[i].FirstName} {ContactList[i].LastName}, Born on: {ContactList[i].DOB.Date.ToString("d")} Age: {ContactList[i].Age}");
            }
            // close out of the file
            Contact_List.Close();
            return;
        }

        /// <summary>
        /// saves the contacts how they are to DevSave.txt
        /// </summary>
        public void SaveToDevFile()
        {
            DevSave = new StreamWriter(m_devFileLocation);

            for (int i = 0; i < ContactList.Count; i++)
            {
                DevSave.WriteLine($"{ContactList[i].FirstName}|{ContactList[i].LastName}|{ContactList[i].MonthBorn}|{ContactList[i].DayBorn}|{ContactList[i].YearBorn}|");
            }
            DevSave.Close();           
        }

        public void LoadContacts()
        {
            // creating the common variables used throughout this method
            int _toFirstName; int _toLastName; int _toMonth; int _toDay; int _toYear;

            // a string array that holds all of the lines inside of the text file in an individual index
            string[] FileContents = File.ReadAllLines(m_devFileLocation);

            ///a list to hold the numbers of stopping points
            /// (0-1st#) = First name
            /// (1st#-2nd#) = Last name
            /// (2nd#-3rd#) = Month born
            /// (3rd#-4th#) = Day born
            /// (4th#-Last#) = Year born
            List<int> StoppingPoint = new List<int> { };

            char[] Contents = string.Join(string.Empty, FileContents).ToCharArray();

            // (_counter) holds the number of times the program has gotten information about each contact
            // counts to make sure the program only recieves info for evey line there is in the .txt file
            int _counter = 1;

            // (_startNumber) is initally 0 so that when looping through the array we star on index 0
            // then (_startNumber) begins on the last index for the last person inside of (StoppingPoint) so the correct first name is recieved.
            int _startNumber = 0;

            while (_counter <= FileContents.Length)
            {
                // looping through (Contents) and finding every pole (|) and saving the index number of the pole inside of (StoppingPoint)
                for (int i = _startNumber; i < Contents.Length; i++)
                {
                    if (Contents[i] == '|')
                    {
                        StoppingPoint.Add(i);
                        Contents[i] = ' ';
                    }
                }

                _toFirstName = StoppingPoint[0];
                _toLastName = StoppingPoint[1];
                _toMonth = StoppingPoint[2];
                _toDay = StoppingPoint[3];
                _toYear = StoppingPoint[4];


                m_firstName = "";
                // looping from the start numer to where the first name ends
                for (int i = _startNumber; i < _toFirstName; i++)
                {
                    m_firstName = m_firstName + Contents[i];
                }

                m_lastName = "";
                // looping from where the first name ended++ to where the last name ends
                for (int i = (_toFirstName + 1); i < _toLastName; i++)
                {
                    m_lastName = m_lastName + Contents[i];
                }

                string _month = "";
                // looping from where the last name ended++ to where the month born number ends
                for (int i = (_toLastName + 1); i < _toMonth; i++)
                {
                    _month = _month + Contents[i];
                }
                int.TryParse(_month, out m_monthBorn);

                string _day = "";
                // looping from where the month born number ends++ to where the day born ends
                for (int i = (_toMonth + 1); i < _toDay; i++)
                {
                    _day = _day + Contents[i];
                }
                int.TryParse(_day, out m_dayBorn);

                string _year = "";
                // looping from where the day born number ends++ to where the year born ends
                for (int i = (_toDay + 1); i < _toYear; i++)
                {
                    _year = _year + Contents[i];
                }
                int.TryParse(_year, out m_yearBorn);

                // refreshing the starting points so the stoppin points for the next line/next person could be saved
                StoppingPoint.Remove(_toFirstName);
                StoppingPoint.Remove(_toLastName);
                StoppingPoint.Remove(_toMonth);
                StoppingPoint.Remove(_toDay);
                StoppingPoint.Remove(_toYear);

                // the start number is set to the index of the pole that is after the year born number so the program can start looping from there
                _startNumber = _toYear + 1;

                {   // save the person inside of the list Contacts
                    Person person = new Person();

                    // Assigning the properties for each person that is created inside of the class (person)
                    person.FirstName = m_firstName;
                    person.LastName = m_lastName;
                    person.MonthBorn = m_monthBorn;
                    person.DayBorn = m_dayBorn;
                    person.YearBorn = m_yearBorn;
                    person.DOB = new DateTime(person.YearBorn, person.MonthBorn, person.DayBorn);

                    // subtracting the year now from the year supplied by the user
                    person.Age = DateTime.Now.Year - int.Parse(person.DOB.Year.ToString());

                    if (DateTime.Now.DayOfYear < person.DOB.DayOfYear)
                    {
                        person.Age = int.Parse(person.Age.ToString()) - 1;
                    }

                    // the new person created is added to the list (ContactList)
                    ContactList.Add(person);
                }

                _counter++;
            }
            return;
        }

        public void Exit()
        {
            if (NumberOfContacts() == false)
            {
                System.Environment.Exit(0);
            }
            else if (NumberOfContacts() == true && ChangeMade == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("You have made changes to your contacts, would you like to save before exiting? [y/n]");
                m_answer = Console.ReadLine();
                if (m_errorChecking.EvulatuingYesOrNo(m_answer) == 1)
                {
                    // save to the user file and save to the dev file
                    SaveToUserFile();
                    SaveToDevFile();
                    // Exits out of the program
                    System.Environment.Exit(0);
                }
                System.Environment.Exit(0);
            }
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Wow!
        /// Basiclly the same thing as I had written before but in such an easier way
        /// </summary>
        //public void LoadContacts2()
        //{
        //    string[] FileContents = File.ReadAllLines(m_devFileLocation);

        //    for (int i = 0; i < FileContents.Length; i++)
        //    {
        //        string[] value = FileContents[i].Split('|');

        //        // saving the 
        //        m_firstName = value[0];
        //        m_lastName = value[1];
        //        int.TryParse(value[2], out m_monthBorn);
        //        int.TryParse(value[3], out m_dayBorn);
        //        int.TryParse(value[4], out m_yearBorn);
                    
        //        {   // save the person inside of the list Contacts

        //            Person person = new Person();

        //            //Assigning the properties for each person that is created inside of the class (person)
        //            person.FirstName = m_firstName;
        //            person.LastName = m_lastName;
        //            person.MonthBorn = m_monthBorn;
        //            person.DayBorn = m_dayBorn;
        //            person.YearBorn = m_yearBorn;
        //            person.DOB = new DateTime(person.YearBorn, person.MonthBorn, person.DayBorn);

        //            //subtracting the year now from the year supplied by the user
        //            person.Age = DateTime.Now.Year - int.Parse(person.DOB.Year.ToString());

        //            if (DateTime.Now.DayOfYear<person.DOB.DayOfYear)
        //            {
        //                person.Age = int.Parse(person.Age.ToString()) - 1;
        //            }

        //            //the new person created is added to the list (ContactList)
        //            ContactList.Add(person);
        //        }               
        //    }
        //}
    }


    /// <summary>
    /// This class holds the First name, Last name, and DOB properties for each person.
    /// </summary>
    public class Person
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MonthBorn { get; set; }
        public int DayBorn { get; set; }
        public int YearBorn { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
    }


    /// <summary>
    /// This class checks the data it is given from any class to what it is supposed to be.
    /// </summary>
    class ErrorChecking
    {
        // variables used by most of this class
        bool m_trueOrFalse; int m_userInput; int m_year; int m_month; int m_day;

        /// <summary>
        /// Error message if the user's input is not a number or a number that is not from 1 through 5.
        /// Comes from (Main method)
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public int EvaluateUserInput(string value)         
        {
            // if the user has enterd in (EXIT) or (exit)
            if (value == "EXIT" | value == "exit")
            {
                return 7;
            }

            // What is sent to this method (UserInput) will be parsed into an integer and put inside of the integer variable (_userInput)
            // if the process has worked or not, it will be put inside of the bool variable (trueOrFalse)
            m_trueOrFalse = int.TryParse(value, out m_userInput);

            // if the users input is not a number or it is a number that is not from 1 through 6
            if (m_trueOrFalse == false || m_userInput > 7 || m_userInput < 1)
            {
                return 0;
            }
            // return the user's input if it meets standards
            return m_userInput;
        }
        
        /// <summary>
        /// evaluates if the first and last names given are corrent or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string EvaluatingFirstAndLastName(string value)
        {            
            while (value.Contains("|") || value.Contains("[") || value.Contains("]") || value.Contains("<") || value.Contains(">") || value.Contains("{") || value.Contains("}") || value.Contains("/") || value.Contains("*"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No special characters are allowed in the name fields.\nPlease try again!");
                Console.ResetColor();
                Console.WriteLine();
                value = Console.ReadLine();
                continue;
            }
            return value;
        }

        /// <summary>
        /// Evaluates if the user's input is a number or a number from 1-2020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int EvaluatingYearBorn(string value)
        {
            // trying to parse the given string into an integer in the variable (_userInput)
            // if the process works or not it is put inside of the bool (m_trueOrFalse)
            m_trueOrFalse = int.TryParse(value, out m_year);

            // while the value given is not a number that is not between 1 - and the current year
            while (m_trueOrFalse == false || m_year < 1 || m_year > DateTime.Now.Year)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter in a correct year.");
                Console.ResetColor();
                value = Console.ReadLine();

                m_trueOrFalse = int.TryParse(value, out m_year);
                continue;
            }
            return m_year;
        }
        
        /// <summary>
        /// This method check if the supplied value is a number from 1-12
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int EvaluatingMonthBorn(string value)     
        {
            // trying to parse the given string into an integer in the variable (_userInput)
            // if the process works or not it is put inside of the bool (m_trueOrFalse)
            m_trueOrFalse = int.TryParse(value, out m_month);

            // while the value given is not a number or a number that is not between 1 - 12
            while (m_trueOrFalse == false || m_month < 1 || m_month > 12)
            {               
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter in a number 1 - 12 that represents the month the person was born.");
                Console.ResetColor();

                value = Console.ReadLine();
                m_trueOrFalse = int.TryParse(value, out m_month);
                continue;               
            }
            return m_month;
        }     

        /// <summary>
        /// This method cheks if the date given by the user is proper based of the year and the days in that month.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int EvaluatingDayBorn(string value, int year)
        {
            m_trueOrFalse = false;

            while (m_trueOrFalse == false)
            {
                m_trueOrFalse = int.TryParse(value, out m_day);

                if (!m_trueOrFalse || m_day < 1 || m_day > DateTime.DaysInMonth(year, m_month))                                                             
                {
                    // prints out error message
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter in the correct day of birth for the month you have choosen.");
                    Console.ResetColor();
                    m_trueOrFalse = false;
                    value = Console.ReadLine();
                    continue;
                }
                break;
            }

            return m_day;
        }

        /// <summary>
        /// This method checks the number supplied if it is betweeen the bonds of the list.
        /// </summary>
        /// <returns></returns>
        public int BoundsOfList(string value, int numberOfContacts)
        {
            int _userChoice;

            // The user gives a number for which person they pick
            int.TryParse(value, out _userChoice);

            while (true)
            {
                // if the input of the user is greater than 0 or is less than or equal to the number of contacts with one added
                if (_userChoice > 0 && _userChoice <= numberOfContacts)
                {
                    _userChoice = _userChoice - 1;
                    break;
                }

                // if the user's input is not a number from the choices provided then retry
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please enter in a number from the choices provided.");
                Console.ResetColor();

                int.TryParse(Console.ReadLine(), out _userChoice);
                continue;
            }
            return _userChoice;
        }

        /// <summary>
        /// This method evaluates the value it is given to see wether it is "EXIT" "EXIT" or "y" "Y" "n" "N"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int EvulatuingYesOrNo(string value)
        {
            while (true)           
            {
                // if the user's input is (EXIT) or (exit)
                if (value == "EXIT" | value == "exit")
                {
                    return 9;
                }
                else if (value == "y" || value == "Y")
                {
                    return 1;
                }
                else if (value == "n" || value == "N")
                {
                    return 0;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Please enter in [y/n] Or enter 'exit' to exit the program.");
                Console.ResetColor();

                value = Console.ReadLine();
                continue;
            }
        }
    }
}