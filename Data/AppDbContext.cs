using Microsoft.EntityFrameworkCore;

namespace microprojeto_aspnet_PersonalBudget.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
