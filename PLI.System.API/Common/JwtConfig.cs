﻿
namespace PLI.System.API.Common
{
    public class JwtConfig
    {
        public string? Secret { get; set; }
        public string? ValidAudience { get; set; }
        public string? ValidIssuer { get; set; }
        public int TokenExpirationMinutes { get; set; }
    }
}