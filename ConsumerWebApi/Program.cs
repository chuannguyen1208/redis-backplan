using ConsumerWebApi.Posts;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

string redisConnectionString = builder.Configuration["Redis:ConnectionString"] ?? "localhost:6379";
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
builder.Services.AddSingleton<PostCreatedComsumer>();

var app = builder.Build();

app.MapCarter();

PostCreatedComsumer postCreatedComsumer = app.Services.GetService<PostCreatedComsumer>();
await postCreatedComsumer.SubcribePostCreated();

app.Run();