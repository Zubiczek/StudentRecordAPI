using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.Database;

namespace StudentRecordAPI.ServiceExtensions
{
    public static class DatabaseConnection
    {
        public static void AddConnection(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer((Configuration.GetConnectionString("StudentRecordContext"))));
        }
    }
}
