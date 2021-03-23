using CarRental.Core.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims); //User bilgisi ve operasyonclaim leirni vermiş oluyoruz
        //Burada User OperationClaim ve UserOperationClaim Nesneleri Core altındaki entities altındaki Concrete klasörü altına taşınır. Tabi bu şekilde using i bozulmuş tüm referasnlar yeniden çözülür.***

    }
}
