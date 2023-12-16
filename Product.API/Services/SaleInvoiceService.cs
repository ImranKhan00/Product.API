  using Microsoft.EntityFrameworkCore;

using Product.API.Models;
using Product.API.Models.Domain;
using Product.API.Models.Request;

using System;
  using System.Collections.Generic;
  using System.Linq;

namespace Product.API.Services
{
    public class SaleInvoiceService
    {
      private readonly cUnitOfWork _UnitOfWork;
      IQueryable<SaleInvoice> _Invoices => _UnitOfWork.SaleInvoiceRepository.GetAll().Where(x => x.Items.Any());


      public SaleInvoiceService(cUnitOfWork unitOfWork)
      {
        this._UnitOfWork = unitOfWork;
      }

      public IEnumerable<SaleInvoice> Get()
      {
      return _Invoices ;
      }

      public SaleInvoice Get(int id)
      {
        var invoice = _UnitOfWork.SaleInvoiceRepository.Get(id);
        if (invoice == null)
          throw new Exception("Invoice not found");
        return invoice;
      }

      /// <summary>
      /// Creates sale invoice
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="NotFoundException"></exception>
      public SaleInvoice? Create( SaleInvoiceRequest request)
      {
        if (request.Items?.Count() == 0)
          throw new Exception("Items are required");
        var invoice = _Create( request);
        // save changes
        _UnitOfWork.Complete();
        return invoice;
      }

    public dynamic ByCategories()
    {
      var sales = _UnitOfWork.SaleInvoiceRepository.GetAll().ToList();
      var grouped = sales.SelectMany(s => s.Items, (invoice, item) => new { CategoryId=item.Product.Category.Id,TotalSale=invoice.NetAmount, CategoryName = item.Product.Category.Name })
        .GroupBy(pc => pc.CategoryId).ToList();
      return grouped;
    }
      internal SaleInvoice _Create( SaleInvoiceRequest request, Customer? customer = null)
      {
        var invoice = new SaleInvoice
        {
          CustomerId = request.CustomerId,
          Customer = customer,
          PaidAmount = request.PaidAmount,
          Date = request.Date,
          Description = request.Description,
          Items = request?.Items?.Select(x =>
          {
            var product = _UnitOfWork.ProductRepository.Get(x.ProductId);
            if (product == null)
              throw new Exception("Product not found");
            return new SaleLineItem
            {
              Quantity = x.Quantity,
              //ActualPrice = ActualPrice,
              ProductId = x.ProductId,
              SalePrice = product.SalePrice,
            };
          }).ToList()
        };

      // calculate invoice discount
      invoice.NetDiscount = 0;

        // calculate invoice net amount 
        invoice.NetAmount = invoice.Items?.Sum(x => x.SalePrice * x.Quantity) ?? 0;

        // calculate net profit 
        invoice.NetProfit = invoice.Items?.Sum(x => x.NetProfit * x.Quantity) ?? 0;

        // calculate arrears
        invoice.Arrears = _GetArrears(invoice.CustomerId) + invoice.NetAmount ?? 0 - invoice.PaidAmount ?? 0;

        // if invoice is cash invoice, set paid amount to net amount
        if (request.IsCashInvoice)
        {
          invoice.PaidAmount = invoice.NetAmount;
        }
        // add to database
        _UnitOfWork.SaleInvoiceRepository.Add(invoice);
        return invoice;
      }

      #region PRIVATE METHODS

      private double _GetArrears(int customerId)
      {
        return _UnitOfWork
            .SaleInvoiceRepository
            .GetAll()
            .Where(x => x.CustomerId == customerId)
            //.ToList()
            //.Sum(x => x.NetAmount - x.PaidAmount);
            .OrderByDescending(x => x.InvoiceNumber)
            //.ThenByDescending(x=>x.Id)
            .FirstOrDefault()?
            .Arrears ?? 0;
        //var invoices = _UnitOfWork.SaleInvoiceRepository.GetAll().Where(x => x.CustomerId == customerId);
        //return invoices.Sum(x => (x.NetAmount??0)  - (x.PaidAmount??0));
      }

      #endregion
    }
  
}
