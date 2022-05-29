using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Library.Services.Impl.Service)))
            {
                host.Open();
                Console.WriteLine("Хост стартовал");
                Console.ReadLine();
            }
        }
    }
}