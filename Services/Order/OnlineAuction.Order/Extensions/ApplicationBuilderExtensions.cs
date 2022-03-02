﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using OnlineAuction.Order.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineAuction.Order.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static EventBusOrderCreateConsumer Listener { get; set; }

        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusOrderCreateConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;

        }
        private static void OnStarted()
        {
            Listener.Counsume();
        }
        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}
