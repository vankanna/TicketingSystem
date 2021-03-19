using System.Collections.Generic;

namespace TicketingSystem
{
    class TaskTicket : Ticket
    {
        public string projectName {get; set;}
        public string dueDate {get; set;}

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
    }
}