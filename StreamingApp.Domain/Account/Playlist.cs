using StreamingApp.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Account
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Public { get; set; }
        public User User { get; set; }
        public List<Music> Musics { get; set; }

        public Playlist()
        {
            Musics = new List<Music>();
        }
    }
}
