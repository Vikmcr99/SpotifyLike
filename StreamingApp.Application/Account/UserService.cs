using StreamingApp.Domain.Account;
using StreamingApp.Domain.Transaction;
using StreamingApp.Repository.Account;
using StreamingApp.Repository.Streaming;
using StreamingApp.Repository.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Application.Account
{
    public class UserService
    {
        private UserRepository userRepository;
        private PlanRepository planRepository;
        private BandRepository bandRepository;

        public UserService(UserRepository userRepository, PlanRepository planRepository = null, BandRepository bandRepository = null)
        {
            this.userRepository = userRepository;
            this.planRepository = planRepository;
            this.bandRepository = bandRepository;
        }

        public User CreateAccount(string name, Guid planId, Card card) 
        {
            Plan plan = this.planRepository.GetPlanById(planId);

            if (plan == null) 
            {
                throw new Exception("Plan not found.");
            }

            User user = new User();
            user.CreateUser(name, plan, card);

            this.userRepository.Save(user);

            return user;
        }

        public User GetUserById(Guid id)
        {
            var user = this.userRepository.GetUser(id);
            return user;
        }

        public void FavoriteMusic(Guid id, Guid idMusic)
        {
            var user = this.userRepository.GetUser(id);

            if (user == null) 
            {
                throw new Exception("user not found");
            }

            var music = this.bandRepository.GetMusic(idMusic);

            if(music == null)
            {
                throw new Exception("Music not found");
            }

            user.FavoriteMusic(music);

            this.userRepository.Update(user);

        }

        public void UnfavoriteMusic(Guid id, Guid idMusic)
        {
            var user = this.userRepository.GetUser(id);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            var music = this.bandRepository.GetMusic(idMusic);

            if (music == null)
            {
                throw new Exception("Music not found");
            }

            user.UnfavoriteMusic(music);

            this.userRepository.Update(user);

        }
    }
}
