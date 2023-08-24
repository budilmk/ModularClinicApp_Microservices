using Booking.API.Services;
using Booking.Domain.Contracts;
using Booking.Shared;
using Booking.Infrastructure.Repositories;
using SlotManagement.Services;
using SlotManagement.Repositories;
using Booking.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Booking.Application.Contracts;
using Booking.Infrastructure;
using Notification.Application;

namespace Booking.API;

public static class Extensions
{
    public static IServiceCollection AddBookingModule(this IServiceCollection services)
    {
        services.AddTransient<ISlotService, SlotService>()
                .AddTransient<ISlotRepository, SlotRepo>()
                .AddTransient<IAppointmentService, AppointmentService>()
                .AddTransient<INotificationService, NotificationService>()
                .AddTransient<IBookPublisher, RabbitMQBookingPublisher>()
                .AddTransient<IAppointmentRepo, AppointmentRepo>();

        return services;
    }

}