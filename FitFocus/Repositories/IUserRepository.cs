using Microsoft.AspNetCore.Identity;

namespace FitFocus.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
