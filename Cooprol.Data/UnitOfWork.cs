
using Cooprol.Data.IRepository;
using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Cooprol.Data.Repository;

namespace Cooprol.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool _disposed = false;
    private readonly CooprolContext _context; 
    private IRepository<Producer, int> _producerRepository;
    private IRepository<Bill, int> _billRepository;
    public UnitOfWork(CooprolContext context)
    {
        _context = context;
    }
    public IRepository<Producer, int> ProducerRepository 
    {
        get {
            _producerRepository ??= new Repository<Producer, int>(_context);
            return _producerRepository;
        }
    }

    public IRepository<Bill, int> BillRepository 
    {
        get {
            _billRepository ??= new Repository<Bill, int>(_context);
            return _billRepository;
        }
    }



    public async Task SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
        }
    }

    #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.DisposeAsync();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
}
