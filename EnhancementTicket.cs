using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    public class EnhancementTicket : Ticket

    {
        public string software {get; set;}
        public Double cost {get; set;} 
        public string reason {get; set;}
        public string estimate {get; set;}

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
            "," + this.software +
            "," + this.cost +
            "," + this.reason +
            "," + this.estimate;
        }
        
        public static EnhancementTicket createTicket(int ticketId) {
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

            Console.WriteLine("Enter software");                        
            string software = Console.ReadLine();
            Console.WriteLine("Enter the cost");                        
            Double cost = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a reason");                        
            string reason = Console.ReadLine();
            EnhancementTicket enhancementTicket = new EnhancementTicket();
            enhancementTicket.ticketId = ticketId;
            enhancementTicket.summary = summary;
            enhancementTicket.status = status;
            enhancementTicket.priority = priority;
            enhancementTicket.submitter = submitter;
            enhancementTicket.assigned = assigned;
            enhancementTicket.watchers = watchers;
            enhancementTicket.software = software;
            enhancementTicket.cost = cost;
            enhancementTicket.reason = reason;

            return enhancementTicket;
        }
        public static EnhancementTicket createTicketFromFile(string line) {
            EnhancementTicket enhancementTicket = new EnhancementTicket();
            string[] fieldsArr = line.Split(',');

            enhancementTicket.ticketId = Int32.Parse(fieldsArr[0]);
            enhancementTicket.summary = fieldsArr[1];
            enhancementTicket.status = fieldsArr[2];
            enhancementTicket.priority = fieldsArr[3];
            enhancementTicket.submitter = fieldsArr[4];
            enhancementTicket.assigned = fieldsArr[5];
            enhancementTicket.watchers = Ticket.createWatchersFromString(fieldsArr[6]);
            enhancementTicket.software = fieldsArr[7];
            enhancementTicket.cost = Double.Parse(fieldsArr[8]);
            enhancementTicket.reason = fieldsArr[9];
            return enhancementTicket;
        }
    }
}