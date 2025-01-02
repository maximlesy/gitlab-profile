using Maxject.Core.Services;

namespace Maxject.Cons.Services
{
    public class SuperHelloService : ISuperHelloService
    {
        private readonly IHelloService baseHelloService;
        public SuperHelloService(IHelloService service)
        {
            baseHelloService = service;
        }

        public string GetSuperHello()
        {
            return baseHelloService.GetHello() + "!!!!!!!";
        }
    }
}
