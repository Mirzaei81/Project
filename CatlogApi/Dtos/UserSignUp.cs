using System.ComponentModel.DataAnnotations;
namespace AuthApi.Dto
{
    public record UserSignUp
    {
        [Required]
        public string FirstName{get;set;} = string.Empty;

        [Required]
        public string LastName{get;set;}  = string.Empty;

        [Required]
        public string UserName{get;set;} = string.Empty;

        [EmailAddress] 
        [Required]
        public string Email{get;set;} = string.Empty;

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
                ErrorMessage="Password Must Be Eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password{get;set;} = string.Empty;
    }
}
