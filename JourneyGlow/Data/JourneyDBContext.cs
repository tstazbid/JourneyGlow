using JourneyGlow.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JourneyGlow.Data
{
    public class JourneyDBContext : DbContext
    {
        public JourneyDBContext(DbContextOptions<JourneyDBContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLikes { get; set; }

        public DbSet<BlogPostComment> BlogPostComments { get; set; }
    }
}
