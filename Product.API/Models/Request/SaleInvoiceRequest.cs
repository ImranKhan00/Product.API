  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.Text.Json.Serialization;

namespace Product.API.Models.Request
{

    public class SaleInvoiceRequest
    {
      [Required]
      public int CustomerId { get; set; }

      //public int SalemanId { get; set; }
      public double? PaidAmount { get; set; }

      [Required]
      public DateTime Date { get; set; }


      public string? Description { get; set; }

      [Required]
      public IEnumerable<InvoiceItem> Items { get; set; }
      public bool IsCashInvoice { get; set; } = false;

      public SaleInvoiceRequest()
      {
        Items = new List<InvoiceItem>();
      }

    }
  
}
