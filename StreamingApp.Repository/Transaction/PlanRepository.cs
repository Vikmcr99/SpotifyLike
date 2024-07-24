using StreamingApp.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Repository.Transaction
{
    public class PlanRepository
    {
        private ApplicationContext _context;

        public PlanRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Plan GetPlanById(object planId)
        {
            throw new NotImplementedException();
        }
    }
}
