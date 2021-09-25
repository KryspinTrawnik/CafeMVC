//using CafeMVC.Domain.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CafeMVC.Tests
//{
//    public class OrdersForTesting
//    {
//        public List<Order> OrdersOfCustomersOne()
//        {
            

//            Order order1Customer1 = new Order()
//            {
//                Id = 1,
//                DateOfOrder = new DateTime(2021, 06, 30, 8, 0, 0),
//                LeadTime = new DateTime(2021, 06, 30, 10, 0, 0),
//                Products = new List<Product>(),
//                HasBeenDone = true,
//                IsCollection = true,
//                Note = "1blabla",
//                CustomerId = 1,
//                Addresses = new List<Address>()
//                {
//                    new Address()
//                    {
//                    Id = 1,
//                    BuildingNumber ="1",
//                    Street = "Grecka",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 1,
//                    AddressType = new AddressType()
//                    {
//                        Id = 1,
//                        Name = "Adres rozliczeniowy"
//                    }
//                    },
//                    new Address()
//                  {
//                        Id = 2,
//                    BuildingNumber ="4",
//                    Street = "Budowlanych",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 2,
//                    AddressType = new AddressType()
//                    {
//                        Id = 2,
//                        Name = "Adres dostawy"
//                    }
//                  }
//                }
//            };
//            Order order2Customer1 = new Order()
//            {
//                Id = 2,
//                DateOfOrder = new DateTime(2021, 07, 01, 14, 0, 0),
//                LeadTime = new DateTime(2021, 07, 1, 16, 0, 0),
//                Products = new List<Product>(),
//                HasBeenDone = false,
//                IsCollection = true,
//                Note = "1blabla",
//                CustomerId = 1,
//                Addresses = new List<Address>()
//                {
//                    new Address()
//                    {
//                    Id = 1,
//                    BuildingNumber ="1",
//                    Street = "Grecka",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 1,
//                    AddressType = new AddressType()
//                    {
//                        Id = 1,
//                        Name = "Adres rozliczeniowy"
//                    }
//                    },
//                    new Address()
//                  {
//                        Id = 2,
//                    BuildingNumber ="4",
//                    Street = "Budowlanych",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 2,
//                    AddressType = new AddressType()
//                    {
//                        Id = 2,
//                        Name = "Adres dostawy"
//                    }
//                  }
//                }
//            };
//            List<Order> listOfOrdersCustomerOne = new List<Order>()
//            { order1Customer1,
//                order2Customer1
//            };

//            return listOfOrdersCustomerOne;
//        }

//        public List<Order> OrdersOfCustomersTwo()
//        {


//            Order order1Customer2 = new Order()
//            {
//                Id = 3,
//                DateOfOrder = new DateTime(2021, 07, 30, 16, 0, 0),
//                LeadTime = new DateTime(2021, 07, 30, 16, 0, 0),
//                Products = new List<Product>(),
//                HasBeenDone = false,
//                IsCollection = true,
//                Note = "1blabla",
//                CustomerId = 2,
//                Addresses = new List<Address>()
//                {
//                    new Address()
//                    {
//                    Id = 1,
//                    BuildingNumber ="3",
//                    FlatNumber = 5,
//                    Street = "Aleja Wojska Polskiego",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 1,
//                    AddressType = new AddressType()
//                    {
//                        Id = 1,
//                        Name = "Adres rozliczeniowy"
//                    }
//                    },
//                    new Address()
//                  {
//                        Id = 2,
//                    BuildingNumber ="18",
//                    FlatNumber = 23,
//                    Street = "Serbinowska",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 2,
//                    AddressType = new AddressType()
//                    {
//                        Id = 2,
//                        Name = "Adres Dostawy"
//                    }
//                  }

//                }
//            };
//            Order order2Customer2 = new Order()
//            {
//                Id = 4,
//                DateOfOrder = new DateTime(2021, 07, 21, 14, 0, 0),
//                LeadTime = new DateTime(2021, 07, 21, 16, 0, 0),
//                Products = new List<Product>(),
//                HasBeenDone = false,
//                IsCollection = true,
//                Note = "1blabla",
//                CustomerId = 2,
//                Addresses = new List<Address>()
//                {
//                    new Address()
//                    {
//                    Id = 1,
//                    BuildingNumber ="3",
//                    FlatNumber = 5,
//                    Street = "Aleja Wojska Polskiego",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 1,
//                    AddressType = new AddressType()
//                    {
//                        Id = 1,
//                        Name = "Adres rozliczeniowy"
//                    }
//                    },
//                    new Address()
//                  {
//                        Id = 2,
//                    BuildingNumber ="18",
//                    FlatNumber = 23,
//                    Street = "Serbinowska",
//                    City = "Kalisz",
//                    ZipCode = "62-800",
//                    Country = "Poland",
//                    AddressTypeId = 2,
//                    AddressType = new AddressType()
//                    {
//                        Id = 2,
//                        Name = "Adres Dostawy"
//                    }
//                  }

//                }
//            };
//            List<Order> listOfOrdersCustomerTwo = new List<Order>()
//            { order1Customer2,
//                order2Customer2
//            };

//            return listOfOrdersCustomerTwo;
//        }

//        public List<Order> GetAllOrdersForTesting()
//        {
//            var listOfAllOrders = OrdersOfCustomersOne();

//            var ordersOfCustomersTwo = OrdersOfCustomersTwo();
//            listOfAllOrders.AddRange(ordersOfCustomersTwo);

//            return listOfAllOrders;
//        }
//    }
//}
