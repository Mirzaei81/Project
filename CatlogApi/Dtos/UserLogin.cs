using System.ComponentModel.DataAnnotations;

namespace AuthApi.Dto
{
    public record UserLogin
    {
        [Required]
        public string UserName{get;set;} = string.Empty;
        [Required]
        public string Password{get;set;} = string.Empty;
    }
}
