using System;
using System.Collections.Generic;

namespace LinqExplanation.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Customer { get; set; }
        public string City { get; set; }
        public DateTime CrtDate { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
    }
}
