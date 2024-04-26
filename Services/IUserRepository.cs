using Labb3_API.Models;
using Microsoft.AspNetCore.Identity;

namespace Labb3_API.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<Interest>> GetUserInterests(int userId);
        Task <IEnumerable<Link>> GetUserLinks(int userId);
        Task AddInterestToUser(int userId, int interestId);
        Task AddLinkToUserInterest(int userId, int interestId, string url);
    }
}
