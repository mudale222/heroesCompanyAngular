using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(heroesCompany.Areas.Identity.IdentityHostingStartup))]
namespace heroesCompany.Areas.Identity {
    public class IdentityHostingStartup : IHostingStartup {
        public void Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}