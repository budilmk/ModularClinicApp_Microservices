using Authentication.API;
using Booking.API;
using Booking.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBookingModule()
    .AddClinicAppDb(builder.Configuration)
    .AddAuthenticationModule(builder.Configuration);

builder.Services.AddControllers();
var app = builder.Build();
app.MapGet("/", () => "Modular ClinicApp!");
app.MapControllers();

app.Run();
