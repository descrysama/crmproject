using BluePillCRM.Business.Repository;
using BluePillCRM.Datas.Entities;
using BluePillCRM.Business.Dtos;

namespace BluePillCRM.Business.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // Fetch d'un addresse par son id
        public async Task<Address> GetAddress(int id)
        {
            try
            {
                return await _addressRepository.GetById(id).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Une erreur s'est produite. Adresse non trouvée.");
            }
        }
        // Création d'une address Street, City, PostalCode, CountryId, le niveau d'accès de cette adresse et l'id du user ayant fait la modification.
        public async Task<Address> CreateAddress(createAddress addressToCreate)
        {
            try
            {
                return await _addressRepository.Insert(dtoToEntity.createAddressMapper(addressToCreate)).ConfigureAwait(false);
            } catch
            {
                throw new Exception("Une erreur s'est produite. Adresse non crée, veuillez verifier vos entrées.");
            }
        }

        // Mise à jour d'une addresse prenant uniquement Street, City, PostalCode, CountryId et AccessLevel.
        public async Task<Address> UpdateAddress(updateAddress addressToUpdate)
        {
            try
            {
                return await _addressRepository.Update(dtoToEntity.updateAddressMapper(addressToUpdate)).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Une erreur s'est produite. Adresse non modifié.");
            }
        }

        // Suppression d'une addresse par son id.
        public async Task<Address> DeleteAddress(int addressId)
        {
            try
            {
                return await _addressRepository.Delete(dtoToEntity.deleteAddressMapper(addressId)).ConfigureAwait(false);
            }
            catch
            {
                throw new Exception("Une erreur s'est produite. Adresse non supprimée.");
            }
        }
    }
}