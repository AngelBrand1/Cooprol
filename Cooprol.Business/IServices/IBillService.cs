using Cooprol.Data.Dto;
using Cooprol.Data.Models;
namespace Cooprol.Business.IServices;
public interface IBillService
{
    Task<BaseMessage<Bill>> GetByProducer(int idProducer);
    Task<BaseMessage<Bill>> CreateBill(Bill bill);
    Task<BaseMessage<Bill>> UpdateBill(Bill bill);
    Task<BaseMessage<Bill>> GetAll();
}