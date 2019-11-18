using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalAdoptionCenter m_animalAdoptionCenter = new AnimalAdoptionCenter();
            DenverZoo(m_animalAdoptionCenter);
            SanFranZoo(m_animalAdoptionCenter);
            AtlantaZoo(m_animalAdoptionCenter);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("What baby would you like to have?");
                string m_babyAnimalBorn = Console.ReadLine();
                m_animalAdoptionCenter.m_babyAnimal = m_babyAnimalBorn;
                Console.WriteLine();

                Console.WriteLine("Which Zoo should have the baby? \nDenver Zoo, San Fran Zoo, or Atlanta Zoo ?");
                string m_zooWhoHasBaby = Console.ReadLine();
                m_animalAdoptionCenter.m_zooWhoHasBaby = m_zooWhoHasBaby;
                Console.WriteLine();
                
                m_animalAdoptionCenter.FireEvent();

                Console.WriteLine("Would you like to have another baby?  Answer Yes or No.");
                string m_answer = Console.ReadLine();
                if (m_answer == "Yes")
                {
                    continue;
                }
                else if (m_answer == "No")
                {
                    break;
                }
            }
        }
        private void notes()
        {
            // 2 zoos whant the same baby?
            // show the want and need at first then at the end

            /*
            * there are a number of zoos
            * they have an array of animals that they already have
            * they have an array of animals that they want
            * when a zoo has a baby they need to make an annoucment (fire an event) so all other zoos know
            * if another zoo wants it they say I want your animal
            * if the same animal is born a second time then the want is changed for the zoo that got the animal
            * or maybe no one wants your baby
            * */
        }

        private static void DenverZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo DenverZoo = new Zoo(m_animalAdoptionCenter);
            DenverZoo.HasAnimals = new string[] { "Kangroo", "Monkey", "Snake" };
            DenverZoo.WantsAnimals = new string[] { "Giraffe", "Scorpion", "Sloth", "Panda" };
            DenverZoo.zooName = "Denver Zoo";
        
        }

        private static void SanFranZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo SanFranZoo = new Zoo(m_animalAdoptionCenter);
            SanFranZoo.HasAnimals = new string[] { "Tiger", "Bear", "Elk" };
            SanFranZoo.WantsAnimals = new string[] { "Eel", "Raccoon", "Elephant" };
            SanFranZoo.zooName = "San Fran Zoo";
        }

        private static void AtlantaZoo(AnimalAdoptionCenter m_animalAdoptionCenter)
        {
            Zoo AtlantaZoo = new Zoo(m_animalAdoptionCenter);
            AtlantaZoo.HasAnimals = new string[] { "Deer", "Peacock", "Panda" };
            AtlantaZoo.WantsAnimals = new string[] { "Zebra", "Spider", "Hippo" };
            AtlantaZoo.zooName = "Atlanta Zoo";
        }
    }

    public class Zoo
    {
        public AnimalAdoptionCenter m_animalAdoptionCenter;

        public string[] HasAnimals;
        public string[] WantsAnimals;
        public string zooName;
        public string zooWhoHasBaby;
        string[] HasAnimals2;

        // Zoo Constructor
        public Zoo(AnimalAdoptionCenter animalAdoptionCenter)
        {
            m_animalAdoptionCenter = animalAdoptionCenter;
            m_animalAdoptionCenter.IWantAnAnimalEvent += ZooSubscriber;
        }

        // Zoo Subscriber
        public void ZooSubscriber(object sender, EventArgs e)
        {
            AnimalAdoptionCenter animalAdoptionCenter = sender as AnimalAdoptionCenter;

            if (animalAdoptionCenter.m_zooWhoHasBaby == zooName)
            {
                Console.WriteLine("Cogratulations " + zooName + " just had a baby " + animalAdoptionCenter.m_babyAnimal);

                // the new (Has Animals) array is given a size of the original has animals array plus one for the new animal to be moved from want to have
                HasAnimals2 = new string[HasAnimals.Length + 1];

                for (int i = 0; i < WantsAnimals.Length; i++)
                {
                    if (animalAdoptionCenter.m_babyAnimal == WantsAnimals[i])
                    {         
                        Console.WriteLine(zooName + " will keep their baby.");

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
                }
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
                return;
            }

            for (int i = 0; i < WantsAnimals.Length; i++)
            {
                if (animalAdoptionCenter.m_babyAnimal == WantsAnimals[i])
                {
                    Console.WriteLine(zooName + " would like to have your baby " + animalAdoptionCenter.m_babyAnimal);
                    WantsAnimals[i] = null;

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
                    return;
                }
            }
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
                return;
            }
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

        public void FireEvent()
        {
            if (IWantAnAnimalEvent != null)
            {
                IWantAnAnimalEvent(this, EventArgs.Empty);
            }
        }
    }

    public class test
    {
        public test()
        {
            List<string> ls = new List<string>();
            ls.Add("Hello");

            for (int i = 0; i < ls.Capacity; i++)
            {
                //Console.WriteLine(i);
                //Console.WriteLine(ls[i]);
            }
        }
    }
}    
