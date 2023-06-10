using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class UserEntityToDto
    {
        public static readUser ReadUserMapper(User entityUser)
        {
            readUser user = new readUser()
            {
                Username = entityUser.Username,
                Email = entityUser.Email,
                Name = entityUser.Name,
                LastName = entityUser.LastName,
                Title = entityUser.Title,
                RoleId = entityUser.RoleId
            };

            return user;
        }
    }
}
