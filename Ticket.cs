using System.Collections.Generic;

namespace TicketingSystem
{
    class Ticket
    {
        public int ticketId {get; set;}
        public string summary {get; set;}        
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        List<string> watchers {get; set;}

        public Ticket(int ticketId, string summary, string status, string priority, string submitter, string assigned, List<string> watchers) {
            this.ticketId = ticketId;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigned = assigned;
            this.watchers = watchers;
        }


        public string formatTicket() {
            string watchersString = string.Join("|", this.watchers.ToArray());
            return this.ticketId + "," + this.summary + "," + this.status + "," + this.priority + "," + this.submitter + "," + this.assigned + "," + watchersString;
        }
    }
}