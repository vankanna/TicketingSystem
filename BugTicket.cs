using System.Collections.Generic;

namespace TicketingSystem
{
    class BugTicket: Ticket
    {

        public string severity {get; set;}
         
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
            "," + this.severity;
        }

    }
}