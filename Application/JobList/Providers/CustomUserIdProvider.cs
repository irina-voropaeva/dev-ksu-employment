﻿using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace KsuEmployment.Api.Providers
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
