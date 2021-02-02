using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
              string file = "Tickets.csv";
              StreamReader sr = new StreamReader(file);
                List<string> originalFile = new List<string>();
                while (!sr.EndOfStream)
                {
                    originalFile.Add(sr.ReadLine());
                    
                }
                sr.Close();

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
                    if (File.Exists(file))
                    {
                     
                        // read data from file
                        StreamReader sr1 = new StreamReader(file);
                        //Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");

                        while (!sr1.EndOfStream)
                        {
                            string line = sr1.ReadLine();
                            //Console.WriteLine(line);
                            // convert string to array
                            string[] arr = line.Split(',');
                         
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                            arr[0],arr[1] , arr[2] , arr[3] , arr[4],arr[5], arr[6]);
                            // add to accumulators
                        }
                        sr1.Close();
                        
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    
                    // TODO: create file from data
                    StreamWriter sw = new StreamWriter(file);
    
                    Console.WriteLine("Do you want to create more data?(Y/N)");
                    string resp = Console.ReadLine().ToUpper();

                    if (resp != "Y") { break; }
                    // ask a question
                    Console.WriteLine("What is the TicketID (Type only number)?");
                    // input the response
                    int ticketID = Convert.ToInt32(Console.ReadLine());                        
                    
                    Console.WriteLine("Enter a summary.");                        
                    string summary = Console.ReadLine();

                    
                    Console.WriteLine("Enter the status(Open/Close)");
                    string status = Console.ReadLine();
                    
                    Console.WriteLine("Enter the priority");   
                    string priority = Console.ReadLine();

                    Console.WriteLine("Enter the submitter");
                    string submitter = Console.ReadLine();

                    Console.WriteLine("Enter the assigned");
                    string assigned = Console.ReadLine();

                    Console.WriteLine("Enter the watching");
                    string watching = Console.ReadLine();
                    
                    originalFile.Add(ticketID + "," + summary + "," + status + "," + priority + "," + submitter + "," + assigned + "," + watching);

                    foreach (var line in originalFile) {
                        sw.WriteLine(line);
                    }
                    
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
