using ECommerceApplication.Models;
using ECommerceApplication.Services.Interfaces;
using ECommerceApplication.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApplication.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ISalesService _saleService;
    private readonly IOrderService _orderService;

    public ProductsController(IProductService productService, ISalesService saleService, IOrderService orderService)
    {
        _productService = productService;
        _saleService = saleService;
        _orderService = orderService;
    }

    // GET: api/<ProductsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("GetProductsPartner/limit/{limit}")]
    public async Task<ActionResult<IEnumerable<Partner>>> GetProductsPartner(int limit)
    {
        try
        {
            var result = await _productService.GetProductsPartner(limit);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpGet($"partner")]
    public async Task<ActionResult<IEnumerable<Partner>>> GetProductsPartnerNew(int limit)
    {
        try
        {
            var result = await _productService.GetProductsPartner(limit);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("seasonal-tops")]
    public ActionResult<Dictionary<string, IEnumerable<object>>> GetProductTopTotalSalesBySeason(int topN)
    {
        try
        {
            var result = _saleService.GetProductTotalSalesBySeason(topN);

            return Ok(result);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("return-rates")]
    public ActionResult<IEnumerable<object>> GetProductReturnRateByYear(int year)
    {
        try
        {
            var result = _orderService.GetProductReturnRateByYear(year);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpGet("seasonal-trends")]
    public ActionResult<IEnumerable<object>> GetProductOrderCountOfEachMonthByYear(int year)
    {
        try
        {
            var result = _orderService.GetProductOrderCountOfEachMonthByYear(year);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

}
