using AutoMapper;
using System;
using ToastNotifications;

namespace Ecom.Helpers
{
    public static class Globals
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IMapper Mapper { get; set; }

        public static Notifier Notifier { get; set; }

        public enum DaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
