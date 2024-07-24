using StreamingApp.Domain.Streaming;
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

        public void FavoriteMusic(Music music, string playlistName = "Favorites")
        {
            var playlist = this.Playlists.FirstOrDefault(x => x.Name == playlistName);

            if(playlist == null)
            {
                throw new Exception("Playlist not found");
            }
            playlist.Musics.Add(music);
        }

        public void UnfavoriteMusic(Music music, string playlistName = "Favorites")
        {
            var playlist = this.Playlists.FirstOrDefault(x => x.Name == playlistName);

            if (playlist == null)
            {
                throw new Exception("Playlist not found");
            }

            var musicFav = playlist.Musics.FirstOrDefault(x => x.Id == music.Id);

            if (musicFav == null)
                throw new Exception("Music not found");

            playlist.Musics.Remove(music);
        }
    }
}
