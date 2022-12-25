using System;
using System.Collections;
using System.Xml.Serialization;
using System.IO;



namespace Lab1
{

    class Program
    {
        static void Main()
        {
            //try
            {
                #region input
                Forest forest = new();
                Steppe steppe = new();
                Water water = new();

                Omnivore bear = new();
                bear.population = 10;
                bear.name = "Bear";

                Omnivore boar = new();
                boar.population = 80;
                boar.name = "Boar";

                Predator wolf = new();
                wolf.population = 50;
                wolf.name = "Wolf";

                Predator salmon = new();
                salmon.population = 140;
                salmon.name = "Salmon";

                Predator corsac = new();
                corsac.population = 15;
                corsac.name = "Corsac";

                Herbivore hare = new();
                hare.population = 150;
                hare.name = "Hare";

                Herbivore muskrat = new();
                muskrat.population = 20;
                muskrat.name = "Muskrat";

                Herbivore crustaceans = new();
                crustaceans.population = 10000;
                crustaceans.name = "Crustaceans";

                Herbivore vole = new();
                vole.population = 500;
                vole.name = "Vole";

                Herbivore jerboa = new();
                jerboa.population = 180;
                jerboa.name = "Jerboa";

                forest.add_animal(bear, 0);
                forest.add_animal(boar, 1);
                forest.add_animal(wolf, 2);
                Fauna[] list_forest_animal = forest.add_animal(hare, 3);


                steppe.add_animal(corsac, 0);
                steppe.add_animal(vole, 1);
                Fauna[] list_steppe_animal = steppe.add_animal(jerboa, 2);


                water.add_animal(salmon, 0);
                water.add_animal(muskrat, 1);
                Fauna[] list_water_animal = water.add_animal(crustaceans, 2);

                Herb yarrow = new();
                yarrow.population = 37000;
                yarrow.name = "Yarrow";

                Herb clover = new();
                clover.population = 37000;
                clover.name = "Clover";

                Herb dandelion = new();
                dandelion.population = 37000;
                dandelion.name = "Dandelion";

                Herb cane = new();
                cane.population = 37000;
                cane.name = "Cane";

                Herb cattail = new();
                cattail.population = 37000;
                cattail.name = "Cattail";

                Herb cornflower = new();
                cornflower.population = 37000;
                cornflower.name = "Cornflower";

                Herb sweet_clover = new();
                sweet_clover.population = 37000;
                sweet_clover.name = "Sweet clover";

                Bush blueberry = new();
                blueberry.population = 10000;
                blueberry.name = "Blueberry";

                Bush honeysuckle = new();
                honeysuckle.population = 10000;
                honeysuckle.name = "Honeysuckle";

                Tree rowan = new();
                rowan.population = 5000;
                rowan.name = "Rowan";

                Seaweed seaweed = new();
                seaweed.population = 65000;
                seaweed.name = "Seaweed";

                forest.add_green(yarrow, 0);
                forest.add_green(clover, 1);
                forest.add_green(dandelion, 2);
                forest.add_green(blueberry, 3);
                forest.add_green(honeysuckle, 4);
                Flora[] list_forest_green = forest.add_green(rowan, 5);

                steppe.add_green(cornflower, 0);
                Flora[] list_steppe_green = steppe.add_green(sweet_clover, 1);

                water.add_green(cane, 0);
                water.add_green(cattail, 1);
                Flora[] list_water_green = water.add_green(seaweed, 2);

                List<string> forest_specification = new List<string>()
            {
                "gray forest soil",
                "moderately cokd winter",
                "warm summer"
            };

                List<string> steppe_specification = new List<string>()
            {
                "black soil",
                "moderately cold winter",
                "sunny hot summer"
            };

                List<string> water_specification = new List<string>()
            {
                "fresh water",
                "the mouth of the mountain river"
            };

                Forest.Ob_code<string> objforest = new Forest.Ob_code<string>("rsTu0");
                Steppe.Ob_code<string> objsteppe = new Steppe.Ob_code<string>("tqi7Z");
                Water.Ob_code<string> objwater = new Water.Ob_code<string>("hgt52A");

                Forest_inf<Fauna> b = new();
                b.Add(bear);
                b.Add(boar);
                b.Add(wolf);
                b.Add(hare);
                b.Print_specification(0);
                #endregion


                int n = 0;
                Random rnd = new();

                while (n != 6)
                {
                    Console.WriteLine("\n Choose an action: 0. eating process, 1. cycle forward, 2. information about the area, 3. Sorting the forest list, 4. Serialization, 5. Test, 6. finish the program ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n == 0)
                    {
                        Console.WriteLine("Choose an area: 0. Forest, 1. Steppe, 2. Water ");
                        int area = Convert.ToInt32(Console.ReadLine());
                        if (area == 0)
                        {
                            Console.WriteLine("Who will eat? 0. Bear, 1.Boar, 2.Wolf, 3.Hare");
                            int animal = Convert.ToInt32(Console.ReadLine());
                            if (list_forest_animal[animal].population >= 1)
                            {
                                Console.WriteLine("What or who will be eaten? 1. Animal, 2.Plant");
                                int who_what = Convert.ToInt32(Console.ReadLine());
                                if ((who_what == 1) && (list_forest_animal[animal].name != "Hare"))
                                {
                                    Console.WriteLine("Who will be eaten? 0. Bear, 1.Boar, 2.Wolf, 3.Hare");
                                    int eaten_animal = Convert.ToInt32(Console.ReadLine());
                                    if (list_forest_animal[eaten_animal].population >= 1)
                                    {
                                        if ((list_forest_animal[eaten_animal].name == "Hare") || (rnd.Next(0, 10) > 5))
                                        {
                                            Console.WriteLine($"The {list_forest_animal[eaten_animal].name} is eaten!");
                                            list_forest_animal[eaten_animal].population -= 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"The {list_forest_animal[animal].name} is eaten!");
                                            list_forest_animal[animal].population -= 1;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_forest_animal[eaten_animal].name} (");
                                        list_forest_animal[eaten_animal].population += 10;
                                        Console.WriteLine("New animals introduced!");
                                    }
                                }
                                else if ((who_what == 1) && (list_forest_animal[animal].name == "Hare"))
                                {
                                    Console.WriteLine("Hares are herbivores!");
                                }
                                else if ((who_what == 2) && (list_forest_animal[animal].name == "Wolf"))
                                {
                                    Console.WriteLine("Wolves are carnivores!");
                                }
                                else
                                {
                                    Console.WriteLine("What will be eaten? 0. Yarrow, 1.Clover, 2.Dandelion, 3.Blueberry, 4.Honeysuckle, 5.Rowan");
                                    int eaten_grass = Convert.ToInt32(Console.ReadLine());
                                    if (list_forest_green[eaten_grass].population >= 1)
                                    {
                                        Console.WriteLine($"The {list_forest_green[eaten_grass].name} is eaten!");
                                        list_forest_green[eaten_grass].population -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_forest_green[eaten_grass].name} (");
                                        list_forest_green[eaten_grass].population += 100;
                                        Console.WriteLine("New grass introduced!");
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine($"There are no {list_forest_animal[animal].name} (");
                                list_forest_animal[animal].population += 10;
                                Console.WriteLine("New animals introduced!");
                            }
                        }
                        else if (area == 1)
                        {
                            Console.WriteLine("Who will eat? 0. Corsac, 1.Vole, 2.Jerboa");
                            int animal = Convert.ToInt32(Console.ReadLine());
                            if (list_steppe_animal[animal].population >= 1)
                            {
                                Console.WriteLine("What or who will be eaten? 1. Animal, 2.Plant");
                                int who_what = Convert.ToInt32(Console.ReadLine());
                                if ((who_what == 1) && (list_steppe_animal[animal].name == "Corsac"))
                                {
                                    Console.WriteLine("Who will be eaten? 1. Vole, 2.Jerboa");
                                    int eaten_animal = Convert.ToInt32(Console.ReadLine());
                                    if (list_steppe_animal[eaten_animal].population >= 1)
                                    {
                                        Console.WriteLine($"The {list_steppe_animal[eaten_animal].name} is eaten!");
                                        list_steppe_animal[eaten_animal].population -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_steppe_animal[eaten_animal].name} (");
                                        list_steppe_animal[eaten_animal].population += 10;
                                        Console.WriteLine("New animals introduced!");
                                    }
                                }
                                else if ((who_what == 1) && (list_steppe_animal[animal].name != "Corsac"))
                                {
                                    Console.WriteLine($"{list_steppe_animal[animal].name} are herbivores!");
                                }
                                else if ((who_what == 2) && (list_steppe_animal[animal].name == "Corsac"))
                                {
                                    Console.WriteLine("Corsac are carnivores!");
                                }
                                else
                                {
                                    Console.WriteLine("What will be eaten? 0. Cornflower, 1.Sweet clover");
                                    int eaten_grass = Convert.ToInt32(Console.ReadLine());
                                    if (list_steppe_green[eaten_grass].population >= 1)
                                    {
                                        Console.WriteLine($"The {list_steppe_green[eaten_grass].name} is eaten!");
                                        list_steppe_green[eaten_grass].population -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_steppe_green[eaten_grass].name} (");
                                        list_steppe_green[eaten_grass].population += 100;
                                        Console.WriteLine("New grass introduced!");
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine($"There are no {list_steppe_animal[animal].name} (");
                                list_steppe_animal[animal].population += 10;
                                Console.WriteLine("New animals introduced!");
                            }
                        }
                        else if (area == 2)
                        {
                            Console.WriteLine("Who will eat? 0. Salmon, 1.Muskrat, 2.Crustaceans");
                            int animal = Convert.ToInt32(Console.ReadLine());
                            if (list_water_animal[animal].population >= 1)
                            {
                                Console.WriteLine("What or who will be eaten? 1. Animal, 2.Plant");
                                int who_what = Convert.ToInt32(Console.ReadLine());
                                if ((who_what == 1) && (list_water_animal[animal].name == "Salmon"))
                                {
                                    Console.WriteLine("Who will be eaten? 2. Crustaceans");
                                    int eaten_animal = Convert.ToInt32(Console.ReadLine());
                                    if (list_water_animal[eaten_animal].population >= 1)
                                    {
                                        Console.WriteLine($"The {list_water_animal[eaten_animal].name} is eaten!");
                                        list_water_animal[eaten_animal].population -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_water_animal[eaten_animal].name} (");
                                        list_water_animal[eaten_animal].population += 10;
                                        Console.WriteLine("New animals introduced!");
                                    }
                                }
                                else if ((who_what == 1) && (list_water_animal[animal].name != "Salmon"))
                                {
                                    Console.WriteLine($"{list_water_animal[animal].name} are herbivores!");
                                }
                                else
                                {
                                    Console.WriteLine("What will be eaten? 0. Cane, 1.Cattail, 2.Seaweed");
                                    int eaten_grass = Convert.ToInt32(Console.ReadLine());
                                    if (list_water_green[eaten_grass].population >= 1)
                                    {
                                        Console.WriteLine($"The {list_water_green[eaten_grass].name} is eaten!");
                                        list_water_green[eaten_grass].population -= 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There are no {list_water_green[eaten_grass].name} (");
                                        list_water_green[eaten_grass].population += 100;
                                        Console.WriteLine("New grass introduced!");
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine($"There are no {list_water_animal[animal].name} (");
                                list_water_animal[animal].population += 10;
                                Console.WriteLine("New animals introduced!");
                            }
                        }

                    }
                    else if (n == 1)
                    {
                        Console.WriteLine("Press 0 to display today's population, 1 to display next year's population");
                        int act = Convert.ToInt32(Console.ReadLine());
                        if (act == 0)
                        {
                            Console.WriteLine("\n Forest animals");
                            for (int i = 0; i < list_forest_animal.Length; i++)
                            {
                                list_forest_animal[i].Print();
                            }
                            Console.WriteLine("\n Forest plants");
                            for (int i = 0; i < list_forest_green.Length; i++)
                            {
                                list_forest_green[i].Print();
                            }
                            Console.WriteLine("\n Steppe animals");
                            for (int i = 0; i < list_steppe_animal.Length; i++)
                            {
                                list_steppe_animal[i].Print();
                            }
                            Console.WriteLine("\n Steppe plants");
                            for (int i = 0; i < list_steppe_green.Length; i++)
                            {
                                list_steppe_green[i].Print();
                            }
                            Console.WriteLine("\n Water animals");
                            for (int i = 0; i < list_water_animal.Length; i++)
                            {
                                list_water_animal[i].Print();
                            }
                            Console.WriteLine("\n Water plants");
                            for (int i = 0; i < list_water_green.Length; i++)
                            {
                                list_water_green[i].Print();
                            }


                        }
                        else if (act == 1)
                        {
                            Console.WriteLine("\n Forest animals");
                            for (int i = 0; i < list_forest_animal.Length; i++)
                            {
                                list_forest_animal[i].Print_new();
                            }
                            Console.WriteLine("\n Forest plants");
                            for (int i = 0; i < list_forest_green.Length; i++)
                            {
                                list_forest_green[i].Print_new();
                            }
                            Console.WriteLine("\n Steppe animals");
                            for (int i = 0; i < list_steppe_animal.Length; i++)
                            {
                                list_steppe_animal[i].Print_new();
                            }
                            Console.WriteLine("\n Steppe plants");
                            for (int i = 0; i < list_steppe_green.Length; i++)
                            {
                                list_steppe_green[i].Print_new();
                            }
                            Console.WriteLine("\n Water animals");
                            for (int i = 0; i < list_water_animal.Length; i++)
                            {
                                list_water_animal[i].Print_new();
                            }
                            Console.WriteLine("\n Water plants");
                            for (int i = 0; i < list_water_green.Length; i++)
                            {
                                list_water_green[i].Print_new();
                            }
                            break;
                        }
                    }
                    else if (n == 2)
                    {
                        Console.WriteLine("Choose an area: 0. Forest, 1. Steppe, 2. Water ");
                        int area = Convert.ToInt32(Console.ReadLine());
                        if (area == 0)
                        {
                            IEnumerator forestEnumerator = forest_specification.GetEnumerator();
                            while (forestEnumerator.MoveNext())
                            {
                                string item = (string)forestEnumerator.Current;
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Object code: " + objforest.Object_code);
                        }
                        else if (area == 1)
                        {
                            IEnumerator steppeEnumerator = steppe_specification.GetEnumerator();
                            while (steppeEnumerator.MoveNext())
                            {
                                string item = (string)steppeEnumerator.Current;
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Object code: " + objsteppe.Object_code);
                        }
                        else if (area == 3)
                        {
                            IEnumerator waterEnumerator = water_specification.GetEnumerator();
                            while (waterEnumerator.MoveNext())
                            {
                                string item = (string)waterEnumerator.Current;
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Object code: " + objwater.Object_code);
                        }
                    }
                    else if (n == 3)
                    {
                        b.Sort((x, y) => x.population.CompareTo(y.population));
                        foreach (Fauna an in b)
                        {
                            Console.WriteLine(an.name);
                        }
                    }
                    else if (n == 4)
                    {
                        Serialization.ToXML(b);
                        Serialization.FromXML();
                    }
                    else if (n == 5)
                    {

                    }

                }
            }
            //catch
            //{
            // Logger<string>.WriteLog("Wow, error");
            //Console.WriteLine(Logger<string>.lastLine());
            //}
        }

    }



    public class Logger<K>
    {
        public static void WriteLog(K message)
        {
            string logPath = @"F:\log.txt";
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} :{message}");
            }

        }
        public static string lastLine()
        {
            return File.ReadLines(@"F:\log.txt").Last();
        }


    }

    public class Serialization
    {
        public static void ToXML(Forest_inf<Fauna> b)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Forest_inf<Fauna>));
            using (FileStream fs = new FileStream("fauna.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, b);
            }
        }
        public static void FromXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Forest_inf<Fauna>));
            using (FileStream fs = new FileStream("fauna.xml", FileMode.OpenOrCreate))
            {
                Forest_inf<Fauna>? new_list_animal = formatter.Deserialize(fs) as Forest_inf<Fauna>;

                if (new_list_animal != null)
                {
                    foreach (Fauna new_animal in new_list_animal)
                    {
                        Console.WriteLine($"Name: {new_animal.name} --- Population: {new_animal.population}");
                    }
                }
            }
        }
    }


    public class Area
    {
        public string name = "";
        public string country = "";

        public class Ob_code<T> where T : class
        {
            public T Object_code { get; set; }
            public Ob_code(T object_code)
            {
                Object_code = object_code;

            }
        }



    }

    //[XmlInclude(typeof(Omnivore))]
    [XmlInclude(typeof(Predator))]
    [XmlInclude(typeof(Herbivore))]
    [Serializable]
    public class Forest_inf<T> : IEnumerable<T>, IComparable<T> where T : Fauna
    {
        List<T> forest_specification = new List<T>();
        public void Add(T value)
        {
            forest_specification.Add(value);
        }

        public void Print_specification(int i)
        {
            Console.WriteLine(forest_specification[i].name);
        }

        public int Num(int i)
        {
            return forest_specification[i].population;
        }

        public int CompareTo(T? other)
        {
            throw new NotImplementedException();
        }

        public void Sort(Func<T, T, int> value)
        {
            forest_specification.Sort((x, y) => value(x, y));
        }


        public IEnumerator<T> GetEnumerator()
        {
            return forest_specification.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Forest : Area
    {
        Fauna[] list_forest_animal = new Fauna[4];

        public Fauna[] add_animal(Fauna animal, int i)
        {
            list_forest_animal[i] = animal;
            return list_forest_animal;
            //Console.WriteLine(list_forest_animal[i].name);
        }

        Flora[] list_forest_green = new Flora[6];
        public Flora[] add_green(Flora green, int i)
        {
            list_forest_green[i] = green;
            return list_forest_green;
            //Console.WriteLine(list_forest_green[i].name);
        }
    }

    public class Steppe : Area
    {
        Fauna[] list_steppe_animal = new Fauna[3];
        public Fauna[] add_animal(Fauna animal, int i)
        {
            list_steppe_animal[i] = animal;
            return list_steppe_animal;
            //Console.WriteLine(list_steppe_animal[i].name);
        }

        Flora[] list_steppe_green = new Flora[2];
        public Flora[] add_green(Flora green, int i)
        {
            list_steppe_green[i] = green;
            return list_steppe_green;
            //Console.WriteLine(list_steppe_green[i].name);
        }
    }

    public class Water : Area
    {
        Fauna[] list_water_animal = new Fauna[3];
        public Fauna[] add_animal(Fauna animal, int i)
        {
            list_water_animal[i] = animal;
            return list_water_animal;
            //Console.WriteLine(list_water_animal[i].name);
        }

        Flora[] list_steppe_green = new Flora[3];
        public Flora[] add_green(Flora green, int i)
        {
            list_steppe_green[i] = green;
            return list_steppe_green;
            //Console.WriteLine(list_steppe_green[i].name);
        }
    }

    [Serializable]
    public abstract class Fauna
    {
        public string name = "";
        public int population;
        public abstract void Print_new();
        public void Print()
        {
            Console.WriteLine($"Name: {name}  Population: {population}");
        }

    }
    [Serializable]
    public class Predator : Fauna
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Predator()
        {
            adding = rnd.Next(12, 16);
            loss = rnd.Next(11, 13);
            change = adding - loss;
        }

        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }
    [Serializable]
    public class Omnivore : Fauna
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Omnivore()
        {
            adding = rnd.Next(15, 19);
            loss = rnd.Next(13, 15);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {2 * change + population}");

        }
    }
    [Serializable]
    public class Herbivore : Fauna
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Herbivore()
        {
            adding = rnd.Next(50, 80);
            loss = rnd.Next(30, 40);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }


    public class Flora
    {
        public string name = "";
        public int population;
        public virtual void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {population}");
        }

        public void Print()
        {
            Console.WriteLine($"Name: {name}  Population: {population}");
        }
    }

    public class Seaweed : Flora
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Seaweed()
        {
            adding = rnd.Next(150, 300);
            loss = rnd.Next(80, 200);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }

    public class Herb : Flora
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Herb()
        {
            adding = rnd.Next(1000, 1500);
            loss = rnd.Next(700, 1200);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }

    public class Bush : Flora
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Bush()
        {
            adding = rnd.Next(1000, 1500);
            loss = rnd.Next(700, 1200);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }

    public class Tree : Flora
    {
        public Random rnd = new();
        private int adding;
        private int loss;
        private int change;
        public Tree()
        {
            adding = rnd.Next(100, 150);
            loss = rnd.Next(70, 120);
            change = adding - loss;
        }
        public override void Print_new()
        {
            Console.WriteLine($"Name: {name}  Population: {change + population}");

        }
    }


}
