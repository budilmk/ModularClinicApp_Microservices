using Authentication.API;
using Booking.API;
using Booking.Infrastructure.Database;
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
    .AddClinicAppDb(builder.Configuration)
    .AddAuthenticationModule(builder.Configuration)
    .AddConvey().AddRabbitMq();
    

builder.Services.AddControllers();
var app = builder.Build();
app.MapGet("/", () => "Modular ClinicApp!");
app.MapControllers();

app.Run();
