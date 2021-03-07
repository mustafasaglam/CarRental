using CarRental.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2).MaximumLength(100);
            RuleFor(c => c.ModelYear).NotEmpty();

            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(2000); //Fiyatı 200den fazla olmalı

            RuleFor(c => c.Name).Must(EndWith); //Araç ismi ğ ile bitemez.Kendimiz zel yazdık ve aşağıdada metodunu yazdık

        }

        private bool EndWith(string arg)
        {
            return arg.EndsWith("ğ");
        }
    }
}
