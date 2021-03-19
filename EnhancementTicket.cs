using System.Collections.Generic;

namespace TicketingSystem
{
    class EnhancementTicket : Ticket

    {
        public string software {get; set;}
        public int cost {get; set;} 
        public string reason {get; set;}
        public string estmate {get; set;}

        public EnhancementTicket(
            int ticketId,
            string summary,
            string status,
            string priority,
            string submitter,
            string assigned,
            List<string> watchers,
            string software,
            int cost,
            string reson,
            string estmate) : base (ticketId, summary, status, priority, submitter, assigned, watchers)
        {
            this.software = software;
            this.cost = cost;
            this.reason = reason;
            this.estmate = estmate;
        }

    }
}