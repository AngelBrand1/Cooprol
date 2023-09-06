using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cooprol.Business.IServices;
namespace Cooprol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var producers = await _producerService.GetProducerAsync();
            return Ok(producers);
        }
    }    
}
