﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance(); //Bunun bir veri erişimi olmadığı için efAuth dal ksımını yapmadık. Ama user service bağımlılığnı bi yukarda verdik zaten
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance(); //Token helper için




            //Bu kısım sabit. Git bütün interfacelerı al ve aspectInterceptorSelector ile çalıştır demek için
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
