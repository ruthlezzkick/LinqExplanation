using System.Collections.Generic;
using System.Linq;
using LinqExplanation.AltLinq;
using LinqExplanation.Domain;

namespace LinqExplanation
{
    class Program
    {
        public static void Main()
        {
            /* testowe fakowe kolekcje faktur i kierowców */
            var invoices = DomainFactory.FakeInvoiceList();
            var drivers = DomainFactory.FakeDriverList();

            /*0. ORYGINALNE LINQ */
            /* za pomocą LINQ pofiltrujmy przykładowo kolekcję faktur */
            var linqWarsawInvoices = invoices.Where(x=>x.City=="Warszawa");
            var linqAprilInvoices = invoices.Where(x => x.CrtDate.Month==4);
            var linqInvoicesWithValueMoreThan30 = invoices.Where(x => x.Value>30);
            var linqAuchanInvoices = invoices.Where(x => x.Customer=="Auchan");
            /* przykład bardziej złożony siegający do niższego poziomu naszej klasy */
            var linqInvoicesWithBeer = invoices.Where(x => x.InvoiceItems.Any(y => y.ItemName == "Beer"));


            /*1. ITERACJA BEZ LINQ */
            /* zwróc mi tylko te faktury na Warszawę*/
            var warsawInvoices = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if (invoice.City == "Warszawa")
                {
                    warsawInvoices.Add(invoice);
                }
            }
            Helper.WriteInvoicesDetails(warsawInvoices);

            /* zwróc mi tylko te faktury, które zawierają piwo */
            var invoicesWithBeer = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                foreach (var invoiceItem in invoice.InvoiceItems)
                {
                    if (invoiceItem.ItemName == "Beer")
                    {
                        invoicesWithBeer.Add(invoice);
                        break;
                    }
                }
            }
            Helper.WriteInvoicesDetails(invoicesWithBeer);

            /*2. UŻYCIE KONKRETNYCH METOD DO FILTRACJI */

            var clInvoicesWithBeer = ConstLinq.WhereInvoiceHasBeer(invoices);
            Helper.WriteInvoicesDetails(clInvoicesWithBeer);
            var clWarsawInvoices = ConstLinq.WhereInvoiceCityIsEqualWarsaw(invoices);
            Helper.WriteInvoicesDetails(clWarsawInvoices);

            /*3. UŻYCIE DELEGAT */
            /* zwróc mi tylko te faktury na warszawę , za pomocą delegaty */

            InvoiceLinq.CheckIfConditionIsTrue del1 = Helper.IsCityEqualWarszawa;
            var result1 = InvoiceLinq.Where(invoices, del1);
            Helper.WriteInvoicesDetails(result1);
            InvoiceLinq.CheckIfConditionIsTrue del2 = Helper.IsIdLessThanTree;
            var result2 = InvoiceLinq.Where(invoices, del2);
            Helper.WriteInvoicesDetails(result2);



            /* próbujemy napisac samemu funkcje jako wyrażenie Lambda i wstawiamy powstały kod jako parametr naszej metody InvoiceLinq.Where*/
            /*
               przerabiamy taką finkcję eliminując po kolei
               refaktor if do ternary operator a następnie jako wyrażenie logiczne
               kwantyfikatory dosstępu, static
               typ , nazwa, return, typ parametru, skrócenie nazwy parametru do x, usinięcie return, strzałka lambda, usunięcie nawiasów 
               public static bool IsCityEqualWarszawa(Invoice invoice)
                {
                    if (invoice.City == "Warszawa")
                    {
                        return true;
                    }
                    return false;
                }
             */

            /* użycie powstałego wyrażenia w metodzie InvoiceLinq.Where*/
            var result3 = InvoiceLinq.Where(invoices, x => x.City == "Warszawa");
            Helper.WriteInvoicesDetails(result3);

            /* użycie powstałego wyrażenia w metodzie InvoiceLinq.WherebyFunc*/
            var result4 = InvoiceLinq.WhereByFunc(invoices, x => x.City == "Warszawa");
            Helper.WriteInvoicesDetails(result4);

            /* to samo dla delegata napisanego jako  lambda */
            InvoiceLinq.CheckIfConditionIsTrue del5 = (Invoice invoice) =>
            {
                return (invoice.City == "Warszawa");
            };
            var result5 = InvoiceLinq.Where(invoices, del5);

            /*4. UŻYCIE DELEGAT w KLASACH GENERYCZNYCH */
            /* jeszcze jeden test stworzenia na szybko wyrażenia lambda, przypisanie go do zmiennej i użycie w metodzie*/
            /* TYM RAZEM PRZY UŻYCIU GENERYCNEJ KLASY, która może działać nie tylko na kolekcjach Invoice ale kolekcjach każdego innego typu*/
            bool del6(Invoice x) => x.City == "Warszawa";
            var result6 = MyGenericLinq.GenericWhere<Invoice>(invoices, del6);
            Helper.WriteInvoicesDetails(result6);

            /* przykład użycia na innej klasie niż Invoice z pisaną metodą jako wyrażenie Lambda w miejscu przyjmowanego parametru metody*/
            var result7 = MyGenericLinq.GenericWhere<Driver>(drivers, x => x.Age > 33);
            Helper.WriteDriversDetails(result7);
            /* UWAGA: wyżej w obu przykładach możemy usunąć typy <Invoice> , <Driver> . które są zbędne*/



            /*5. finalne testy przy zastosowaniu metody rozszerzającej*/

            var result8 = drivers.MyOwnWhere(x => x.Age > 33);
            Helper.WriteDriversDetails(result8);

            var result9 = invoices.MyOwnWhere(x => x.Value > 30);
            Helper.WriteInvoicesDetails(result9);
        }
    }
}
