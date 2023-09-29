using Cooprol.Data.Dto;
using Cooprol.Data.Models;
namespace Cooprol.Business.IServices;
public interface IProducerService
{
    Task<BaseMessage<Producer>> GetActive();
    Task<BaseMessage<Producer>> GetAll();
    Task<BaseMessage<Producer>> UpdateProducer(Producer producer);
    Task<BaseMessage<Producer>> CreateProducer(Producer producer);
    Task<BaseMessage<Producer>> DeleteProducer(int id);
}