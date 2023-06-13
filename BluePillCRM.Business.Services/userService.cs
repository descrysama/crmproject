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

        public async Task<User> UpdateUser(UpdateUser userToUpdate)
        {
            User oldUser = await _userRepository.GetById(userToUpdate.Id).ConfigureAwait(false);
            userToUpdate.RoleId = oldUser.RoleId;
            userToUpdate.Password = oldUser.Password;
            _userRepository.RemoveTrack(oldUser);
            User user = await _userRepository.Update(UserDtoToEntity.updateUserMapper(userToUpdate)).ConfigureAwait(false);
            return user;
        }

        public async Task<bool> CheckIfExists(int id)
        {
            return await _userRepository.CheckIfExists(id).ConfigureAwait(false);
        }

        public async Task<User> DisableUser(int id, int RoleId)
        {
            User oldUser = await _userRepository.GetById(id).ConfigureAwait(false);
            if(oldUser.RoleId > RoleId)
            {
                _userRepository.RemoveTrack(oldUser);
                User user = await _userRepository.Update(UserDtoToEntity.deleteUserMapper(oldUser)).ConfigureAwait(false);
                return user;
            }

            throw new Exception("Vous ne pouvez pas supprimer ou desactiver un compte ayant un niveau d'accès supérieur au votre.");
        }
    }
}
