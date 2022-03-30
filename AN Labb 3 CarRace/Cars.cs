using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AN_Labb_3
{
    public class Car
    {
        private Thread CarThread;
        public string CarName { get; set; }

        public int SpeedKmh { get; set; } = 120;

        public int Distance { get; set; } = 0;

        public static int FinishOrder { get; set; }
        public static void Placement(string carName)
        {
            if (FinishOrder == 1)
                Console.WriteLine($"{DateTime.Now:T}: {carName} finished number [{FinishOrder}], AND BECOMES THE NEW WORLD CHAMPION!");
            else
                Console.WriteLine($"{DateTime.Now:T}: {carName} finished number [{FinishOrder}] ");
        }


        public Car(string carname)
        {
            CarName = carname;
            CarThread = new Thread(Drive);
        }
        internal void Start()
        {
            CarThread.Start();
        }

        public List<int> Report()
        {
            return new List<int>() { SpeedKmh, Distance };
        }


        private void Drive()
        {
            Random random = new Random();
            Console.WriteLine($"{DateTime.Now:T}: {CarName} has pulled off with a great start!");

            for (int i = 1; i <= 500; i++)
            {
                Thread.Sleep(1000);
                Distance = SpeedKmh * i;


                if (Distance >= 10000)
                {
                    FinishOrder++;
                    Placement(CarName);
                    break;
                }
                if (i % 10 == 0) // styr hur ofta ett problem ska hända, atm var 10 sekund
                {
                    int problem = random.Next(1, 51);
                    if (problem < 9)
                        Problem(problem);
                    else if (problem >= 9 && problem <= 19)
                    {
                        int newSpeed = SpeedKmh - 10;
                        Console.WriteLine($"{DateTime.Now:T}: {CarName} Minor DRS problems, speed will be down 10km/h from [{SpeedKmh}km/h] to [{newSpeed}km/h].");
                        SpeedKmh = newSpeed;
                        if (SpeedKmh == 0)
                        {
                            Console.WriteLine($"{DateTime.Now:T}: {CarName} Has got some engine problems! Car will have to DNF");
                            i = 500;
                        }
                    }
                }
            }
        }


        void Problem(int problem)
        {

            switch (problem)
            {
                case int a when (a == 1):
                    Console.WriteLine($"{DateTime.Now:T}: {CarName} Have to pit for gas, loses 30 seconds in pitlane");
                    Thread.Sleep(30000);
                    break;
                case int a when (a == 2 && a == 3):
                    Console.WriteLine($"{DateTime.Now:T}: {CarName} Have to change rubber for better grip, 20 second pitstop");
                    Thread.Sleep(20000);
                    break;
                case int a when (a >= 4 && a <= 9):
                    Console.WriteLine($"{DateTime.Now:T}: {CarName} Spun out of track and loses 10 second getting back on the grid");
                    Thread.Sleep(10000);
                    break;
                default:
                    break;
            }


        }
    }

}