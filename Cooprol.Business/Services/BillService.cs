using System.Net;
using Cooprol.Business.IServices;
using Cooprol.Data;
using Cooprol.Data.Dto;
using Cooprol.Data.Models;

namespace Cooprol.Business.Services;


public class BillService : IBillService
{
    private readonly IUnitOfWork _unitOfWork;
    public BillService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseMessage<Bill>> CreateBill(Bill bill)
    {
        var newBill = new Bill{
            DateB = bill.DateB,
            LProduced = bill.LProduced,
            Deductions = bill.Deductions,
            IdProducer = bill.IdProducer,
            ToPay = bill.ToPay
        };
        try
        {
            var producer = await _unitOfWork.ProducerRepository.FindAsync(bill.IdProducer);
            if(producer == null)
            {
                return Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest, BaseMessageStatus.BAD_REQUEST_400);
            }
            newBill.IdProducerNavigation= producer;
            await _unitOfWork.BillRepository.AddAsync(newBill);
            await _unitOfWork.SaveAsync();
            return Utils.BuildMessage<Bill>(HttpStatusCode.OK, BaseMessageStatus.OK_200);
        }
        catch (Exception ex)
        {
            
            return Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest, ex.InnerException.Message);
        }
    }

    public async Task<BaseMessage<Bill>> GetAll()
    {
    
        IEnumerable<Bill> bills;
        try
        {
            bills = await _unitOfWork.BillRepository.GetAllAsync();
            if(bills!=null && bills.Any())
            {
            return Utils.BuildMessage<Bill>(HttpStatusCode.OK,BaseMessageStatus.OK_200, new List<Bill>(bills));
            }
            else
            {

                return Utils.BuildMessage<Bill>(HttpStatusCode.NoContent,BaseMessageStatus.OK_200);
            }
        }
        catch (Exception ex)
        {
            
            return Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest,ex.Message);
            
        }
    }
    public async Task<BaseMessage<Bill>> GetByProducer(int idProducer)
    {
        IEnumerable<Bill> bills;
        try
        {
            // var producer = await _unitOfWork.ProducerRepository.FindAsync(idProducer);
            // if(producer==null)return  Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest,BaseMessageStatus.PRODUCER_NOT_FOUND);
            bills = await _unitOfWork.BillRepository.GetAllAsync(x => x.IdProducer==idProducer,x=> x.OrderBy(x => x.Id));
            if(bills!=null && bills.Any())
            {
            return Utils.BuildMessage<Bill>(HttpStatusCode.OK,BaseMessageStatus.OK_200, new List<Bill>(bills));
            }
            else
            {

                return Utils.BuildMessage<Bill>(HttpStatusCode.OK,BaseMessageStatus.OK_200);
            }
        }
        catch (Exception ex)
        {
            
            return Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest,ex.Message);
            
        }
    }

    public async Task<BaseMessage<Bill>> UpdateBill(Bill bill)
    {
        try
        {
            await _unitOfWork.BillRepository.Update(bill);
            await _unitOfWork.SaveAsync();
            return Utils.BuildMessage<Bill>(HttpStatusCode.NoContent,BaseMessageStatus.OK_204);
        }
        catch (Exception ex)
        {
            return Utils.BuildMessage<Bill>(HttpStatusCode.BadRequest,ex.Message);
        }
    }
}