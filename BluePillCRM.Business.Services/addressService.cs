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
        public async Task<Address> GetAddress(int id, int userRole)
        {
            try
            {
                Address address = await _addressRepository.GetById(id).ConfigureAwait(false);
                if(address.AccessLevel < userRole)
                {
                    throw new Exception("Vous ne pouvez pas accéder à cette ressource, elle outrepasse vos droits.");
                }
                return address;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Création d'une address Street, City, PostalCode, CountryId, le niveau d'accès de cette adresse et l'id du user ayant fait la modification.
        public async Task<Address> CreateAddress(createAddress addressToCreate)
        {
            try
            {
                return await _addressRepository.Insert(AddressDtoToEntity.createAddressMapper(addressToCreate)).ConfigureAwait(false);
            } catch
            {
                throw new Exception("Une erreur s'est produite. Adresse non crée, veuillez verifier vos entrées.");
            }
        }

        // Mise à jour d'une addresse prenant uniquement Street, City, PostalCode, CountryId et AccessLevel.
        public async Task<Address> UpdateAddress(updateAddress addressToUpdate, int userId)
        {
            try
            {
                Address CheckIfExists = await _addressRepository.GetById(addressToUpdate.Id).ConfigureAwait(false);
                if(CheckIfExists == null)
                {
                    throw new Exception("Cette adresse n'existe pas.");
                }
                addressToUpdate.ModifiedBy = userId;
                return await _addressRepository.Update(AddressDtoToEntity.updateAddressMapper(addressToUpdate, CheckIfExists)).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Suppression d'une addresse par son id.
        public async Task<Address> DeleteAddress(int addressId, int userRole)
        {
            try
            {
                Address address = await _addressRepository.GetById(addressId).ConfigureAwait(false);
                if (address.AccessLevel < userRole)
                {
                    throw new Exception("Vous ne pouvez pas agir sur cette ressource, elle outrepasse vos droits.");
                }
                _addressRepository.RemoveTrack(address);
                return await _addressRepository.Delete(AddressDtoToEntity.deleteAddressMapper(addressId)).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}