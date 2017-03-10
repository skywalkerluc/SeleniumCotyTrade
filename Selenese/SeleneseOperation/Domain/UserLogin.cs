
namespace SeleneseOperation.Domain
{
    public sealed class UserLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserLogin()
        {
            Login = "erik.ramos";
            Password = "erik_acesso2016";
        }
    }
}
