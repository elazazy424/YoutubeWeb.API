using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Options;
using YoutubeWeb.API.Dtos;
using YoutubeWeb.BLL.Interfaces;
using YoutubeWeb.DAL.Entities;

namespace YoutubeWeb.BLL.Repositories
{
    public class YoutubeClientRepository : IYoutubeClientRepository
    {
        #region DI & Constructor
        private readonly YouTubeService _youTubeService;

        public YoutubeClientRepository(IOptions<YoutubeKeys> options)
        {
            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = options.Value.ApiKey,
                ApplicationName = options.Value.ApplicationName
            });
        }
        #endregion
        #region Search
        public async Task<SearchResponseDto> SearchAsync(string q, int maxResult)
        {
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.Q = q;
            searchListRequest.MaxResults = maxResult;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            SearchResponseDto searchResponseDto = new SearchResponseDto();
            foreach (var SearchItem in searchListResponse.Items)
            {
                switch (SearchItem.Id.Kind)
                {
                    case "youtube#video":
                        searchResponseDto.Videos.Add(new VideoResult
                        {
                            Id = SearchItem.Id.VideoId,
                            Title = SearchItem.Snippet.Title,
                            Thumbnail = SearchItem.Snippet.Thumbnails.Medium.Url,
                            PublishedTime = SearchItem.Snippet.PublishedAt,
                            Url = $"https://www.youtube.com/watch?v={SearchItem.Id.VideoId}"
                        });
                        break;

                    case "youtube#channel":
                    searchResponseDto.Channels.Add(new ChannelResult
                    {
                        Id = SearchItem.Id.ChannelId,
                        Title = SearchItem.Snippet.Title,
                        Url = $"https://www.youtube.com/channel/{SearchItem.Id.ChannelId}"
                    });
                    break;

                    case "youtube#playlist":
                    searchResponseDto.Playlists.Add(new PlaylistResult
                    {
                        Id = SearchItem.Id.PlaylistId,
                        Title = SearchItem.Snippet.Title,
                        Thumbnail = SearchItem.Snippet.Thumbnails.Medium.Url,
                        Url = $"https://www.youtube.com/playlist?list={SearchItem.Id.PlaylistId}"
                    });
                    break;
                }
            }
            return searchResponseDto;
        }
        #endregion
        #region SearchChannel
        public async Task<ChannelResponseDto> SearchChannelAsync(string channelName, int maxResult)
        {
            var searchListRequest = _youTubeService.Search.List("snippet");
            searchListRequest.ChannelId = channelName;
            searchListRequest.MaxResults = maxResult;
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            ChannelResponseDto channelResponseDto = new ChannelResponseDto();
            foreach (var SearchItem in searchListResponse.Items)
            {
                switch (SearchItem.Id.Kind)
                {
                    case "youtube#video":
                        channelResponseDto.Videos.Add(new VideoResult
                        {
                            Id = SearchItem.Id.VideoId,
                            Title = SearchItem.Snippet.Title,
                            Thumbnail = SearchItem.Snippet.Thumbnails.Medium.Url,
                            PublishedTime = SearchItem.Snippet.PublishedAt,
                            Url = $"https://www.youtube.com/watch?v={SearchItem.Id.VideoId}"
                        });
                        break;

                    case "youtube#playlist":
                    channelResponseDto.Playlists.Add(new PlaylistResult
                    {
                        Id = SearchItem.Id.PlaylistId,
                        Title = SearchItem.Snippet.Title,
                        Thumbnail = SearchItem.Snippet.Thumbnails.Medium.Url,
                        Url = $"https://www.youtube.com/playlist?list={SearchItem.Id.PlaylistId}"
                    });
                    break;
                }
            }
            return channelResponseDto;
        }
        #endregion
    }
}
