using System;

namespace ConsoleApp
{
    public sealed class Singleton
    {
        private static readonly Lazy<DateTime> lazy =
            new Lazy<DateTime>(() => DateTime.Now.AddDays(-2));

        public static DateTime Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
    }
}