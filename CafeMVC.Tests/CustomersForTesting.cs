using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Tests
{
    public class CustomersForTesting
    {
        public List<Customer> AllCustomersForTesting()
        {
            List<Customer> AllCustomers = new List<Customer>();

            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Tom",
                Surname = "Bradley",
                Addresses = new List<Address>()
                { 
                    new Address()
                    { 
                    Id = 1,
                    BuildingNumber ="1",
                    Street = "Grecka",
                    City = "Kalisz",
                    ZipCode = "62-800",
                    Country = "Poland",
                    TypeId = 1,
                    AddressType = new AddressType()
                    {
                        Id = 1,
                        Name = "HomeAdress"
                    }
                    },
                    new Address()
                  {
                        Id = 2,
                    BuildingNumber ="4",
                    Street = "Budowlanych",
                    City = "Kalisz",
                    ZipCode = "62-800",
                    Country = "Poland",
                    TypeId = 2,
                    AddressType = new AddressType()
                    {
                        Id = 2,
                        Name = "DeliveryAdress"
                    }
                  }
                  
                },
                UserContactInformations = new List<CustomerContactInformation>()
                {
                    new CustomerContactInformation()
                    {
                        Id = 1,
                        ContactDetailInformation = "0783931456",
                        ContactDetailTypId = 1,
                        ContactDetailInfotmationType = new ContactDetailInfotmationType(){ Id = 1, Name = "Telfon Komórkowy"}
                        
                    },
                    new CustomerContactInformation()
                    {
                        Id = 2,
                        ContactDetailInformation = "TomBradley@gmail.com",
                        ContactDetailTypId = 2,
                        ContactDetailInfotmationType = new ContactDetailInfotmationType(){ Id = 2, Name = "E-mail"}

                    }

                }

            };


            return AllCustomers;
        }
    }
}
