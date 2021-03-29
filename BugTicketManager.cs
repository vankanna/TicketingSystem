using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



namespace TicketingSystem
{
    public class BugTicketManager
    {
        public List<BugTicket> bugTickets = new List<BugTicket>();

        string bugHeaders;
   

        public BugTicketManager ()
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
                        this.bugHeaders = line;
                        firstLine = false;
                    } else {                        
                        this.bugTickets.Add(BugTicket.createTicketFromFile(line));
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

                
                sw.WriteLine(this.bugHeaders);
                foreach (var ticket in this.bugTickets)
                {
                    sw.WriteLine(ticket.formatTicket());
                }
            
                
                sw.Close();
            }
        }

        public void listTickets(string ticketType) {
            Console.WriteLine("\n" + this.bugHeaders);
            foreach (var ticket in this.bugTickets) {
                Console.WriteLine(ticket.formatTicket());
            }
        }

        public void searchTickets(string ticketType) {
            // ask what to search
            Console.WriteLine("What category would you like to search?\n 1) Status\n 2) Priority\n 3) Submitter");
            string category = Console.ReadLine();
            Console.WriteLine("Please Enter Your Search Criteria");
            string searchCriteria = Console.ReadLine();

            var ticketsFound = this.bugTickets.Where((t) => {
                
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