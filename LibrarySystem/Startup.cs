using LibraryBusinessLogic.BL;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;

[assembly: OwinStartup(typeof(LibrarySystem.Startup))]

namespace LibrarySystem
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            BLLogin objBLLogin = new BLLogin();

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(objBLLogin.key))
                    }
                });
        }
    }
}
