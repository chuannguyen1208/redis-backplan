using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace ConsumerWebApi.Posts;
internal class PostCreatedComsumer(IConnectionMultiplexer multiplexer, ILogger<PostCreatedComsumer> logger)
{
  public async Task SubcribePostCreated()
  {
    await multiplexer.GetSubscriber().SubscribeAsync(RedisChannel.Literal("PostCreated"), (channel, value) =>
    {
      logger.LogInformation($"Msg from {channel} and value is {value}");
    });
  }
}
