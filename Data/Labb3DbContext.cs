using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Data
{
    public class Labb3DbContext : DbContext
    {
        public Labb3DbContext(DbContextOptions<Labb3DbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User { UserID = 1, UserName = "Noah", PhoneNumber = "1234567" });
            modelBuilder.Entity<User>().HasData(new User { UserID = 2, UserName = "Simon", PhoneNumber = "1234567" });
            modelBuilder.Entity<User>().HasData(new User { UserID = 3, UserName = "Casper", PhoneNumber = "1234567" });
            modelBuilder.Entity<User>().HasData(new User { UserID = 4, UserName = "Svante", PhoneNumber = "1234567" });
            



            modelBuilder.Entity<Interest>().HasData(new Interest 
            { 
                InterestID = 100, 
                Title = "Gaming", 
                Description = "Playing video games"
                
            });
            modelBuilder.Entity<Interest>().HasData(new Interest 
            { 
                InterestID = 101, 
                Title = "Exercise", 
                Description = "Any type of exercise like running, sports or gym" 
            });
            modelBuilder.Entity<Interest>().HasData(new Interest 
            {
                InterestID = 102, 
                Title = "Reading", 
                Description = "Reading books"
                
            });
            modelBuilder.Entity<Interest>().HasData(new Interest 
            { 
                InterestID = 103, 
                Title = "Football", 
                Description = "Watching or playing football" 

            });
           


            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 50, URL = "www.youtube.com", UserInterestID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 51, URL = "www.transfermarkt.com", UserInterestID = 1 });
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 52, URL = "www.books.com", UserInterestID = 2});
            modelBuilder.Entity<Link>().HasData(new Link { LinkID = 53, URL = "www.running.com", UserInterestID = 2 });
           



            modelBuilder.Entity<UserInterest>().HasData(new UserInterest 
            { 
                UserInterestID = 1,
                UserID = 1, 
                InterestID = 100, 
            });

            modelBuilder.Entity<UserInterest>().HasData(new UserInterest
            {
                UserInterestID = 2,
                UserID = 2,
                InterestID = 102,
            });






        }
    }
}
