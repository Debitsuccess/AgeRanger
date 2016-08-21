using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AgeRanger.ConfigTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var connectionStringConfig = builder.Build();

            Console.WriteLine(connectionStringConfig.GetConnectionString("DefaultConnection"));
        }
    }
}
