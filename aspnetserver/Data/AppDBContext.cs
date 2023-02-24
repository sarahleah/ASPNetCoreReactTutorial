using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    // usually just use {{name}}DBContext
    internal sealed class AppDBContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];

            for (int i = 0; i < 6; i++)
            {
                postsToSeed[i] = new Post
                {
                    PostId = i,
                    Title = $"Post #{i} is here",
                    Content = $"This is some very interesting content. Woah is that a fricking pinncle of ice?"
                };

                modelBuilder.Entity<Post>().HasData(postsToSeed);
            }
        }
    }
}
