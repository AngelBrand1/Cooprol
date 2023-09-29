using Cooprol.API.Controllers;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
using Cooprol.Data;
using Cooprol.Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace Cooprol.API.Controllers;
public class BillController: BaseApiController
{
    private readonly IBillService _billService;
    public BillController(IBillService billService)
    {
        _billService = billService;
    }
    [HttpGet]
    [Route("GetBills")]
    public async Task<IActionResult> GetBills()
    {
        var bills = await _billService.GetAll();
        return Ok(bills);
    }

    [HttpGet]
    [Route("GetByProducer/{id}")]
    public async Task<IActionResult> GetByProducer(int id)
    {
        var bills = await _billService.GetByProducer(id);
        return Ok(bills);
    }
    [HttpPost]
    [Route("CreateBill")]
    public async Task<IActionResult> CreateBill(Bill bill)
    {
        var bills = await _billService.CreateBill(bill);
        return Ok(bills);
    }
}