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
                RoleId = createUser.RoleId,
                CreatedAt = createUser.CreatedAt
            };

            return user;
        }

        public static User updateUserMapper(UpdateUser updateUser)
        {
            User user = new User()
            {
                Id = updateUser.Id,
                Username = updateUser.Username,
                Email = updateUser.Email,
                Name = updateUser.Name,
                RoleId = updateUser.RoleId,
                Password = updateUser.Password,
                LastName = updateUser.LastName,
                Title = updateUser.Title
            };

            return user;
        }

        public static User deleteUserMapper(User userToDisable)
        {
            User user = new User()
            {
                Id = userToDisable.Id,
                Username = userToDisable.Username,
                Email = userToDisable.Email,
                Password = userToDisable.Password,
                Title = userToDisable.Title,
                Name = userToDisable.Name,
                LastName= userToDisable.LastName,
                RoleId = userToDisable.RoleId,
                IsDisabled = true 
            };

            return user;
        }
    }
}
