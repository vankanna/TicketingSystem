using System;
using System.IO;
using System.Collections.Generic;


namespace TicketingSystem
{
    class TicketManager
    {
        List Tickets = new List();
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

            bool ask = true;

            while(ask) {
                ask = false;
                Console.WriteLine("Please choose ticket type:\n 1. Bug\n 2. Task\n 3. Enhancment");
                string choice = Console.ReadLine();

                
                

                if ( choice == "1") {
                    ask = false;
                    //this.Tickets[this.Tickets.Count - 1].ticketId + 1;
                    this.Tickets.Add(bugTicket);
                } else if (choice == "2") {
                    ask = false;
                    
                    this.Tickets.Add(taskTicket);
                } else if (choice == "3") {
                    ask = false;
                    
                    this.Tickets.Add(enhancementTicket);

                } else {
                    ask = true;
                }
            }
             
        }

        public List<string> createWatchersFromString(string watchers) {
            string[] watchersArry = watchers.Split('|');
            List<string> watchersList = new List<string>(watchersArry);
            return watchersList;
        }
        
    }

}