using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Domain
{
    public class Attendees
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public virtual Students Student { get; set; }
        public int Event_Id { get; set; }
        public virtual Events Event { get; set; }
    }
}
