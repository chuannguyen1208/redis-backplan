using WebApi.BL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddBL(builder.Configuration);

var app = builder.Build();

app.MapCarter();

app.Run();