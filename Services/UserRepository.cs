using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class UserRepository : IUser
    {
        private Labb3DbContext _labb3Dbcontext;

        public UserRepository(Labb3DbContext labb3Dbcontext)
        {
            _labb3Dbcontext = labb3Dbcontext;
        }

        public async Task AddInterestToUser(int userId, int interestId)
        {
            //för att undvika duplicering utav samma intresse
            var existUserInterest = await _labb3Dbcontext.UserInterests
                .FirstOrDefaultAsync(u => u.UserID == userId && u.InterestID == interestId);

            if (existUserInterest == null)
            {
                var result = new UserInterest
                {
                    UserID = userId,
                    InterestID = interestId
                };
                _labb3Dbcontext.UserInterests.Add(result);
                await _labb3Dbcontext.SaveChangesAsync();

            }
        }

        public async Task AddLinkToUserInterest(int userId, int interestId, string url)
        {

            var userInterest = await _labb3Dbcontext.UserInterests
                .Include(u => u.Links).FirstOrDefaultAsync(u => u.UserID == userId && u.InterestID == interestId);

            if(userInterest != null)
            {
                userInterest.Links.Add(new Link { URL = url });
                await _labb3Dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _labb3Dbcontext.Users.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetAllInterests()
        {
            return await _labb3Dbcontext.Interests.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetUserInterests(int userId)
        {
            return await _labb3Dbcontext.UserInterests.Where(u => u.UserID == userId)
                .Select(u => u.Interest).ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetUserLinks(int userId)
        {
            return await _labb3Dbcontext.UserInterests.Where(u => u.UserID == userId)
                .SelectMany(u => u.Links).ToListAsync();
        }

        public async Task<bool> UserExists(int userId)
        {
            return await _labb3Dbcontext.Users.AnyAsync(u => u.UserID == userId);

        }
    }
}
