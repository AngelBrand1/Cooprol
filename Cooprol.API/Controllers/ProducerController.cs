using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
using Cooprol.Data;
using Cooprol.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cooprol.API.Controllers;
public class ProducerController : BaseApiController
{
    private readonly IProducerService _producerService;

    public ProducerController(IProducerService producerService)
    {
        _producerService = producerService;
    }
    [HttpGet]
    [Route("GetActive")]
    public async Task<ActionResult> GetActiveAsync()
    {
        var producers = await _producerService.GetActive();
        return Ok(producers);
    }
    [Route("GetProducers")]
    public async Task<ActionResult> GetProducersAsync()
    {
        var producers = await _producerService.GetAll();
        return Ok(producers);
    }
    
    [HttpPost]
    [Route("CreateProducer")]
    public async Task<IActionResult> CreateProducerAsync(Producer producer)
    {
        var result = await _producerService.CreateProducer(producer);
        return Ok(result);
    }
    [HttpPut]
    [Route("UpdateProducer")]
    public async Task<IActionResult> UpdateProducerAsync(Producer producer)
    {
        var result = await _producerService.UpdateProducer(producer);
        return Ok(result);
    }

    [HttpDelete]
    [Route("DeleteProducer/{id}")]
    public async Task<IActionResult> DeleteProducerAsync(int id)
    {
        var result = await _producerService.DeleteProducer(id);
        return Ok(result);
    }
}
