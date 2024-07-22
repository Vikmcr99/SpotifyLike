using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Transaction
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Value { get; set; }

        public String Merchant { get; set; }
        public String Description { get; set; }
    }
}
