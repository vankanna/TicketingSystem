using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    public abstract class Ticket
    {
        public int ticketId {get; set;}
        public string summary {get; set;}        
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public List<string> watchers {get; set;}

        public Ticket() {
            watchers = new List<string>();
        }

        public virtual string formatTicket() {
            string watchersString = string.Join("|", this.watchers.ToArray());
            return this.ticketId + "," + this.summary + "," + this.status + "," + this.priority + "," + this.submitter + "," + this.assigned + "," + watchersString;
        }

        public static object createTicket() {
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
            
            return new object();
        }
        public List<string> createWatchersFromString(string watchers) {
            string[] watchersArry = watchers.Split('|');
            List<string> watchersList = new List<string>(watchersArry);
            return watchersList;
        }

    }
}