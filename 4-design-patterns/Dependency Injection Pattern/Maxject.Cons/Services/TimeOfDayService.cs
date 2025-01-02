using System;
using Maxject.Core.Services;

namespace Maxject.Cons.Services
{
    public class TimeOfDayService : ITimeOfDayService
    {
        public string GetTimeOfDay()
        {
            DateTime now = DateTime.Now;

            if (now.Hour > 0 && now.Hour < 6) return "Goeienacht";
            if (now.Hour >= 6 && now.Hour < 12) return "Goeiemorgen";
            if (now.Hour >= 12 && now.Hour < 18) return "Goeiemiddag";
            return "Goeieavond";
        }
    }
}
