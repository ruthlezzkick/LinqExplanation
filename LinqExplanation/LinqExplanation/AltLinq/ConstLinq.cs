using System.Collections.Generic;
using LinqExplanation.Domain;

namespace LinqExplanation.AltLinq
{
    public static class ConstLinq
    {
        public static IEnumerable<Invoice> WhereInvoiceCityIsEqualWarsaw(IEnumerable<Invoice> invoices)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if (invoice.City == "Warszawa")
                {
                    resultList.Add(invoice);
                }
            }
            return resultList;
        }

        public static IEnumerable<Invoice> WhereInvoiceHasBeer(IEnumerable<Invoice> invoices)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                foreach (var invoiceItem in invoice.InvoiceItems)
                {
                    if (invoiceItem.ItemName == "Beer")
                    {
                        resultList.Add(invoice);
                        break;
                    }
                }
            }
            return resultList;
        }
    }
}
