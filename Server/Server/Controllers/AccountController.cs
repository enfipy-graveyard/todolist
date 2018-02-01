using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Server.BusinessLogic.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Server.Abstractions;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IAccount _account;

        public AccountController(IAccount account) { _account = account; }

        [HttpPost]
        [Route("/api/gettoken")]
        public async Task GetToken([FromBody] AccountModel account)
        {
            var identity = _account.GetIdentity(account);

            if (identity == null)
            {
                await Response.WriteAsync("Login or password is incorrect");
                return;
            }
            string encodedJwt = GetEncodedJwt(account, identity);

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(encodedJwt,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost]
        [Route("/api/registration")]
        public async Task Registration([FromBody] AccountModel account)
        {
            if (_account.LoginExists(account.Login))
            {
                await Response.WriteAsync("Login already exists");
                return;
            }

            _account.Registration(account);

            var identity = _account.GetIdentity(account);

            if (identity == null)
            {
                await Response.WriteAsync("Registration error");
                return;
            }
            string encodedJwt = GetEncodedJwt(account, identity);

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(encodedJwt,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private string GetEncodedJwt(AccountModel account, ClaimsIdentity identity)
        {
            var token = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: AuthOptions.GetNotBefore(),
                claims: identity.Claims,
                expires: AuthOptions.GetExpires(),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var accountInfoModel = _account.GetAccountInfo(account);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            accountInfoModel.Token = encodedJwt;
            return encodedJwt;
        }
    }
}