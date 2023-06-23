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

        public static List<readUser> ReadUserListMapper(List<User> users)
        {
            List<readUser> userList = new List<readUser>();

            foreach (var user in users)
            {
                readUser readUser = ReadUserMapper(user);
                userList.Add(readUser);
            }

            return userList;
        }
    }
}
