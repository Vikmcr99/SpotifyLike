namespace StreamingApp.API.DTO
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PlanId { get; set; }
        public List<PlaylistResponse> Playlists { get; set; } = new List<PlaylistResponse>();
    }

    public class PlaylistResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<MusicResponse> Musics { get; set; } = new List<MusicResponse>();
    }

    public class MusicResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Decimal Duraction { get; set; }
    }
}
