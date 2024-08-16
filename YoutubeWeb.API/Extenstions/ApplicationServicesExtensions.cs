using Microsoft.AspNetCore.Mvc;
using YoutubeWeb.API.Errors;
using YoutubeWeb.API.Helper;
using YoutubeWeb.BLL.Interfaces;
using YoutubeWeb.BLL.Repositories;
using YoutubeWeb.BLL.Services;

namespace YoutubeWeb.API.Extenstions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IYoutubeClientRepository, YoutubeClientRepository>();
            services.AddScoped<ITokenService, TokenService>();
          
            services.AddAutoMapper(typeof(MappingProfiles));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            }
            );
            return services;
        }
    }
}
