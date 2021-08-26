﻿using CafeMVC.Domain.Model;
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
            List<Customer> AllCustomers = new();

            Customer customer1 = new()
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
                        Name = "Adres rozliczeniowy"
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
                        Name = "Adres dostawy"
                    }
                  }
                  
                },
                UserContactInformations = new List<ContactDetail>()
                {
                    new ContactDetail()
                    {
                        Id = 1,
                        ContactDetailInformation = "0783931456",
                        ContactDetailTypId = 1,
                        ContactDetailType = new ContactDetailType(){ Id = 1, Name = "Telfon Komórkowy"}
                        
                    },
                    new ContactDetail()
                    {
                        Id = 2,
                        ContactDetailInformation = "TomBradley@gmail.com",
                        ContactDetailTypId = 2,
                        ContactDetailType = new ContactDetailType(){ Id = 2, Name = "E-mail"}

                    }

                }

            };


            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Harry",
                Surname = "Marley",
                Addresses = new List<Address>()
                {
                    new Address()
                    {
                    Id = 1,
                    BuildingNumber ="3",
                    FlatNumber = 5,
                    Street = "Aleja Wojska Polskiego",
                    City = "Kalisz",
                    ZipCode = "62-800",
                    Country = "Poland",
                    TypeId = 1,
                    AddressType = new AddressType()
                    {
                        Id = 1,
                        Name = "Adres rozliczeniowy"
                    }
                    },
                    new Address()
                  {
                        Id = 2,
                    BuildingNumber ="18",
                    FlatNumber = 23,
                    Street = "Serbinowska",
                    City = "Kalisz",
                    ZipCode = "62-800",
                    Country = "Poland",
                    TypeId = 2,
                    AddressType = new AddressType()
                    {
                        Id = 2,
                        Name = "Adres Dostawy"
                    }
                  }

                },
                UserContactInformations = new List<ContactDetail>()
                {
                    new ContactDetail()
                    {
                        Id = 1,
                        ContactDetailInformation = "608583619",
                        ContactDetailTypId = 1,
                        ContactDetailType = new ContactDetailType(){ Id = 1, Name = "Telfon Komórkowy"}

                    },
                    new ContactDetail()
                    {
                        Id = 2,
                        ContactDetailInformation = "HarryM@gmail.com",
                        ContactDetailTypId = 2,
                        ContactDetailType = new ContactDetailType(){ Id = 2, Name = "E-mail"}

                    }

                }

            };
            AllCustomers.Add(customer1);
            AllCustomers.Add(customer2);

            return AllCustomers;
        }
    }
}
