using CafeMVC.Application.ViewModels.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IAddressService
    {
        void AddNewAddress(AddressForCreationVm address);

        AddressForCreationVm GetAddressToEdit(int addressId);

        void ChangeCustomerAddress(AddressForCreationVm address);

        CustomerForCreationVm SetInitialContactsAndAddressesTypes(CustomerForCreationVm newCreatedCustomer);

        List<AddressTypeVm> GetAllAddressTypes();

        void DeleteAddress(int addressId);

        Task<List<AddressForSummaryVm>> GetAllAddressesByCustomerId(int customerId);
    }
}
