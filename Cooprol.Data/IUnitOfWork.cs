using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooprol.Data.IRepository;
using Cooprol.Data.Models;
namespace Cooprol.Data;

public interface IUnitOfWork
{
    IRepository<Producer, int> ProducerRepository {get;}
    IRepository<Bill, int> BillRepository {get;}
    Task SaveAsync();
}
