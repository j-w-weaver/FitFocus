using FitFocus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitFocus.Data
{
    public class FitFocusDbContext : DbContext
    {
        public FitFocusDbContext(DbContextOptions<FitFocusDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set; }

        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
