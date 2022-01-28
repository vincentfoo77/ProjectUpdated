using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Domain
{
    public class FeedBack
    {
        public int Id { get; set; }
        public String Feedback { get; set; }
        public int Event_Id { get; set; }
        public virtual Events Event { get; set; }
    }
}
