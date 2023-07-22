using Booking.API.Services;
using Booking.Domain.Contracts;
using Booking.Shared;
using Booking.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.API;

public static class Extensions
{
    public static IServiceCollection AddClinicModule(this IServiceCollection services)
    {
        services.AddTransient<ISlotService, SlotService>()
                .AddTransient<ISlotRepository, SlotRepo>()
                .AddTransient<IAppointmentService, AppointmentService>()
                .AddTransient<IAppointmentRepo, AppointmentRepo>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        return app;
    }
}