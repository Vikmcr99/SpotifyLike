using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Transaction
{
    public  class Subscription
    {
        public Guid Id { get; set; }
        public Plan Plan { get; set; }
        public Boolean Active { get; set; }
        public DateTime Date { get; set; }
    }
}
