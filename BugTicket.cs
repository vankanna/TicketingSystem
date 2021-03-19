using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class BugTicket: Ticket
    {

        public string severity {get; set;}
         
        public override string formatTicket()
        {
            string watchersString = string.Join("|", this.watchers.ToArray());
            return this.ticketId +
            "," + this.summary +
            "," + this.status +
            "," + this.priority +
            "," + this.submitter +
            "," + this.assigned +
            "," + watchersString +
            "," + this.severity;
        }
        public static BugTicket createTicket(int ticketId) {
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

            Console.WriteLine("Enter a severity (Low/Medium/High)");                        
            string severity = Console.ReadLine();

            BugTicket bugTicket = new BugTicket();
            bugTicket.ticketId = ticketId;
            bugTicket.summary = summary;
            bugTicket.status = status;
            bugTicket.priority = priority;
            bugTicket.submitter = submitter;
            bugTicket.assigned = assigned;
            bugTicket.watchers = watchers;
            bugTicket.severity = severity;
            return bugTicket;
        }

    }
}