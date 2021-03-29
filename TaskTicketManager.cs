using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



namespace TicketingSystem
{
    public class TaskTicketManager : TicketManager
    {
        public List<TaskTicket> taskTickets = new List<TaskTicket>();
        string filename;
        string taskHeaders;
   

        public TaskTicketManager (string filename)
        {
            this.filename = filename;
        }

        public void loadTicketsFromFile()
        {
            if (File.Exists(this.filename))
            {
                StreamReader sr1 = new StreamReader(this.filename);
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
                Console.WriteLine("File does not exist" + this.filename);
            }
        }

        public void writeTicketsToFile()
        {
            if (File.Exists(this.filename))
            {
                StreamWriter sw = new StreamWriter(this.filename);
                sw.WriteLine(this.taskHeaders);
                foreach (var ticket in this.taskTickets)
                {
                    sw.WriteLine(ticket.formatTicket());
                }
                sw.Close();
            }
        }

        public void listTickets() {
            Console.WriteLine("\n" + this.taskHeaders);
            foreach (var ticket in this.taskTickets) {
                Console.WriteLine(ticket.formatTicket());
            }
        }

        public void searchTickets() {
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
            foreach(TaskTicket t in ticketsFound)
            {
                Console.WriteLine($" - {t.formatTicket()}");
            }
        }
    }
}