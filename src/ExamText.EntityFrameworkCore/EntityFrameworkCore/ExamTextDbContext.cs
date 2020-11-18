using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ExamText.Authorization.Roles;
using ExamText.Authorization.Users;
using ExamText.MultiTenancy;

namespace ExamText.EntityFrameworkCore
{
    public class ExamTextDbContext : AbpZeroDbContext<Tenant, Role, User, ExamTextDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ExamTextDbContext(DbContextOptions<ExamTextDbContext> options)
            : base(options)
        {
        }
    }
}
