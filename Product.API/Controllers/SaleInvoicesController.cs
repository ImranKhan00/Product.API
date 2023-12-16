using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Product.API.Models.Domain;
using Product.API.Models.Request;
using Product.API.Services;

namespace Product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SaleInvoicesController : ControllerBase
  {
    private readonly SaleInvoiceService _SaleInvoiceService;

    public SaleInvoicesController(SaleInvoiceService saleInvoiceService)
    {
      _SaleInvoiceService = saleInvoiceService;
    }

    /// <summary>
    /// Get sale invoices
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<SaleInvoice>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
      var saleInvoices = _SaleInvoiceService.Get();
      return Ok(saleInvoices);
    }


    /// <summary>
    /// Get a single sale invoice
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(SaleInvoice), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var saleInvoice = _SaleInvoiceService.Get(id);
      return Ok(saleInvoice);
    }

    [HttpPost]
    public IActionResult Create(SaleInvoiceRequest request)
    {
      var saleInvoice = _SaleInvoiceService.Create(request);
      return Ok(saleInvoice);
    }

    [HttpGet("Sales-by-category")]
    public IActionResult Sales(){
      return Ok(_SaleInvoiceService.ByCategories());
    }

  }
}
