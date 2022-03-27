using System;
using System.Collections.Generic;
using LinqExplanation.Domain;

namespace LinqExplanation.AltLinq
{
    public static class InvoiceLinq
    {
        public delegate bool CheckIfConditionIsTrue(Invoice invoice);
        //Func<Invoice,bool>
        
        public static IEnumerable<Invoice> Where(IEnumerable<Invoice> invoices, CheckIfConditionIsTrue checkIfConditionIsTrue)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if(checkIfConditionIsTrue(invoice))
                {
                    resultList.Add(invoice);
                }
            }
            return resultList;
        }

        public static IEnumerable<Invoice> WhereByFunc(IEnumerable<Invoice> invoices, Func<Invoice,bool> invoiceDelegate)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if (invoiceDelegate(invoice))
                {
                    resultList.Add(invoice);
                }
            }
            return resultList;
        }
    }
}
