using Microsoft.EntityFrameworkCore;
using StreamingApp.Domain.Account;
using StreamingApp.Domain.Streaming;
using StreamingApp.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Repository
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
       
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base (options)
        {

        }
    }
}
