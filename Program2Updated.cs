using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tWelcome to sydney hotel");
            int i = 0;
            string[] name = new string[20];
            int[] night = new int[20];
            string[] roomservice = new string[20];
            double[] costlist = new double[20];

            while (true)
            {
                Console.WriteLine("Enter Customer Name:");
                string Name = Console.ReadLine();
                name[i] = Name;
                
                Console.WriteLine("Enter Number of night:");
                int NumberOfnight = 0;

                while (true)
                {
                    // CHANGE 1: Switched from int.Parse to int.TryParse to prevent the program from 
                    // crashing if the user enters non-numeric text.
                    bool isValidInput = int.TryParse(Console.ReadLine(), out NumberOfnight);

                    if (isValidInput && NumberOfnight >= 1 && NumberOfnight <= 20)
                    {
                        night[i] = NumberOfnight;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Nights must be a number between 1 and 20:");
                    }
                }

                Console.WriteLine("Enter yes/no to indicate whether you want room service:");
                string roomService = Console.ReadLine();
                roomservice[i] = roomService;
                
                double cost = 0;
                if (NumberOfnight >= 1 && NumberOfnight <= 3)
                {
                    cost = NumberOfnight * 100;
                }
                else if (NumberOfnight >= 4 && NumberOfnight <= 10)
                {
                    cost = NumberOfnight * 80.5;
                }
                else
                {
                    cost = NumberOfnight * 75.3;
                }

                if (roomService.ToLower() == "yes")
                {
                    cost = cost + (cost * .10);
                }
                costlist[i] = cost;

                Console.WriteLine("Total price for " + Name + " is $" + cost);
                i = i + 1;

                Console.WriteLine("________________________________________");
                Console.WriteLine("Press q to exit Or press any other key to continue:");
                string choice = Console.ReadLine();
                if (choice == "q" || choice == "Q")
                {
                    break;
                }

                Console.WriteLine("________________________________________");
            }

            Console.WriteLine("\t\t\tSummery of reservation");
            Console.WriteLine("Name\t\t\tNumber of room\t\tRoom service\t\tCharge");
            for (int j = 0; j < i; j++)
            {
                // CHANGE 2: Used String Interpolation with currency formatting (:C) 
                // to display the charge cleanly with two decimal places and a currency symbol.
                Console.WriteLine($"{name[j]}\t\t\t{night[j]}\t\t\t{roomservice[j]}\t\t{costlist[j]:C}");
            }

            double largest = costlist[0];
            int ind = 0;
            for (int j = 1; j < i; j++)
            {
                if (largest < costlist[j])
                {
                    largest = costlist[j];
                    ind = j;
                }
            }
            
            Console.WriteLine("Customer spending the most is " + name[ind] + " $" + costlist[ind]);
            
            double min = costlist[0];
            int ind2 = 0;
            for (int j = 1; j < i; j++)
            {
                if (min > costlist[j])
                {
                    min = costlist[j];
                    ind2 = j;
                }
            }

            Console.WriteLine("Customer spending the least is " + name[ind2] + " $" + costlist[ind2]);
        }
    }
}