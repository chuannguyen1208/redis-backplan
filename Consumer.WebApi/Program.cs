using Consumer.BL;
using Consumer.BO.Posts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBL(builder.Configuration);

var app = builder.Build();

IPostCreatedConsumer consumer = app.Services.GetRequiredService<IPostCreatedConsumer>();
await consumer.Subcribe();

app.Run();
