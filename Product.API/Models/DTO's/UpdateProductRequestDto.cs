﻿namespace Products.API.Models.DTO_s
{
  public class UpdateProductRequestDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
    public bool IsSoldOut { get; set; }

    public int[] Categories { get; set; }

  }
}
