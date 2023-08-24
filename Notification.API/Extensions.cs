using Booking.Shared.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using Convey.MessageBrokers.RabbitMQ;
using Notification.Application;

namespace Notification.API
{
    public static class Extensions
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }


        public static IApplicationBuilder UseNotificationModule(this IApplicationBuilder app)

        {
            app.UseRabbitMq().Subscribe<NewAppointmentBookedEventDto>(async (serviceProvider, message, context) =>
            {
                await serviceProvider.GetRequiredService<INotificationService>().Handle(message);

            });

            return app;

        }
    }
}