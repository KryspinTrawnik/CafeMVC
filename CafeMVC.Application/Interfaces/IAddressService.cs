using CafeMVC.Application.Services;
using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Domain.Model;
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

        Task <List<AddressTypeVm>> GetAllAddressTypes();

        void DeleteAddress(int addressId);

        Task<List<AddressForSummaryVm>> GetAllAddressesByCustomerId(int customerId);

        Address PrepareAddressToSave(AddressForCreationVm address);
        AddressForOrderViewVm GetAddressToview(int id);
        List<AddressForOrderViewVm> GetCustmersDeliveryAddresses(int id);

        List<AddressForCreationVm> GetAllAddressesForCreationByCustomerId(int customerId);
    }
}
