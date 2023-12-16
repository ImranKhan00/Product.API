using System.Runtime.ConstrainedExecution;

namespace Product.API.Models.Domain
{
  public class SaleInvoice
  {
    public int Id { get; set; }
    public double? NetAmount { get; set; }
    public double? NetDiscount { get; set; }
    public double? PaidAmount { get; set; }
    public double? NetProfit { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public double Arrears { get; set; }

    public Customer Customer { get; set; }
    public int CustomerId { get; set; }

    /// <summary>
    /// Invoice number is human readable unique number for each invoice
    /// it will used by users to get invoices
    /// </summary>
    public long InvoiceNumber { get; set; }

    public ICollection<SaleLineItem> Items { get; set; }

    //public SaleInvoiceDto ToDto() => new SaleInvoiceDto(this);
  }
}
