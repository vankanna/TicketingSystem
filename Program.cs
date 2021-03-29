using System;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BugTicketManager bugManager = new BugTicketManager("bugTickets.csv");
            TaskTicketManager taskManager = new TaskTicketManager("taskTickets.csv");
            EnhancementTicketManager enhancementManager = new EnhancementTicketManager("enhancementTickets.csv");
            bugManager.loadTicketsFromFile();
            taskManager.loadTicketsFromFile();
            enhancementManager.loadTicketsFromFile();

            string typeSelected;
            do 
            {

                Console.WriteLine("Please Select Type Of Ticket To Manage\n 1 - Bug Tickets\n 2 - Task Tickets\n 3 - Enhancement Tickets");
                string typeChoice = Console.ReadLine();
                if (typeChoice == "1") {
                    typeSelected = "bugTicket";
                } else if (typeChoice == "2") {
                    typeSelected = "taskTicket";
                } else if (typeChoice == "3") {
                    typeSelected = "enhancementTicket";
                } else {
                    typeSelected = "no Choice";
                }

                string choice;
                if (typeSelected != "no Choice") {
                    do
                    {
                        // ask user a question
                        Console.WriteLine("\n1) List Tickets From File.");
                        Console.WriteLine("2) Create New Ticket And Write To File.");
                        Console.WriteLine("3) Search Tickets");
                        Console.WriteLine("Enter any other key to exit.");
                        // input response
                        choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            if (typeSelected == "bugTicket") {
                                bugManager.listTickets();
                            } else if (typeSelected == "taskTicket") {
                                taskManager.listTickets();
                            } else if (typeSelected == "enhancementTicket") {
                                enhancementManager.listTickets();
                            }
                            
                        } else if (choice == "2")
                        {
                            if (typeSelected == "bugTicket") {
                                int id = bugManager.bugTickets[bugManager.bugTickets.Count - 1].ticketId + 1;
                                bugManager.bugTickets.Add(BugTicket.createTicket(id));
                                bugManager.writeTicketsToFile();
                            } else if (typeSelected == "taskTicket") {
                                int id = taskManager.taskTickets[taskManager.taskTickets.Count - 1].ticketId + 1;
                                taskManager.taskTickets.Add(TaskTicket.createTicket(id));
                                taskManager.writeTicketsToFile();
                            } else if (typeSelected == "enhancementTicket") {
                                int id = enhancementManager.enhancementTickets[enhancementManager.enhancementTickets.Count - 1].ticketId + 1;
                                enhancementManager.enhancementTickets.Add(EnhancementTicket.createTicket(id));
                                enhancementManager.writeTicketsToFile();
                            }
                        } else if (choice == "3") {
                            if (typeSelected == "bugTicket") {
                                bugManager.searchTickets();
                            } else if (typeSelected == "taskTicket") {
                                taskManager.searchTickets();
                            } else if (typeSelected == "enhancementTicket") {
                                enhancementManager.searchTickets();
                            }
                        } else {
                            typeSelected = "";
                        }
                    } while (choice == "1" || choice == "2" || choice == "3");
                } else {
                    Console.WriteLine("Please Make a Valid Choice");
                    typeSelected = "";
                }
            } while (typeSelected == "");
            

            
        }
    }
}
