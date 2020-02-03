using System.ComponentModel.DataAnnotations;

namespace ELearningApp.Core.Dtos.InputModels.Auth
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}