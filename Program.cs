using System;

namespace Zoo
{
    public class Program
    {
        public static void Main(string[] args)
        {   // creating an instance of the Animal Adoption Center
            AnimalAdoptionCenter m_animalAdoptionCenter = new AnimalAdoptionCenter();

            // creating the zoos
            DenverZoo(m_animalAdoptionCenter);
            SanFranZoo(m_animalAdoptionCenter);
            AtlantaZoo(m_animalAdoptionCenter);
            
            // enable this (Boston Zoo) if you want to expirement yourself! :)
            //BostonZoo(m_animalAdoptionCenter);
            while (true)
            {   // asking the user what baby should be born and sending it to the animal adoption center
                Console.WriteLine();
                Console.WriteLine("What baby would you like to have?");
                string m_babyAnimalBorn = Console.ReadLine();
                m_animalAdoptionCenter.m_babyAnimal = m_babyAnimalBorn;
                Console.WriteLine();

                //asking the user who should have the baby and sending it to the animal adoption center
                Console.WriteLine("Which Zoo should have the baby? \nDenver Zoo, San Fran Zoo, or Atlanta Zoo ?");
                string m_zooWhoHasBaby = Console.ReadLine();
                m_animalAdoptionCenter.m_zooWhoHasBaby = m_zooWhoHasBaby;
                Console.WriteLine();
                
                // firing the event
                m_animalAdoptionCenter.FireEvent();

                // asks the user if they want to have another baby then either continues or ends
                Console.WriteLine("Would you like to have another baby?  Answer Yes or No.");
                string m_answer = Console.ReadLine();
                if (m_answer == "Yes")
                {
                    m_animalAdoptionCenter.TakeBaby = 0;
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        
        private static void BostonZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo BostonZoo = new Zoo(m_animalAdoptionCenter);
        }

        // method for the Denver Zoo that sends the animal adoption center to it and sets the has and want list and sends the name of the zoo to its class
        private static void DenverZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo DenverZoo = new Zoo(m_animalAdoptionCenter);
            DenverZoo.HasAnimals = new string[] { "Kangroo", "Monkey", "Snake" };
            DenverZoo.WantsAnimals = new string[] { "Giraffe", "Scorpion", "Panda" };
            DenverZoo.zooName = "Denver Zoo";
        
        }

        // method for the San Fran Zoo that sends the animal adoption center to it and sets the has and want list and sends the name of the zoo to its class
        private static void SanFranZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo SanFranZoo = new Zoo(m_animalAdoptionCenter);
            SanFranZoo.HasAnimals = new string[] { "Tiger", "Bear", "Elk" };
            SanFranZoo.WantsAnimals = new string[] { "Eel", "Raccoon", "Elephant", "Sloth" };
            SanFranZoo.zooName = "San Fran Zoo";
        }

        // method for the Atlanta Zoo that sends the animal adoption center to it and sets the has and want list and sends the name of the zoo to its class
        private static void AtlantaZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo AtlantaZoo = new Zoo(m_animalAdoptionCenter);
            AtlantaZoo.HasAnimals = new string[] { "Deer", "Peacock", "Panda" };
            AtlantaZoo.WantsAnimals = new string[] { "Zebra", "Spider", "Hippo", "Sloth"};
            AtlantaZoo.zooName = "Atlanta Zoo";
        }
    } 

    public class Zoo
    {
        AnimalAdoptionCenter m_animalAdoptionCenter;

        // creating the has, want and has2 arrays with the zoo name string.
        public string[] HasAnimals;
        public string[] WantsAnimals;
        string[] HasAnimals2;
        public string zooName;        

        // Zoo Constructor
        public Zoo(AnimalAdoptionCenter animalAdoptionCenter)
        {
            // giving anotherl developer what is needed for the program
            // if the supplied argument is null
            if (animalAdoptionCenter == null)
            {
                // manually creation an error to stop the execution. 
                throw new ArgumentNullException("animalAdoptionCenter");
            }

            m_animalAdoptionCenter = animalAdoptionCenter;
            // subscribing to the event with the method (ZooSubscriber)
            m_animalAdoptionCenter.IWantAnAnimalEvent += ZooSubscriber;
        }

        // the zoo Subscriber
        public void ZooSubscriber(object sender, EventArgs e)
        {
            // if the array is null
            if (WantsAnimals == null)
            {
                // manually creating an error to stop the execution. 
                // this error helps another developer to know what is needed to create a zoo
                throw new ApplicationException("WantsAnimals");
            }
            // the WantsAnimals array needs to be set

            // if the supplied argument is null
            if (HasAnimals == null)
            //the animal adoption center in this class is equal to the one passed down
            {
                // manually creating an error to stop the execution.
                // this error helps another developer to know what is needed to create a zoo
                throw new ApplicationException("HasAnimals");
            }
            // the HasAnimals array needs to be set

            AnimalAdoptionCenter animalAdoptionCenter = sender as AnimalAdoptionCenter;

            // if the zoo that has the baby is the same zoo as the one going through this class right now
            if (animalAdoptionCenter.m_zooWhoHasBaby == zooName)
            {
                Console.WriteLine("Cogratulations " + zooName + " just had a baby " + animalAdoptionCenter.m_babyAnimal);
                // the new (Has Animals) array is given a size of the original has animals array plus one for the new animal to be moved from want to have
                HasAnimals2 = new string[HasAnimals.Length + 1];

                for (int i = 0; i < WantsAnimals.Length; i++)
                {
                    if (animalAdoptionCenter.m_babyAnimal == WantsAnimals[i])
                    {
                        if (animalAdoptionCenter.TakeBaby == 0)
                        {
                            Console.WriteLine(zooName + " will keep their baby.");
                            animalAdoptionCenter.TakeBaby = 1;

                            // The animal in the (WantsAnimals) array is made null
                            WantsAnimals[i] = null;

                            // introduces the original (HasAnimals) array
                            for (int m = 0; m < HasAnimals.Length; m++)
                            {
                                for (int k = 0; k < HasAnimals2.Length; k++)
                                {
                                    // (HasAnimals2) becomes (HasAnimals) from the index of (HasAnimals) because that index is at a constate rate
                                    HasAnimals2[m] = HasAnimals[m];

                                    // (lastIndex) gets the highest index the array (HasAnimals2) has.
                                    int lastIndex1 = HasAnimals2.GetUpperBound(0);
                                    // the last index in the array (HasAnimals2) would equal the baby animal born
                                    HasAnimals2[lastIndex1] = m_animalAdoptionCenter.m_babyAnimal;

                                    break;
                                }
                            }
                            // the old (HasAnimals) is equal to the new (HasAnimals2)
                            HasAnimals = HasAnimals2;
                        }
                        else if (animalAdoptionCenter.TakeBaby == 1)
                        {
                            Console.WriteLine(zooName + " will take the baby " + m_animalAdoptionCenter.m_babyAnimal + " another time");
                        }
                    }
                }
                // printing what is the new version of the has and want list
                {
                    Console.WriteLine();
                    Console.WriteLine(zooName + " has");
                    for (int i = 0; i < HasAnimals.Length; i++)
                    {
                        Console.WriteLine(HasAnimals[i]);
                    }
                    Console.WriteLine(zooName + " wants");
                    for (int i = 0; i < WantsAnimals.Length; i++)
                    {
                        Console.WriteLine(WantsAnimals[i]);
                    }
                    Console.WriteLine();
                }
                
                return;
            }

            for (int i = 0; i < WantsAnimals.Length; i++)
            {
                if (animalAdoptionCenter.m_babyAnimal == WantsAnimals[i] )
                {
                    if (animalAdoptionCenter.TakeBaby == 0)
                    {
                        Console.WriteLine(zooName + " would like to have your baby " + animalAdoptionCenter.m_babyAnimal);
                        WantsAnimals[i] = null;
                        animalAdoptionCenter.TakeBaby = 1;

                        // the new (Has Animals) array is given a size of the original has animals array plus one for the new animal to be moved from want to have
                        HasAnimals2 = new string[HasAnimals.Length + 1];

                        // introduces the original (HasAnimals) array
                        for (int m = 0; m < HasAnimals.Length; m++)
                        {
                            for (int k = 0; k < HasAnimals2.Length; k++)
                            {
                                // (HasAnimals2) becomes (HasAnimals) from the index of (HasAnimals) because that index is at a constate rate
                                HasAnimals2[m] = HasAnimals[m];

                                // (lastIndex) gets the highest index the array (HasAnimals2) has.
                                int lastIndex1 = HasAnimals2.GetUpperBound(0);
                                // the last index in the array (HasAnimals2) would equal the baby animal born
                                HasAnimals2[lastIndex1] = m_animalAdoptionCenter.m_babyAnimal;

                                break;
                            }
                        }
                        // the old (HasAnimals) is equal to the new (HasAnimals2)
                        HasAnimals = HasAnimals2;
                    }
                    else if (animalAdoptionCenter.TakeBaby == 1)
                    {
                        Console.WriteLine(zooName + " will take the baby " + m_animalAdoptionCenter.m_babyAnimal + " another time");
                    }

                    // printing what is the new version of the has and want list
                    {
                        Console.WriteLine();
                        Console.WriteLine(zooName + " has");
                        for (int h = 0; h < HasAnimals.Length; h++)
                        {
                            Console.WriteLine(HasAnimals[h]);
                        }
                        Console.WriteLine(zooName + " wants");
                        for (int w = 0; w < WantsAnimals.Length; w++)
                        {
                            Console.WriteLine(WantsAnimals[w]);
                        }
                        Console.WriteLine();
                    }                   
                    return;
                }
            }

            // printing what is the new version of the has and want list
            {               
                Console.WriteLine("Currently, the " + zooName + " does not want your baby");
                Console.WriteLine();
                Console.WriteLine(zooName + " has");
                for (int i = 0; i < HasAnimals.Length; i++)
                {
                    Console.WriteLine(HasAnimals[i]);
                }
                Console.WriteLine(zooName + " wants");
                for (int i = 0; i < WantsAnimals.Length; i++)
                {
                    Console.WriteLine(WantsAnimals[i]);
                }
                Console.WriteLine();               
            }
            return;
        }
    }

    public class AnimalAdoptionCenter
    {
        // the event
        public event EventHandler IWantAnAnimalEvent;

        // the Zoo who has the baby
        public string m_zooWhoHasBaby;

        // the baby animal that is born
        public string m_babyAnimal;

        // field that checks if the baby born has been taken 0 = avaliable, 1 = taken.
        public int TakeBaby;

        // the firing of the mevent
        public void FireEvent()
        {
            if (IWantAnAnimalEvent != null)
            {
                IWantAnAnimalEvent(this, EventArgs.Empty);
            }
        }
    } 
}    
