using Microsoft.AspNetCore.Http;
using WebApi.BO.Posts;

namespace WebApi;
public class PostModule : ICarterModule
{
  public void AddRoutes(IEndpointRouteBuilder app)
  {
    app.MapPost("/posts", async (HttpContext ctx, PostCreateModel model, IPostService service) => {
      await service.CreatePost(model);
    });
  }
}
