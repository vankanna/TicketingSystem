using System.Collections.Generic;

namespace TicketingSystem
{
    class EnhancementTicket : Ticket

    {
        public string software {get; set;}
        public int cost {get; set;} 
        public string reason {get; set;}
        public string estimate {get; set;}

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
            "," + this.software +
            "," + this.cost +
            "," + this.reason +
            "," + this.estimate;
        }
        

    }
}