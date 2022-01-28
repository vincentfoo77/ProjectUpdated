using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Domain
{
    public class Events
    {
        public int Id { get; set; }
        public String  EventName { get; set; }
        public String Venue { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Participants { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
       
    }
}
