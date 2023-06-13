using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
    public class UserRepository : GenericRepository<User>
    {

        public UserRepository(BluePillCRMDbContext bluePillCRMDbContext) : base(bluePillCRMDbContext)
        {
        }

        public async Task<int> CountTotalUsers()
        {
            int type = await _table.CountAsync();
            return type;
        }

        public async Task<User> FindOneByEmail(string email)
        {
            // User type = await _table.FirstOrDefaultAsync(u => u.Email == email && u.IsDisabled == false);
            User type = await _table.FirstOrDefaultAsync(u => u.Email == email);
            if (type == null)
            {
                return null;
            }
            else
            {
                return type;
            }
        }

        public async Task<User> FindOneByUsername(string username)
        {
            User type = await _table.FirstOrDefaultAsync(u => u.Username == username);
            if (type == null)
            {
                return null;
            }
            else
            {
                return type;
            }
        }

        public async Task<bool> CheckIfExists(int id)
        {
            bool exists = _table.Any(e => e.Id == id);

            if (exists)
            {
                return true;
            }
            return false;
        }

        public async void RemoveTrack(User user)
        {
            _table.Entry(user).State = EntityState.Detached;
    
        }
    }
}
