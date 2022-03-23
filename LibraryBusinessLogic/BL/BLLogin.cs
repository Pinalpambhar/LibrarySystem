using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryBusinessLogic.BL
{
    public class BLLogin : DBManager
    {
        #region Public Members
        public string key = "PUH%KTND#J%!1TBD";
        #endregion

        #region Private Members
        Cryptography objCryptography = new Cryptography();
        #endregion

        #region Public Method
        /// <summary>
        /// Checks if User is Valid or not
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns></returns>
        public string Authentication(Login objLogin)
        {
            List<Login> lstUserDetails = new List<Login>();
            var dbFactory = GetConnection();

            try
            {
                using (var db = dbFactory.Open())
                {
                    objLogin.b01f06 = objCryptography.Encrypt(objLogin.b01f06);
                    lstUserDetails = db.Select<Login>(db.From<lib01>()
                                     .Where(x => x.b01f02 == objLogin.b01f02 && x.b01f06 == objLogin.b01f06)
                                     .Select(x => new { x.b01f02, x.b01f06, x.b01f07 }));                
                }
                if (lstUserDetails.Count != 0)
                {
                    return GetToken(objLogin.b01f02, lstUserDetails[0].b01f07);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Generates JwtToken
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        private string GetToken(string userName, int role)
        {
            SymmetricSecurityKey SigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(
                                claims: new Claim[]
                                {
                                     new Claim(ClaimTypes.Name, userName),
                                     new Claim(ClaimTypes.Role, role.ToString())
                                },
                                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                                signingCredentials: new SigningCredentials(SigninKey, SecurityAlgorithms.HmacSha256)
                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion Private Methods
    }
}
