using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Business.Services.Utilities;

namespace BluePillCRM.Business.Services.Utilities
{
    public class UserUtilities
    {
        private readonly UserService _userService;

        public UserUtilities(UserService userService)
        {
            _userService = userService;
        }

        public async Task<int> CheckUserRole(int id)
        {
            User checkUserRole = await _userService.FindOneById(id);
            if(checkUserRole == null)
            {
                return 0;
            }

            return checkUserRole.RoleId;
        }
    }
}
