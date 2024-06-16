using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using WebApi.BL.Posts;
using WebApi.BO.Posts;

namespace WebApi.BL;

public static class DependencyInjection
{
  public static void AddBL(this IServiceCollection services, IConfiguration configuration)
  {
    string redisConnectionString = configuration["Redis:ConnectionString"] ?? "localhost:6379";

    services.AddStackExchangeRedisCache(options =>
    {
      options.Configuration = redisConnectionString;
    });

    services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
    services.AddScoped<IPostService, PostsService>();
  }
}
