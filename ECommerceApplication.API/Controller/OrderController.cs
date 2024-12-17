using ECommerceApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApplication.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }


    [HttpGet("seasonal-trends/{year}")]
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
    
    [HttpGet("return-rates/{year}")]
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


    //// GET api/<OrderController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<OrderController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<OrderController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<OrderController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
