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

        public List<Subscription> Subscription { get; set; } = new List<Subscription>();
    }
}
