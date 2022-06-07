using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


           base.OnModelCreating(builder);

            //builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            //builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            //builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(200));


            ////builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            ////builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));


            ////builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            ////builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            ////builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(200));

            ////builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            ////builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));
        }
    }
}
