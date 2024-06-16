using StackExchange.Redis;
using System.Text.Json;
using WebApi.BO.Posts;

namespace WebApi.BL.Posts;
internal class PostsService(IConnectionMultiplexer redis) : IPostService
{
  public async Task CreatePost(PostCreateModel model)
  {
    await redis.GetSubscriber().PublishAsync(RedisChannel.Literal("PostCreated"), RedisValue.Unbox(JsonSerializer.Serialize(model)));
  }
}
