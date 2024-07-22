using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Streaming
{
   public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Band Band { get; set; }
        public List<Music> Musics { get; set; }
    }
}
