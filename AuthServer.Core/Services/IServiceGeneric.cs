using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class//Api n kullanacağı datayı dönücem
    {
        Task<Response<TDto>> GetByIdAsync(int id);//Tentity tdto ya dönüştü ve response sınıfına gönderip tdo yu döndürdük
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> AddAsync(TEntity entity);//veri tabanında oluşturmuş olduğum entity yi tdto ya dönüştürerek dön
        Task<Response<NoDataDto>> Remove(TEntity entity);//geriye bir şey dönmeyeceğim için boş class döneceğim
        Task<Response<NoDataDto>> Update(TEntity entity);
    }
}
