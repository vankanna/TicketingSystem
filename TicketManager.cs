using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class TicketManager
    {
        List<Ticket> Tickets = new List<Ticket>();
        string fileName;
        string headers;

        public TicketManager(string fileName) 
        {
            this.fileName = fileName;
        }

        public void loadTicketsFromFile()
        {
            if (File.Exists(this.fileName))
            {
                StreamReader sr1 = new StreamReader(this.fileName);
                Boolean firstLine = true;
                while (!sr1.EndOfStream)
                {

                    string line = sr1.ReadLine();
                    if(firstLine) {
                        this.headers = line;
                        firstLine = false;
                    } else {
                    string[] arr = line.Split(',');
        
                        this.Tickets.Add(new Ticket(
                            Int32.Parse(arr[0]),
                            arr[1],
                            arr[2],
                            arr[3],
                            arr[4],
                            arr[5],
                            this.createWatchersFromString(arr[6])));
                    }
                }
                sr1.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        public void writeTicketsToFile()
        {
            if (File.Exists(this.fileName))
            {
                StreamWriter sw = new StreamWriter(this.fileName);
                sw.WriteLine(this.headers);
                foreach (var ticket in this.Tickets)
                {
                    sw.WriteLine(ticket.formatTicket());
                }
                sw.Close();
            }
        }

        public void listTickets() {
            Console.WriteLine("\n" + this.headers);
            foreach (var ticket in this.Tickets) {
                        Console.WriteLine(ticket.formatTicket());
                }
        }

        public void createTicket() {

            Console.WriteLine("Enter a summary");                        
            string summary = Console.ReadLine();


            Console.WriteLine("Enter the status (Open/Closed)");
            string status = Console.ReadLine();

            Console.WriteLine("Enter the priority (Low/Medium/High)");   
            string priority = Console.ReadLine();

            Console.WriteLine("Enter the submitter");
            string submitter = Console.ReadLine();

            Console.WriteLine("Enter the assigned");
            string assigned = Console.ReadLine();

            Console.WriteLine("Enter the watching");
            List<string> watchers = new List<string>();
            string watching = Console.ReadLine();
            // while loop to add more
            watchers.Add(watching);
            this.Tickets.Add(new Ticket(
                this.Tickets[this.Tickets.Count - 1].ticketId + 1,
                summary,
                status,
                priority,
                submitter,
                assigned,
                watchers
            ));
        }

        public List<string> createWatchersFromString(string watchers) {
            string[] watchersArry = watchers.Split('|');
            List<string> watchersList = new List<string>(watchersArry);
            return watchersList;
        }
        
    }

}