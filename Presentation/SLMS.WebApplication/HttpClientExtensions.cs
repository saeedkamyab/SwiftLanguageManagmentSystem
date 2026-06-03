using SLMS.WebApplicationComponents.Services.Api.Media;
using SLMS.WebApplicationComponents.Services.Api.Media.Interface;
using SLMS.WebApplicationComponents.Services.Api.SocialNetwork;
using SLMS.WebApplicationComponents.Services.Api.SocialNetwork.Interface;
using SLMS.WebApplicationComponents.Services.Api.Users;
using SLMS.WebApplicationComponents.Services.Api.Users.Interface;

namespace SLMS.WebApplication
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services, IConfiguration config)
        {
            var baseUrl = config["Api:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl)) throw new Exception("BaseUrl is missing!");


            Action<HttpClient> configureClient = client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
               

            };

       
            services.AddHttpClient<IPostService, PostService>(configureClient);
            services.AddHttpClient<IMediaService, MediaService>(configureClient);
            services.AddHttpClient<IUserService, UserService>(configureClient);
            services.AddHttpClient<ICommentService, CommentService>(configureClient);

            return services;
        }
    }
}
