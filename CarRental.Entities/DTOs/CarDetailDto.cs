using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
