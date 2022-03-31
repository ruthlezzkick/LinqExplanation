using System;
using System.Collections.Generic;
using System.Linq;
using LinqExplanation.Domain;

namespace LinqExplanation
{
    public static class Helper
    {
        /* Przykładowe metody spełniające założenia delegaty InvoiceLinq.CheckIfConditionIsTrue */
        public static bool IsCityEqualWarszawa(Invoice invoice)
        {
            if (invoice.City == "Warszawa")
            {
                return true;
            }
            return false;
        }

        public static bool IsIdLessThanTree(Invoice invoice)
        {
            if (invoice.Id < 3)
            {
                return true;
            }
            return false;
        }

        public static bool IsInvoiceItemsMoreThanTree(Invoice invoice)
        {
            if (invoice.InvoiceItems.Count() > 3)
            {
                return true;
            }
            return false;
        }


        /* Metody pomocnicze do wyświetlania filtrowanych kolekcji w konsoli */
        public static void WriteInvoicesDetails(IEnumerable<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                Console.WriteLine($"ID: {invoice.Id} NUMBER: {invoice.Number} CITY: {invoice.City} CUSTOMER: {invoice.Customer} CRT_DATE: {invoice.CrtDate.ToShortDateString()} VALUE: {invoice.Value} ITEMS COUNT: {invoice.InvoiceItems.Count()}");
            }
        }
        public static void WriteDriversDetails(IEnumerable<Driver> drivers)
        {
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Name: {driver.Name} Country: {driver.Country} Age: {driver.Age}  CAR=> Number: {driver.Car.Number} Color: {driver.Car.Color} Model: {driver.Car.CarModel} Brand: {driver.Car.CarBrand} MaxSpeed: {driver.Car.MaxSpeed}");
            }
        }
    }
}
