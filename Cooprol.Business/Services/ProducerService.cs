using System;
using Cooprol.Business.IServices;
using Cooprol.Data.Models;
namespace Cooprol.Business.Services;

public class ProducerService: IProducerService
{
    public async Task<IEnumerable<Producer>> GetProducerAsync()
    {
        List<Producer> producers = new List<Producer>();
        producers.Add(
          new Producer(){
               Id = 1,
               name = "Juan",
               numberCc = "12356",
               cellNumber = "31822233",
               isActive = true
          }

        );
        return producers;
    }
    public Task<Producer> GetById(int id)
    {
         throw new NotImplementedException();
    }
    public Task<Producer> CreateProducer(Producer producer)
    {
         throw new NotImplementedException();
    }
    public Task<Producer> UpdateProducer(Producer producer)
    {
         throw new NotImplementedException();
    }
}
