using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    //veri tabanı ile iletişim kuracağım.
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);//api dan dto nesneleri alacağım.Dto yu entity ye çevir.
            await _genericRepository.AddAsync(newEntity);//yeni data eklendi
            await _unitOfWork.CommitAsync();//veri tabanına yansıttım.newEntity nin id si yüklendi.
            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);//dto nun id sini de dolduracağım.
            return Response<TDto>.Success(newDto, 200);
        }


        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(products, 200);

        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            if (product == null)
            {
                return Response<TDto>.Fail("Id not found", 404, true);
            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(product), 200);
        }


        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if(isExistEntity==null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }


        public async Task<Response<NoDataDto>> Update(TDto entity,int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if(isExistEntity==null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepository.Update(isExistEntity);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);

        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _genericRepository.Where(predicate);
            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
        }
    }
}
