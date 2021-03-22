using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    public class TaskTicket : Ticket
    {
        public string projectName {get; set;}
        public DateTime dueDate {get; set;}

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
            "," + this.projectName +
            "," + this.dueDate;
        }

        public static TaskTicket createTicket(int ticketId) {
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
            
            Console.WriteLine("Enter a project name");                        
            string projectName = Console.ReadLine();
            Console.WriteLine("Enter a due date, ( 3/21/2021 )");                        
            string dueDate = Console.ReadLine();
            TaskTicket taskTicket = new TaskTicket();
            taskTicket.ticketId = ticketId;
            taskTicket.summary = summary;
            taskTicket.status = status;
            taskTicket.priority = priority;
            taskTicket.submitter = submitter;
            taskTicket.assigned = assigned;
            taskTicket.watchers = watchers;
            taskTicket.projectName = projectName;
            taskTicket.dueDate = DateTime.Parse(dueDate);;

            return taskTicket;
        }

        public static object createTicketFromFile(string line) {
            TaskTicket taskTicket = new TaskTicket();
            string[] fieldsArr = line.Split(',');

            taskTicket.ticketId = Int32.Parse(fieldsArr[0]);
            taskTicket.summary = fieldsArr[1];
            taskTicket.status = fieldsArr[2];
            taskTicket.priority = fieldsArr[3];
            taskTicket.submitter = fieldsArr[4];
            taskTicket.assigned = fieldsArr[5];
            taskTicket.watchers = Ticket.createWatchersFromString(fieldsArr[6]);
            taskTicket.projectName = fieldsArr[7];
            taskTicket.dueDate = DateTime.Parse(fieldsArr[7]);
            return taskTicket;
        }

    }
}