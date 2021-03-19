using System.Collections.Generic;

namespace TicketingSystem
{
    public abstract class Ticket
    {
        public int ticketId {get; set;}
        public string summary {get; set;}        
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public List<string> watchers {get; set;}

        public Ticket() {
            watchers = new List<string>();
        }

        public virtual string formatTicket() {
            string watchersString = string.Join("|", this.watchers.ToArray());
            return this.ticketId + "," + this.summary + "," + this.status + "," + this.priority + "," + this.submitter + "," + this.assigned + "," + watchersString;
        }
    }
}