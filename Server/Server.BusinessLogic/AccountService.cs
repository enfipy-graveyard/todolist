using Server.BusinessLogic.Helpers;
using Server.Abstractions;
using Server.Data.Classes;
using Server.Models;
using Server.Data;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public class AccountService : IAccount
    {
        private readonly ApplicationContext _applicationContext;

        public AccountService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public bool IsAuthorized(AccountModel accountModel)
        {
            if (accountModel == null) return false;

            var user = _applicationContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);

            if (user == null) return false;
            string salt = user.Salt;
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);

            return hash == user.PasswordHash;
        }

        public AccountInfoModel GetAccountInfo(AccountModel accountModel)
        {
            var user = _applicationContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return null;
            return new AccountInfoModel { Id = user.Id };
        }

        public void Registration(AccountModel accountModel)
        {
            var salt = HashingMethods.CreateSalt();
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            User newUser = new User
            {
                Login = accountModel.Login,
                PasswordHash = hash,
                Salt = salt,
            };
            _applicationContext.Users.Add(newUser);
            _applicationContext.SaveChanges();
        }

        public ClaimsIdentity GetIdentity(AccountModel account)
        {
            if (!IsAuthorized(account)) return null;

            var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login) };

            var claimsIdentity = new ClaimsIdentity(claims, AuthOptions.AuthenticationType,
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        public bool LoginExists(string login)
        {
            return _applicationContext.Users.FirstOrDefault(u => u.Login == login) != null;
        }
    }
}
