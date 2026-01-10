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
             var loanResult = await loanService.CreateLoanAsync(request);    
             return Ok(loanResult);
        }
    }
}
