using Microsoft.EntityFrameworkCore;

namespace WEEK7APIFINALSOULTION
{
    public class ActivityContexts: DbContext
    {
        public ActivityContexts(DbContextOptions options): base(options) { }
        public DbSet<Activity> Activitives { get; set; }
    }
}
