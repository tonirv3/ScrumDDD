using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Scrum.BC.Api.Extensions
{
    static class HostExtensions
    {
        public static IHost MigrateDbContext<T>(this IHost host, Action<T, IServiceProvider> action = null) where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<T>();
                action?.Invoke(db, scope.ServiceProvider);

                db.Database.Migrate();
            }

            return host;
        }
    }
}
