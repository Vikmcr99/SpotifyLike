using StreamingApp.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Repository.Account
{
    public class UserRepository
    {
        private static List<User> Users { get; set; } = new List<User>();


        public UserRepository()
        {
              
        }

        public void Save(User user)
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
        }

        public User GetUser(Guid id)
        { 
            return Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            Users.Remove(user);
            Users.Add(user);
        }

        public void Delete(User user) 
        {
            Users.Remove(user);
        }

    }
}
