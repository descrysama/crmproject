using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Business.Services
{
    public class CrmConfigService
    {
        private readonly CrmConfigRepository _crmConfigRepository;

        private readonly UserRepository _userRepository;

        public CrmConfigService(CrmConfigRepository crmConfigRepository, UserRepository repositoryUser)
        {
            _crmConfigRepository = crmConfigRepository;
            _userRepository = repositoryUser;
        }

        // Recupère la config de la CRM + le nombre total d'utilisateurs puis retourn true si l'utilisateur peut toujours créer des users sinon false.
        public async Task<bool> IsAllowedToCreateUser()
        {
            try
            {
                CrmConfig crmConfig = await _crmConfigRepository.GetCrmConfig(1);
                int countTotalUsers = await _userRepository.CountTotalUsers();

                if (countTotalUsers - 1 < crmConfig.MaxUsers)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("Une erreur s'est produite. Utilisateur non crée.");
            }
        }
    }
}