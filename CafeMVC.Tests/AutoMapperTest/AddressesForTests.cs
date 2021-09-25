//using AutoMapper;
//using CafeMVC.Application.Interfaces.Mapping;
//using CafeMVC.Application.ViewModels.Customer;
//using CafeMVC.Domain.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CafeMVC.Tests.AutoMapperTest.CustomerVmTests
//{
//    public class AddressesForTests
//    {
//        public Address GetAdrressForTest()
//        {
//            var address = new Address()
//            {
//                Id = 1,
//                BuildingNumber = "3",
//                FlatNumber = 5,
//                Street = "Aleja Wojska Polskiego",
//                City = "Kalisz",
//                ZipCode = "62-800",
//                Country = "Polska",
//                AddressTypeId = 1,
//                AddressType = new AddressType()
//                {
//                    Id = 1,
//                    Name = "Adres rozliczeniowy"
//                }
//            };
//            return address;
//        }
//        public AddressDetailsForViewVm GetExpectedViewModelOfShortAdrressForTest()
//        {
//            var expectedAddress = new AddressDetailsForViewVm()
//            {
//                Id = 1,
//                Address = "Aleja Wojska Polskiego 3/5",
//                City = "Kalisz",
//                ZipCode = "62-800",
//                Country = "Polska",
//                Type = "Adres rozliczeniowy"

//            };
//            return expectedAddress;
//        }

//        public AddressForSummaryVm GetExpectedViewModelOfLongAdrressForTest()
//        {
//            var expectedAddress = new AddressForSummaryVm()
//            {
//                Id = 1,
//                Address = "Aleja Wojska Polskiego 3/5"
//                + "\n" + "62-800"
//                + "\n" + "Kalisz",
//                Type = "Adres rozliczeniowy"

//            };
//            return expectedAddress;
//        }
//    }
//}
