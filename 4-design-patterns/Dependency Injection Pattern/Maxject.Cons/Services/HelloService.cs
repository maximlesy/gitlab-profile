using Maxject.Core.Services;
using System;

namespace Maxject.Cons.Services
{
    public class HelloService : IHelloService
    {
        private readonly ITimeOfDayService timeOfDayService;
        public HelloService(ITimeOfDayService timeOfDayService)
        {
            this.timeOfDayService = timeOfDayService;
        }
        public string GetHello()
        {
            var now = DateTime.Now;
            return $"{timeOfDayService.GetTimeOfDay()}, het is {now.Hour}:{now.Minute}";


        }
    }
}
