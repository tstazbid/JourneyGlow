using JourneyGlow.Data;
using JourneyGlow.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JourneyGlow.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly JourneyDBContext journeyDBContext;

        public TagRepository(JourneyDBContext journeyDBContext)
        {
            this.journeyDBContext = journeyDBContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await journeyDBContext.Tags.AddAsync(tag);
            await journeyDBContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await journeyDBContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                journeyDBContext.Tags.Remove(existingTag);
                await journeyDBContext.SaveChangesAsync(); 
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await journeyDBContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return journeyDBContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await journeyDBContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await journeyDBContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
