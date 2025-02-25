using Frankenstein2.Data;
using Frankenstein2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frankenstein2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Purchases(DmartdbContext context) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<Purchase>>> GetPurchases()
        {
            return await context.Purchases.ToListAsync();
        }

    }
}
