using Authentication.API;
using Booking.API;
using Booking.Infrastructure.Database;
using Notification.API;
using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});

builder.Services
    .AddBookingModule()
    .AddNotificationModule()
    .AddClinicAppDb(builder.Configuration)
    .AddAuthenticationModule(builder.Configuration)
    .AddConvey().AddRabbitMq();
    

builder.Services.AddControllers();
var app = builder.Build();
app.UseNotificationModule();
app.MapGet("/", () => "Modular ClinicApp!");
app.MapControllers();

app.Run();
