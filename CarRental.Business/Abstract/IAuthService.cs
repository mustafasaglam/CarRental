using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Results;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegsterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
