using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //   string file = "Tickets.csv";
            //   StreamReader sr = new StreamReader(file);
            //     List<string> originalFile = new List<string>();
            //     while (!sr.EndOfStream)
            //     {
            //         originalFile.Add(sr.ReadLine());
                    
            //     }
            //     sr.Close();

            TicketManager manager = new TicketManager("Tickets.csv");
            manager.loadTicketsFromFile();

              string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from CSV file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // TODO: read data from file
                     // create file from data
                     // read data from file
                    manager.listTickets();
                    manager.createTicket();
                }
                else if (choice == "2")
                {
                    
                    manager.writeTicketsToFile();
                    
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
