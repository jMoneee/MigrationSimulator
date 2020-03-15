using System;

namespace FrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MigrationFramework fw = new MigrationFramework();

            Console.WriteLine("Initial population values: " + fw.getUsPop() + ", "  + fw.getFrPop());

            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine("Assume we want to specifically find the Population value for key 12, which is foreign high school graduates");
            Console.WriteLine("Foreign high school graduates:" + fw.getSpecificPopValue("frHighschool"));

            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine("Assume the player implements a policy that alters the population values by: US 1.1*, FR 0.8*");
            fw.implementNewPolicy(1.1f, 0.8f);
            Console.WriteLine("New population values: " + fw.getUsPop() + ", " + fw.getFrPop());
            Console.WriteLine("The new foreign high school graduates population: " + fw.getSpecificPopValue("frHighschool"));
            Console.WriteLine("The new US high school graduates population: " + fw.getSpecificPopValue("usHighschool"));

            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine("Assume a year has passed in the simulaton.");
            fw.yearlyPopUpdate();
            Console.WriteLine("New population values: " + fw.getUsPop() + ", " + fw.getFrPop());
            Console.WriteLine("The new foreign high school graduates population: " + fw.getSpecificPopValue("frHighschool"));
            Console.WriteLine("The new US high school graduates population: " + fw.getSpecificPopValue("usHighschool"));

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("End of simulation. Press any key to close console window.");
            Console.ReadLine();
        }
    }
}
