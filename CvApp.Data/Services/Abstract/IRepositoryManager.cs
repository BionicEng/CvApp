using CvApp.Data.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Services.Abstract
{
    public interface IRepositoryManager<T> where T : class
    {
        IQueryable<T> Get();
        ServiceModel<T> GetById(int id);
        Task<ServiceModel<T>> GetByIdAsync(int id);
        ServiceModel<T> Add(T entity);
        Task<ServiceModel<T>> AddAsync(T entity);
        ServiceModel<T> Update(T entity);
        Task<ServiceModel<T>> UpdateAsync(T entity);
        ServiceModel<T> Delete(T entity);
        Task<ServiceModel<T>> DeleteAsync(T entity);




    }
}
