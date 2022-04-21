using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>context):base(context)
        {
             
        }
        public DbSet<User> Users { get; set; }
    }
}
