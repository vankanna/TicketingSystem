using System.Collections.Generic;

namespace TicketingSystem
{
    class TaskTicket : Ticket
    {
        public string projectName {get; set;}
        public string dueDate {get; set;}
         public TaskTicket (
            int ticketId,
            string summary,
            string status,
            string priority,
            string submitter,
            string assigned,
            List<string> watchers,
            string projectName,
            string dueDate ) : base ( ticketId, summary, status, priority, submitter, assigned, watchers)
        {
           
        }
    }
}