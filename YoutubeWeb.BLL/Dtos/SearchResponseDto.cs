using YoutubeWeb.DAL.Entities;

namespace YoutubeWeb.API.Dtos
{
    public class SearchResponseDto
    {
        public List<VideoResult> Videos { get; set; } = new List<VideoResult>();
        public List<ChannelResult> Channels { get; set; } = new List<ChannelResult>();
        public List<PlaylistResult> Playlists { get; set; } = new List<PlaylistResult>();
    }
}
