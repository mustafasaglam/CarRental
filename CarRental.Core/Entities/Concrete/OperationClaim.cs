using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Entities.Concrete //Name Spaceleri de düzletmek gerekecek Core a taşıdıktan sonra
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
