using Microsoft.AspNetCore.Identity;

namespace JourneyGlow.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
