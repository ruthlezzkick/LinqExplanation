using System;
using System.Collections.Generic;
using LinqExplanation.Domain;

namespace LinqExplanation
{
    public static class DomainFactory
    {
        public static  IEnumerable<Invoice> FakeInvoiceList()
        {
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                    Number = "Invoice1",
                    Customer = "Lidl",
                    City = "Warszawa",
                    CrtDate = new DateTime(2022,5,16),
                    Value = 13.7M,
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new InvoiceItem { InvoiceItemId = 1, ItemName = "Juice", Quantity = 30, Value = 3.5M},
                        new InvoiceItem { InvoiceItemId = 2, ItemName = "Water", Quantity = 5, Value = 6},
                        new InvoiceItem { InvoiceItemId = 3, ItemName = "Bread", Quantity = 80, Value = 4.2M},
                    }
                },
                new Invoice
                {
                    Id = 2,
                    Number = "Invoice2",
                    Customer = "Tesco",
                    City = "Warszawa",
                    CrtDate = new DateTime(2022,5,3),
                    Value = 42.9M,
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new InvoiceItem { InvoiceItemId = 4, ItemName = "Juice", Quantity = 20, Value = 3.5M},
                        new InvoiceItem { InvoiceItemId = 5, ItemName = "Beer", Quantity = 5, Value = 6},
                        new InvoiceItem { InvoiceItemId = 6, ItemName = "Coffee", Quantity = 20, Value = 18.8M},
                        new InvoiceItem { InvoiceItemId = 7, ItemName = "Sugar", Quantity = 15, Value = 4.8M},
                        new InvoiceItem { InvoiceItemId = 8, ItemName = "Apple", Quantity = 26, Value = 9.8M},
                    }
                },
                new Invoice
                {
                    Id = 3,
                    Number = "Invoice3",
                    Customer = "Auchan",
                    City = "Kraków",
                    CrtDate = new DateTime(2022,4,11),
                    Value = 21.5M,
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new InvoiceItem { InvoiceItemId = 7, ItemName = "Milk", Quantity = 25, Value = 2},
                        new InvoiceItem { InvoiceItemId = 8, ItemName = "Beer", Quantity = 50, Value = 4.5M},
                        new InvoiceItem { InvoiceItemId = 9, ItemName = "Coffee", Quantity = 200, Value = 15},
                    }
                },
                new Invoice
                {
                    Id = 4,
                    Number= "Invoice4",
                    Customer = "Auchan",
                    City = "Warszawa",
                    CrtDate = new DateTime(2022,4,17),
                    Value = 22M,
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new InvoiceItem { InvoiceItemId = 7, ItemName = "Milk", Quantity = 15, Value = 3},
                        new InvoiceItem { InvoiceItemId = 8, ItemName = "Sugar", Quantity = 40, Value = 4},
                        new InvoiceItem { InvoiceItemId = 9, ItemName = "Coffee", Quantity = 200, Value = 15},
                    }
                },
                new Invoice
                {
                    Id = 5,
                    Number = "Invoice5",
                    Customer = "Mila",
                    City = "Warszawa",
                    CrtDate = new DateTime(2022,4,20),
                    Value = 9M,
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new InvoiceItem { InvoiceItemId = 7, ItemName = "Milk", Quantity = 18, Value = 5},
                        new InvoiceItem { InvoiceItemId = 8, ItemName = "Water", Quantity = 10, Value = 4},
                    }
                }
            };
            return invoices;
        }
        public static IEnumerable<Driver> FakeDriverList()
        {
            var drivers = new List<Driver>
            {
                new Driver
                {
                    Name = "Paul",
                    Country = "NO",
                    Age = 44,
                    Car = new Car {Number = 17, CarBrand = "Ford", CarModel = "Focus", Color = "Blue", MaxSpeed = 220}
                },
                new Driver
                {
                    Name = "John",
                    Country = "DE",
                    Age = 24,
                    Car = new Car {Number = 30, CarBrand = "Ford", CarModel = "Mondeo", Color = "Black", MaxSpeed = 250}
                },
                new Driver
                {
                    Name = "Steve",
                    Country = "DK",
                    Age = 30,
                    Car = new Car {Number = 33, CarBrand = "Ford", CarModel = "Focus", Color = "Red", MaxSpeed = 220}
                },
                new Driver
                {
                    Name = "Arthur",
                    Country = "DK",
                    Age = 37,
                    Car = new Car {Number = 37, CarBrand = "Audi", CarModel = "A6", Color = "Black", MaxSpeed = 280}
                },
                new Driver
                {
                    Name = "Oleg",
                    Country = "UK",
                    Age = 27,
                    Car = new Car {Number = 44, CarBrand = "BMW", CarModel = "M5", Color = "Red", MaxSpeed = 320}
                },
            };
            return drivers;
        }
    }
}
