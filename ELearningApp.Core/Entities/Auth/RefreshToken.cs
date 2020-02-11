using System;

namespace ELearningApp.Core.Entities.Auth
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public bool Revoked { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public Guid UserId { get; set; }
    }
}