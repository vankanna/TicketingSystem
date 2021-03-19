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

        public void createTicketOld() {

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
        }

        public void createTicket() {

            bool ask = true;

            while(ask) {
                ask = false;
                Console.WriteLine("Please choose ticket type:\n 1. Bug\n 2. Task\n 3. Enhancment");
                string choice = Console.ReadLine();

                // BASE PORTION
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

                if ( choice == "1") {
                    ask = false;
                    Console.WriteLine("Enter a severity (Low/Medium/High)");                        
                    string severity = Console.ReadLine();
                    BugTicket bugTicket = new BugTicket();
                    bugTicket.ticketId = this.Tickets[this.Tickets.Count - 1].ticketId + 1;
                    bugTicket.summary = summary;
                    bugTicket.status = status;
                    bugTicket.priority = priority;
                    bugTicket.submitter = submitter;
                    bugTicket.assigned = assigned;
                    bugTicket.watchers = watchers;
                    bugTicket.severity = severity;
                    this.Tickets.Add(bugTicket);
                } else if (choice == "2") {
                    ask = false;
                    Console.WriteLine("Enter a project name");                        
                    string projectName = Console.ReadLine();
                    Console.WriteLine("Enter a due date");                        
                    string dueDate = Console.ReadLine();
                    TaskTicket taskTicket = new TaskTicket();
                    taskTicket.ticketId = this.Tickets[this.Tickets.Count - 1].ticketId + 1;
                    taskTicket.summary = summary;
                    taskTicket.status = status;
                    taskTicket.priority = priority;
                    taskTicket.submitter = submitter;
                    taskTicket.assigned = assigned;
                    taskTicket.watchers = watchers;
                    taskTicket.projectName = projectName;
                    taskTicket.dueDate = dueDate;
                    this.Tickets.Add(taskTicket);
                } else if (choice == "3") {
                    ask = false;
                    Console.WriteLine("Enter software");                        
                    string software = Console.ReadLine();
                    Console.WriteLine("Enter the cost");                        
                    int cost = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a reason");                        
                    string reason = Console.ReadLine();
                    EnhancementTicket enhancementTicket = new EnhancementTicket();
                    enhancementTicket.ticketId = this.Tickets[this.Tickets.Count - 1].ticketId + 1;
                    enhancementTicket.summary = summary;
                    enhancementTicket.status = status;
                    enhancementTicket.priority = priority;
                    enhancementTicket.submitter = submitter;
                    enhancementTicket.assigned = assigned;
                    enhancementTicket.watchers = watchers;
                    enhancementTicket.software = software;
                    enhancementTicket.cost = cost;
                    enhancementTicket.reason = reason;
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