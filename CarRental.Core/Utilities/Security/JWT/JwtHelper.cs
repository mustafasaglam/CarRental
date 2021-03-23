using CarRental.Core.Entities.Concrete;
using CarRental.Core.Extensions;
using CarRental.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration; //Iconfiguration için using e eklenir
using Microsoft.IdentityModel.Tokens; //SymetricSecurityKey için
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarRental.Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper //ITokenHelperdır diyoruz
    {
        //appsettings.json dosyasını okuyacağız
        public IConfiguration Configuration { get; } //IConfigaration nesnemiz ile appsettings.json deki bilgilerimizi okuyacağız
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration) //constructurda ekliyruz
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //Bu şekilde appsettings den gelecek verileri tokenoptions içine atmış oluyoruz. sonra Create token içini yazabilirz
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpration); //appsettings.jsondaki dk cinsinden gelen değeri ilk başta constructurda set ediyoruz ihtiyacımız olduğunda kullnacağız
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //Encryption içindeki sınıfı ve metodu kullanarak bize bir security key oluştur diyoruz.Yani bir anahtar oluyor

            //Şimdi Signing Credential helper la devam eidyoruz. Yine Encryption altında SigningCredentialHelper ı yazıyoruz.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };


            
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now, //Token in expration bilgiisi şuandan önce ise geçerli değil demek
                claims:SetClaims(user,operationClaims),
                signingCredentials:signingCredentials

                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //claims.Add(new Claim("email", user.Email)); claim nesnesinde extend edilecek nesneler için Extensions nesnesini yazalım

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); //list of operation claims den gelen verieri string array olarak verdik
            return claims;
        }
    }
}
