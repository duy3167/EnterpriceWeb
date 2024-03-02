using EnterpriceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriceWeb.Repository
{
    public class RepoAccount
    {
        private AppDbConText dbContext;
        public RepoAccount(AppDbConText dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<User> login(string gmail, string password)
        {
            var user = dbContext.users.Where(s => s.us_gmail.Equals(gmail) && s.us_password.Equals(password)).ToList();
            return user;
        }
        public async Task<User> register(User user)
        {
            var check = dbContext.users.FirstOrDefault(s => s.us_gmail == user.us_gmail);
            return check;
        }
    }
}
