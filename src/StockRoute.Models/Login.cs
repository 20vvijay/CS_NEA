namespace StockRoute.Models
{
    public class Login
    {
        private readonly string _userName;
        private readonly string _passwordHash;

        public Login(string userName, string passwordHash)
        {
            _userName = userName;
            _passwordHash = passwordHash;
        }
    }
}
