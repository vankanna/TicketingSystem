using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



namespace TicketingSystem
{
    public class TaskTicketManager
    {
        public List<TaskTicket> taskTickets = new List<TaskTicket>();
        string filename;
        string taskHeaders;
   

        public TaskTicketManager ()
        {
        }

        public void loadTicketsFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr1 = new StreamReader(filename);
                Boolean firstLine = true;
                while (!sr1.EndOfStream)
                {
                    string line = sr1.ReadLine();
                    if(firstLine) {
                        this.taskHeaders = line;
                        firstLine = false;
                    } else {                        
                        this.taskTickets.Add(TaskTicket.createTicketFromFile(line));
                    }
                }
                sr1.Close();
            }
            else
            {
                Console.WriteLine("File does not exist" + filename);
            }
        }

        public void writeTicketsToFile(string ticketType, string filename)
        {
            if (File.Exists(filename))
            {
                StreamWriter sw = new StreamWriter(filename);
                sw.WriteLine(this.taskHeaders);
                foreach (var ticket in this.taskTickets)
                {
                    sw.WriteLine(ticket.formatTicket());
                }
                sw.Close();
            }
        }

        public void listTickets(string ticketType) {
            Console.WriteLine("\n" + this.taskHeaders);
            foreach (var ticket in this.taskTickets) {
                Console.WriteLine(ticket.formatTicket());
            }
        }

        public void searchTickets(string ticketType) {
            // ask what to search
            Console.WriteLine("What category would you like to search?\n 1) Status\n 2) Priority\n 3) Submitter");
            string category = Console.ReadLine();
            Console.WriteLine("Please Enter Your Search Criteria");
            string searchCriteria = Console.ReadLine();

            var ticketsFound = this.taskTickets.Where((t) => {
                
                if(category == "1") {
                    return t.status.Contains(searchCriteria);
                } else if (category == "2") {
                    return t.priority.Contains(searchCriteria);
                } else if (category == "3") {
                    return t.submitter.Contains(searchCriteria);
                } else {
                    return false;
                }
            
            });

            Console.WriteLine(ticketsFound.Count() + " Matches Found");
            foreach(BugTicket t in ticketsFound)
            {
                Console.WriteLine($" - {t.formatTicket()}");
            }
        }
    }
}