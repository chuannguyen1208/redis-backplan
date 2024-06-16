namespace WebApi.BO.Posts;
public interface IPostService
{
  Task CreatePost(PostCreateModel model);
}
