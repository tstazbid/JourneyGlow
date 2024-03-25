using JourneyGlow.Data;
using JourneyGlow.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JourneyGlow.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly JourneyDBContext journeyDBContext;

        public BlogPostRepository(JourneyDBContext journeyDBContext)
        {
            this.journeyDBContext = journeyDBContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await journeyDBContext.AddAsync(blogPost);
            await journeyDBContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await journeyDBContext.BlogPosts.FindAsync(id);

            if(existingBlog != null)
            {
                journeyDBContext.BlogPosts.Remove(existingBlog);
                await journeyDBContext.SaveChangesAsync();

                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await journeyDBContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await journeyDBContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await journeyDBContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await journeyDBContext.BlogPosts.Include(x=> x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
   
            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.Author = blogPost.Author;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;

                await journeyDBContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
