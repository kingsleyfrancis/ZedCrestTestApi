using Microsoft.AspNetCore.Mvc;
using ZedCrestApiTest.Models;

namespace ZedCrestApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiplesController : ControllerBase
    {
        /// <summary>
        /// Computes and determines if the number is a multiple of 3 or 5 or both
        /// </summary>
        /// <param name="postBody">Post body object with the number supplied</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PostBody postBody)
        {
            if (postBody == null)
                return BadRequest("Invalid post body");

            var num = postBody.Number;
            if (num <= 0 || num > 100)
                return BadRequest("Invalid number supplied. The number must be between 1 and 100");

            if (num % 3 == 0 && num % 5 == 0)
                return Ok("FizzBuzz");

            if (num % 3 == 0)
                return Ok("Fizz");

            if (num % 5 == 0)
                return Ok("Buzz");

            return Ok(num.ToString());
        }
    }
}
