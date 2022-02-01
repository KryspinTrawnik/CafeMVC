using CafeMVC.Application.ViewModels.Customer;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface IContactDetailService
    {

        void AddNewContactDetail(ContactInfoForCreationVm contactDetail);

        void ChangeContactDetails(ContactInfoForCreationVm contactDetail);

        void RemoveContactDetail(int contactDetailId);

        List<ContactDetailTypeForViewVm> GetAllContactDetailTypes();

        ContactInfoForCreationVm GetContactDetailForEdition(int contactDetailId);

    }
}
