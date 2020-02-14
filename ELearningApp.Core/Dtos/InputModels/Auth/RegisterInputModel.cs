using System.ComponentModel.DataAnnotations;
using ELearningApp.Core.Helpers;

namespace ELearningApp.Core.Dtos.InputModels.Auth
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public RoleEnum Role { get; set; }
        
    }
}