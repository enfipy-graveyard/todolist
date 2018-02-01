using System.Security.Claims;
using Server.Models;

namespace Server.Abstractions
{
    public interface IAccount
    {
        bool IsAuthorized(AccountModel accountModel);
        bool LoginExists(string login);
        AccountInfoModel GetAccountInfo(AccountModel accountModel);
        ClaimsIdentity GetIdentity(AccountModel account);
        void Registration(AccountModel accountModel);
    }
}
