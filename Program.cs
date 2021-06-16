using heroesCompanyAngular.Log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace heroesCompanyAngular {
    public class Program {

        public static void Main(string[] args) {
            Logger.StartLogging();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
