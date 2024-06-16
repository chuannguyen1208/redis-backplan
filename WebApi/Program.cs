using WebApi.BL;
using WebApi.BO.Posts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBL(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World");
app.MapPost(("/posts"), (PostCreateModel model, IPostService service) => service.CreatePost(model));

app.Run();
