using System;
using System.IO;
using System.Collections.Generic;


namespace TicketingSystem
{
    public class TicketManager
    {
        public List<BugTicket> bugTickets = new List<BugTicket>();
        public List<TaskTicket> taskTickets = new List<TaskTicket>();
        public List<EnhancementTicket> enhancmentTickets = new List<EnhancementTicket>();

        string fileName;
        string bugHeaders;
        string taskHeaders;
        string enhancementHeaders;


        public TicketManager (string fileName)
        {
            this.fileName = fileName;
        }

        public void loadTicketsFromFile(string ticketType, string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr1 = new StreamReader(filename);
                Boolean firstLine = true;
                while (!sr1.EndOfStream)
                {

                    string line = sr1.ReadLine();
                    if(firstLine) {

                        if (ticketType == "bugTicket") {
                            this.bugHeaders = line;
                        } else if (ticketType == "taskTicket") {
                            this.taskHeaders = line;
                        } else if (ticketType == "enhancementTicket") {
                            this.enhancementHeaders = line;
                        } else {

                        }
                        firstLine = false;
                    } else {                        
                        if (ticketType == "bugTicket") {
                            BugTicket.createTicketFromFile(line);
                        } else if (ticketType == "taskTicket") {
                            TaskTicket.createTicketFromFile(line)
                        } else if (ticketType == "enhancementTicket") {
                            EnhancementTicket.createTicketFromFile(line)
                        } else {

                        }
                        //this.tickets.Add();
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
            this.Tickets.Add(T.createTicket(this.Tickets[this.Tickets.Count - 1].ticketId + 1));
        }

        public List<string> createWatchersFromString(string watchers) {
            string[] watchersArry = watchers.Split('|');
            List<string> watchersList = new List<string>(watchersArry);
            return watchersList;
        }
        
    }

}