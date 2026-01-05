using Fiducia.Application.DTOs;
using Fiducia.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiducia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController(ILoanService loanService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoanRequest request)
        {
            try
            {
               var loanResult = await loanService.CreateLoanAsync(request);    

                return Ok(loanResult);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal error occurred.", details = ex.Message });
            }
        }
    }
}
