using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace Server.BusinessLogic.Helpers
{
    public static class AuthOptions
    {
        public const string Issuer = "TodoList";
        public const string Audience = "http://localhost:51602/";
        public const string AuthenticationType = "Token";

        private const int DaysToExpires = 7;
        private const string SecurityKey = "TodoListSecurityKey";

        public static DateTime GetNotBefore()
        {
            return DateTime.UtcNow;
        }

        public static DateTime GetExpires()
        {
            return DateTime.UtcNow.AddDays(DaysToExpires);
        }

        public static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                ValidateLifetime = true,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));
        }
    }
}
