using System.IO;

using Microsoft.AspNetCore.Hosting;

namespace WebApi
{
// ReSharper disable once UnusedMember.Global
	public static class Program
	{
// ReSharper disable once UnusedMember.Global
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
