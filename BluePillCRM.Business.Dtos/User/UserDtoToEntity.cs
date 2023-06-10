using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Dtos
{
    public class UserDtoToEntity
    {
        public static User createUserMapper(createUser createUser)
        {
            User user = new User()
            {
                Username = createUser.Username.ToLower(),
                Email = createUser.Email.ToLower(),
                Password = createUser.Password,
                Name = createUser.Name.ToLower(),
                LastName = createUser.LastName,
                Title = createUser.Title,
                RoleId = createUser.RoleId
            };

            return user;
        }

        public static User updateUserMapper(updateUser updateUser)
        {
            User user = new User()
            {
                Username = updateUser.Username,
                Email = updateUser.Email,
                Password = updateUser.Password,
                Name = updateUser.Name,
                LastName = updateUser.LastName,
                Title = updateUser.Title,
                RoleId = updateUser.RoleId
            };

            return user;
        }

        public static User deleteUserMapper(int Id)
        {
            User user = new User()
            {
                Id = Id,
                IsDisabled = true 
            };

            return user;
        }
    }
}
