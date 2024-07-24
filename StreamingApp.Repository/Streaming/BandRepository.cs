using StreamingApp.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StreamingApp.Repository.Streaming
{
    public class BandRepository
    {
        private readonly IHttpClientFactory _httpClientFactory = null;

        public BandRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private int retries = 1;

       

        public Music GetMusic(Guid idMusic)
        {
            string url = $"localhost:9090/api/musics/{idMusic}";

            HttpClient client = this._httpClientFactory.CreateClient("musicApiServer");

            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Music not found");

            var content = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<Music>(content);
        }
    }
}
