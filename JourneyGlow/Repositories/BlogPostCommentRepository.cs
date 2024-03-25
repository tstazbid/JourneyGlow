using JourneyGlow.Data;
using JourneyGlow.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JourneyGlow.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly JourneyDBContext journeyDBContext;

        public BlogPostCommentRepository(JourneyDBContext journeyDBContext) {
            this.journeyDBContext = journeyDBContext;
        }


        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await journeyDBContext.BlogPostComments.AddAsync(blogPostComment);
            await journeyDBContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await journeyDBContext.BlogPostComments.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
