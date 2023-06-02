using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace GenericPack.User
{
    public interface IAspNetUser
    {
        string Name { get; }
        int GetUserId();
        int GetClientId();
        bool IsAutenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetUserClaims();
        HttpContext GetHttpContext();
    }
}