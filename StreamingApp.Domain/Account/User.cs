using StreamingApp.Domain.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Account
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        public void CreateUser(string name, Plan plan, Card card)
        {
            this.Name = name;
            this.SubscrivePlan(plan, card);
            this.AddCard(card);
            this.CreatePlaylist();
        }

        private void CreatePlaylist(string name = "Favorites", bool publicPlaylist = false)
        {
            this.Playlists.Add(new Playlist
            {
                Id = new Guid(),
                Name = name,
                Public = publicPlaylist,
                User = this

            });
        }

        private void AddCard(Card card)
        {
           this.Cards.Add(card);   
        }

        private void SubscrivePlan(Plan plan, Card card)
        {
            card.CreateTransaction(plan.Name, plan.Value, plan.Description);

            if (this.Subscriptions.Count > 0 && this.Subscriptions.Any(x => x.Active))
            {
                var activePlan = this.Subscriptions.FirstOrDefault(x => x.Active);
                activePlan.Active = false;
            }

            this.Subscriptions.Add(new Subscription()
            {
                Active = true,
                Date =  DateTime.Now,
                Plan = plan,
                Id = new Guid()

            });

        }
    }
}
