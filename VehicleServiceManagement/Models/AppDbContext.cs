using Microsoft.EntityFrameworkCore;

namespace VehicleServiceManagement.Models
{
    //To configure Db context inherit in AppDbcontext
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
