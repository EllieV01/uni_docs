using NUnit.Framework;
using Lab1;

namespace TestProject1
{
    public class Tests
    {
        Forest_inf<Fauna> forest_inf;
        Omnivore bear;
        Predator wolf;


        [SetUp]
        public void Setup()
        {
            forest_inf = new Forest_inf<Fauna>();
            bear = new Omnivore();
            bear.population = 10;
            bear.name = "Bear";
            wolf = new Predator();
            wolf.population = 50;
            wolf.name = "Wolf";
            
        }


        [Test]
        public void Test1()
        {
            forest_inf.Add(wolf);
            Assert.NotNull(forest_inf.Num(0));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(10, bear.population);
        }

        [Test]
        public void Test3()
        {
            forest_inf.Add(wolf);
            Assert.AreNotSame(wolf.name, bear.name);
        }

        [Test]
        public void Test4()
        {
            forest_inf.Add(wolf);
            forest_inf.Add(bear);
            forest_inf.Sort((x, y) => x.population.CompareTo(y.population));
            Assert.Less(forest_inf.Num(0), forest_inf.Num(1));
        }

    }
}

