using System.Net;
using Cooprol.Business.IServices;
using Cooprol.Data;
using Cooprol.Data.Dto;
using Cooprol.Data.Models;
namespace Cooprol.Business.Services;

public class ProducerService : IProducerService

{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProducerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseMessage<Producer>> CreateProducer(Producer producer)
    {
        try
        {
            await _unitOfWork.ProducerRepository.AddAsync(producer);
            await _unitOfWork.SaveAsync();
        }
        catch (System.Exception)
        {
            
            return Utils.BuildMessage<Producer>(HttpStatusCode.BadRequest,BaseMessageStatus.BAD_REQUEST_400);
        }
        return  Utils.BuildMessage<Producer>(HttpStatusCode.Created,BaseMessageStatus.OK_200, new List<Producer>{producer});
    }
    
    public async Task<BaseMessage<Producer>> GetAll()
    {
       
        IEnumerable<Producer> producers;
        try
        {
            producers = await _unitOfWork.ProducerRepository.GetAllAsync();
            if(producers!=null && producers.Any())
            {
               return Utils.BuildMessage<Producer>(HttpStatusCode.OK,BaseMessageStatus.OK_200, new List<Producer>(producers));
            }
            else
            {

                return Utils.BuildMessage<Producer>(HttpStatusCode.NoContent,BaseMessageStatus.OK_204);
            }
        }
        catch (Exception ex)
        {
            
            return Utils.BuildMessage<Producer>(HttpStatusCode.BadRequest,ex.Message);
            
        }
    }
    
    public async Task<BaseMessage<Producer>> GetActive()
    {
        IEnumerable<Producer> producers;
        try
        {
            producers = await _unitOfWork.ProducerRepository.GetAllAsync(x => x.IsActive==true);
            if(producers!=null && producers.Any())
            {
               return Utils.BuildMessage<Producer>(HttpStatusCode.OK,BaseMessageStatus.OK_200, new List<Producer>(producers));
            }
            else
            {

                return Utils.BuildMessage<Producer>(HttpStatusCode.NoContent,BaseMessageStatus.OK_204);
            }
        }
        catch (Exception ex)
        {
            
            return Utils.BuildMessage<Producer>(HttpStatusCode.BadRequest,ex.Message);
            
        }
    }

    public async Task<BaseMessage<Producer>> UpdateProducer(Producer producer)
    {
        try
        {
            await _unitOfWork.ProducerRepository.Update(producer);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            return Utils.BuildMessage<Producer>(HttpStatusCode.BadRequest,ex.Message);
        }
        
        return Utils.BuildMessage<Producer>(HttpStatusCode.OK,BaseMessageStatus.OK_200);
    }
        public async Task<BaseMessage<Producer>> DeleteProducer(int id)
    {
        try
        {
            await _unitOfWork.ProducerRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            return Utils.BuildMessage<Producer>(HttpStatusCode.BadRequest,ex.Message);
        }
        
        return Utils.BuildMessage<Producer>(HttpStatusCode.OK,BaseMessageStatus.OK_200);
    }
}
