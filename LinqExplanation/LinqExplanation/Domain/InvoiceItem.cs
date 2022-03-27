namespace LinqExplanation.Domain
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
