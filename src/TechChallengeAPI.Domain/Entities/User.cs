﻿using TechChallenge.Domain.Enums;

namespace TechChallenge.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Roles Role { get; set; } = Roles.User;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryDate { get; set; }

    }
}
