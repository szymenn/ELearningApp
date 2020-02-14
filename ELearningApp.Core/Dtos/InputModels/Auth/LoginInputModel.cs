using System.ComponentModel.DataAnnotations;
using ELearningApp.Core.Helpers;

namespace ELearningApp.Core.Dtos.InputModels.Auth
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public RoleEnum Role { get; set; }
    }
}