using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete.Managers;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Dataaccess
            builder.RegisterType<EfGameDal>().As<IGameDal>();
            builder.RegisterType<EfGameReviewDal>().As<IGamereviewDal>();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>();
            builder.RegisterType<EfGameLibraryDal>().As<IGameLibraryDal>();
            builder.RegisterType<EfPlayerDal>().As<IPlayerDal>();
            builder.RegisterType<EfLibraryGameDal>().As<ILibraryGameDal>();

            //Services
            builder.RegisterType<GameManager>().As<IGameService>();
            builder.RegisterType<GameReviewManager>().As<IGameReviewService>();
            builder.RegisterType<AdminManager>().As<IAdminService>();
            builder.RegisterType<GameLibraryManager>().As<IGameLibraryService>();
            builder.RegisterType<PlayerManager>().As<IPlayerService>();
            builder.RegisterType<LibraryGameManager>().As<ILibraryGameService>();

            



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
