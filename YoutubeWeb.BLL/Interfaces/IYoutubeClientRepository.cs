using YoutubeWeb.API.Dtos;

namespace YoutubeWeb.BLL.Interfaces
{
    public interface IYoutubeClientRepository
    {
        Task<SearchResponseDto> SearchAsync(string q, int maxResult);
        Task<ChannelResponseDto> SearchChannelAsync(string channelName, int maxResult);

    }
}
