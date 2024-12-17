using System.Collections.Generic;
using ECommerceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApplication.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISalesService _saleService;

    public SalesController(ISalesService saleService)
    {
        _saleService = saleService;
    }

    // GET: api/<SalesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    //http://localhost:5141/products/seasonal-tops?topN=3
    [HttpGet("seasonal-tops/{top}")]
    public ActionResult<Dictionary<string, IEnumerable<object>>> GetProductTopTotalSalesBySeason(int top)
    {
        try
        {
            var result = _saleService.GetProductTotalSalesBySeason(top);

            return Ok(result);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    //// GET api/<SalesController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<SalesController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<SalesController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<SalesController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
