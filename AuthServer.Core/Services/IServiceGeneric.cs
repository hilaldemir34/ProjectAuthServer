using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{//datadan gelen entity yi dto ya dönüştürüp servisten api ya sunacağım
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class//Api n kullanacağı datayı dönücem
    {
        Task<Response<TDto>> GetByIdAsync(int id);//Tentity tdto ya dönüştü ve response sınıfına gönderip tdo yu döndürdük
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> AddAsync(TDto entity);//veri tabanında oluşturmuş olduğum entity yi tdto ya dönüştürerek dön
        Task<Response<NoDataDto>> Remove(int id);//geriye bir şey dönmeyeceğim için boş class döneceğim
        Task<Response<NoDataDto>> Update(TDto entity,int id);//api den dto nesneleri alacağım
    }
}
