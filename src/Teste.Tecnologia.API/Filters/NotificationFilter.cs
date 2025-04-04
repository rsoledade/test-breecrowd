﻿using Teste.Tecnologia.Domain.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Teste.Tecnologia.API.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotification _notification;

        public NotificationFilter(INotification notification)
        {
            _notification = notification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notification.HasNotification) 
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                await context.HttpContext.Response.WriteAsJsonAsync(_notification.Errors);
                return;
            }

            await next();
        }
    }
}
