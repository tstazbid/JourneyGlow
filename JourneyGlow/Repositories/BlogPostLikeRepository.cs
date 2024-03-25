
using JourneyGlow.Data;
using JourneyGlow.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JourneyGlow.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly JourneyDBContext journeyDBContext;

        public BlogPostLikeRepository(JourneyDBContext journeyDBContext)
        {
            this.journeyDBContext = journeyDBContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await journeyDBContext.BlogPostLikes.AddAsync(blogPostLike);
            await journeyDBContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await journeyDBContext.BlogPostLikes.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await journeyDBContext.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
