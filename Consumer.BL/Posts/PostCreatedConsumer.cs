using Consumer.BO.Posts;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Consumer.BL.Posts;
internal class PostCreatedConsumer(IConnectionMultiplexer multiplexer, ILogger<PostCreatedConsumer> logger) : IPostCreatedConsumer
{
  public async Task Subcribe()
  {
    await multiplexer.GetSubscriber().SubscribeAsync(RedisChannel.Literal("PostCreated"), (channel, value) =>
    {
      logger.LogInformation($"Msg from {channel} and value is {value}");
    });
  }
}
