
namespace Cooprol.Business.IServices;

public interface IProducerService
{
    Task<IEnumerable<Producer>> GetProducerAsync();
    Task<Producer> GetById(int id);
    Task<Producer> CreateProducer(Producer producer);
    Task<Producer> UpdateProducer(Producer producer);

}
