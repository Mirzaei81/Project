using Microsoft.AspNetCore.Identity;

namespace AuthApi.IdenityAuth
{
    public class UserApllication : IdentityUser
    {
        public string FirstName {get;set;}= string.Empty;
        public string LastName {get;set;}= string.Empty;
    }
}
