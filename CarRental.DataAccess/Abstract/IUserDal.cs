using CarRental.Core.DataAccess;
using CarRental.Core.Entities.Concrete;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);  //bir join operasyonudur
    }
}
