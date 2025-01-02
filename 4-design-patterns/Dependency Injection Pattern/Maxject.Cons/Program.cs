using System;
using Maxject.Core.Services;
using Maxject.Cons.Services;
using Maxject.Core.DependencyInjection;

namespace Maxject.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create container and register all possible dependencies
            var container = new MaxjectContainer();
            container.Register<ITimeOfDayService, TimeOfDayService>(); // A TimeOfDayService has no other dependencies that need to be injected
            container.Register<IHelloService, HelloService>(); // A Hello service has a dependency on a hello repository
            container.Register<ISuperHelloService, SuperHelloService>(); // A super hello services has a dependency on a hello service (and thus also on a repository)

            //Add container to resolver
            var resolver = new MaxjectResolver(container);

            //Do resolving stuff ... (all dependencies are automatically resolved)
            var helloRepo = resolver.Resolve<ITimeOfDayService>();
            var helloService = resolver.Resolve<IHelloService>();
            var superhelloService = resolver.Resolve<ISuperHelloService>();

            Console.WriteLine(helloRepo.GetTimeOfDay()); 
            Console.WriteLine(helloService.GetHello()); 
            Console.WriteLine(superhelloService.GetSuperHello()); 
        }
    }
}
