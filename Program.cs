using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TicketManager manager = new TicketManager();
            manager.loadTicketsFromFile("bugTicket", "bugTickets.csv");
            manager.loadTicketsFromFile("taskTicket", "taskTickets.csv");
            manager.loadTicketsFromFile("enhancementTicket", "enhancementTickets.csv");


            string typeSelected = "";
            string filename = "";

            do 
            {

                Console.WriteLine("Please Select Type Of Ticket To Manage\n 1 - Bug Tickets\n 2 - Task Tickets\n 3 - Enhancement Tickets");
                string typeChoice = Console.ReadLine();
                if (typeChoice == "1") {
                    typeSelected = "bugTicket";
                    filename = "bugTickets.csv";
                } else if (typeChoice == "2") {
                    typeSelected = "taskTicket";
                    filename = "taskTickets.csv";
                } else if (typeChoice == "3") {
                    typeSelected = "enhancementTicket";
                    filename = "enhancementTickets.csv";
                } else {
                    typeSelected = "exit";
                }

                string choice;
                do
                {
                    // ask user a question
                    Console.WriteLine("\n1) List Tickets From File.");
                    Console.WriteLine("2) Create New Ticket And Write To File.");
                    Console.WriteLine("Enter any other key to exit.");
                    // input response
                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        manager.listTickets(typeSelected);
                        
                    } else if (choice == "2")
                    {
                        if (typeSelected == "bugTicket") {
                            int id = manager.bugTickets[manager.bugTickets.Count - 1].ticketId + 1;
                            manager.bugTickets.Add(BugTicket.createTicket(id));
                            manager.writeTicketsToFile("bugTicket", "bugTickets.csv");
                        } else if (typeSelected == "taskTicket") {
                            int id = manager.taskTickets[manager.taskTickets.Count - 1].ticketId + 1;
                            manager.taskTickets.Add(TaskTicket.createTicket(id));
                            manager.writeTicketsToFile("taskTicket", "taskTickets.csv");
                        } else if (typeSelected == "enhancementTicket") {
                            int id = manager.enhancementTickets[manager.enhancementTickets.Count - 1].ticketId + 1;
                            manager.enhancementTickets.Add(EnhancementTicket.createTicket(id));
                            manager.writeTicketsToFile("enhancementTicket", "enhancementTickets.csv");

                        }
                        manager.writeTicketsToFile(typeSelected, filename);

                    } else {
                        typeSelected = "";
                    }
                } while (choice == "1" || choice == "2");

            } while (typeSelected == "");
            

            
        }
    }
}
