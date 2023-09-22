using CvApp.Data.DbContexts;
using CvApp.Data.ServiceResults;
using CvApp.Data.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Services.Concrete
{
    public class Repository<T> : IRepositoryManager<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Repository<T>> _logger;
        public Repository(AppDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }
        //Get Metodu
        public IQueryable<T> Get() => _context.Set<T>();
        //GetById 
        public ServiceModel<T> GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                _logger.LogError("Entity not found");
                return ServiceResult.Error<T>("Entity not found.");
            }
            return ServiceResult.Success("Entity found", entity);
        }
        //GetById Async

        public async Task<ServiceModel<T>> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                _logger.LogError("Entity not found");
                return ServiceResult.Error<T>("Entity not found");
            }
            return ServiceResult.Success("Entity found", entity);
        }
        //Add 
        public ServiceModel<T> Add(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("Entity added");
            return ServiceResult.Success("Entity added", entity);

        }
        //Add Async
        public async Task<ServiceModel<T>> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Entity added");
                return ServiceResult.Success("Entity added", entity);
            }
            catch (Exception ex)
            {
                return ServiceResult.Error<T>(ex.Message);
            }
        }

        public ServiceModel<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            _logger.LogInformation("Entity deleted");
            return ServiceResult.Success("Entity updated", entity);
        }

        public async Task<ServiceModel<T>> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Entity deleted");
            return ServiceResult.Success("Entity deleted", entity);
        }




        public ServiceModel<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            _logger.LogInformation("Entity updated");
            return ServiceResult.Success("Entity updated", entity);

        }

        public async Task<ServiceModel<T>> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Entity updated");
            return ServiceResult.Success("Entity updated", entity);
        }
    }
}
