using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN_Labb_3
{
    public class Program
    {
        static void Main(string[] args)
        {

            Car car1 = new Car("Max Verstappen");
            Car car2 = new Car("Lewis Hamilton");
            Car car3 = new Car("Anas Qlok");


            List<Car> carList = new List<Car>();
            carList.Add(car1);
            carList.Add(car2);
            carList.Add(car3);

            Console.WriteLine("Ready");
            Thread.Sleep(1000);
            Console.WriteLine("Set");
            Thread.Sleep(1000);
            Console.WriteLine("GO!");
            Thread.Sleep(1000);

            StartRace(carList);

            while (true)
            {
                if (Console.ReadLine() == "report")
                {
                    Console.WriteLine("Race Report");
                    Console.WriteLine($"{DateTime.Now:T}: {car1.CarName} Speed: [{car1.Report()[0]}], Distance driven: [{car1.Report()[1]}].");
                    Console.WriteLine($"{DateTime.Now:T}: {car2.CarName} Speed: [{car2.Report()[0]}], Distance driven: [{car2.Report()[1]}].");
                    Console.WriteLine($"{DateTime.Now:T}: {car3.CarName} Speed: [{car3.Report()[0]}], Distance driven: [{car3.Report()[1]}].");
                    Console.WriteLine(" ");
                }
            }

        }

        static void StartRace(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Start();
            }

        }
    }
}
