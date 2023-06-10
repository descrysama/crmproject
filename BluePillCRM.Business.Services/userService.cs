using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;
using BluePillCRM.Business.Services.Utilities;

namespace BluePillCRM.Business.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository repositoryUser)
        {
            _userRepository = repositoryUser;
        }

        public async Task<User> FindOneById(int id)
        {
            User user = await _userRepository.GetById(id).ConfigureAwait(false);
            return user;
        }

        public async Task<User> FindOneByEmail(string email)
        {
            User user = await _userRepository.FindOneByEmail(email).ConfigureAwait(false);
            return user;
        }

        public async Task<User> FindOneByUsername(string username)
        {
            User user = await _userRepository.FindOneByUsername(username).ConfigureAwait(false);
            return user;
        }


        public async Task<User> CreateUser(createUser userToCreate)
        {
            User checkIfEmailIsUsed = await this.FindOneByEmail(userToCreate.Email);
            User checkIfUsernameIsUsed = await this.FindOneByUsername(userToCreate.Username);
            if (checkIfEmailIsUsed == null && checkIfUsernameIsUsed == null)
            {
                userToCreate.Password = PasswordHandler.HashPassword(userToCreate.Password);
                User user = await _userRepository.Insert(UserDtoToEntity.createUserMapper(userToCreate)).ConfigureAwait(false);
                return user;
            } else
            {
                throw new Exception("Un utilisateur avec la même adresse email et/ou le même nom d'utilisateur existe déjà.");
            }

        }

        public async Task<User> UpdateUser(updateUser userToUpdate)
        {
            User user = await _userRepository.Insert(UserDtoToEntity.updateUserMapper(userToUpdate)).ConfigureAwait(false);
            return user;
        }



        public async Task<User> DisableUser(int id)
        {
            User user = await _userRepository.Update(UserDtoToEntity.deleteUserMapper(id)).ConfigureAwait(false);
            return user;
        }
    }
}
