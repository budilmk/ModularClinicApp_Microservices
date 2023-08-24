using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Notification.API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNotificationModule();
builder.Services.AddConvey().AddRabbitMq();

var app = builder.Build();

app.UseNotificationModule();
app.MapGet("/", () => "Notification Program!");

app.Run();
