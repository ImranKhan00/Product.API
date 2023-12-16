using System.Runtime.ConstrainedExecution;

namespace Product.API.Models.Domain
{
  public class PurchaseInvoice
  {
    public int Id { get; set; }
    public double NetAmount { get; set; }
    public double NetDiscount { get; set; }
    public double PaidAmount { get; set; }
    public DateTime Date { get; set; }
    public double Arrears { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// usually invoice number of the company invoice
    /// </summary>
    public string DocumentNo { get; set; }

    /// <summary>
    /// Invoice number is human readable unique number for each invoice
    /// it will used by users to get invoices
    /// </summary>
    public long InvoiceNumber { get; set; }

    public IEnumerable<PurchaseLineItem> Items { get; set; }

    //public PurchaseInvoiceDto ToDto() { return new PurchaseInvoiceDto(this); }
  }
}
