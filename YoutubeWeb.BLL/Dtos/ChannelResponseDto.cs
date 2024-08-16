using YoutubeWeb.DAL.Entities;

namespace YoutubeWeb.API.Dtos
{
    public class ChannelResponseDto
    {
        public List<VideoResult> Videos { get; set; } = new List<VideoResult>();
        public List<PlaylistResult> Playlists { get; set; } = new List<PlaylistResult>();
    }
}
