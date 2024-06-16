using Consumer.BL.Posts;
using Consumer.BO.Posts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Consumer.BL;

public static class DependencyInjection
{
  public static void AddBL(this IServiceCollection services, IConfiguration configuration)
  {
    string redisConnectionString = configuration["Redis:ConnectionString"] ?? "localhost:6379";
    services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
    services.AddSingleton<IPostCreatedConsumer, PostCreatedConsumer>();
  }
}
