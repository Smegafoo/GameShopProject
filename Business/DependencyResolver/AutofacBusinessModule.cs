using Autofac;
using Business.Abstract;
using Business.Concrete.Managers;
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
            builder.RegisterType<EfGameDal>().As<IGameDal>().SingleInstance();
            //Services
            builder.RegisterType<GameManager>().As<IGameService>().SingleInstance();
        }
    }
}
