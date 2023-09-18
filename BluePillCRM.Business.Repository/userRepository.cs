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
            int type = await _table.Where(e => e.RoleId != 1).CountAsync();
            return type;
        }

        public async Task<User> FindOneByEmail(string email)
        {
            // User type = await _table.FirstOrDefaultAsync(u => u.Email == email && u.IsDisabled == false);
            User type = await _table.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
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
            User type = await _table.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
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
            bool exists = _table.AsNoTracking().Any(e => e.Id == id);

            if (exists)
            {
                User user = new()
                {
                    Id = id
                };
                RemoveTrack(user);
                return true;
            }
            return false;
        }

        public bool RemoveTrack(User user)
        {
            try
            {
                _table.Entry(user).State = EntityState.Detached;
                return true;
            } catch(Exception)
            {
                return false;
            }

    
        }
    }
}
