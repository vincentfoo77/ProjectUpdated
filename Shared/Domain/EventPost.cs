using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Domain
{
    public class EventPost
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public int Event_id { get; set; }
        public virtual Events Event { get; set; }
    }
}
