using AutoMapper;
using ECommerceSiteApi.Application.DTOs;
using ECommerceSiteApi.Application.Repositories;
using ECommerceSiteApi.Application.RequestParameters;
using ECommerceSiteApi.Application.Services.DataServices;
using ECommerceSiteApi.Application.UnitOfWorks;
using ECommerceSiteApi.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceSiteApi.Infrastructure.Services.DataServices
{
    public class DataService<Entity, Dto> : IDataService<Entity, Dto> where Entity : BaseEntity where Dto : BaseDto
    {
        protected readonly IWriteRepository<Entity> _writeRepository;
        protected readonly IReadRepository<Entity> _readRepository;
        public readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public DataService(IWriteRepository<Entity> writeRepository, IReadRepository<Entity> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(BaseDto dto)
        {
            Entity entity = _mapper.Map<Entity>(dto);
            Dto valueDto = _mapper.Map<Dto>(await _writeRepository.AddAsync(entity));
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<Dto>.Success(201, valueDto);
           
        }

        public async Task<CustomResponseDto<NoContentDto>> AddRangeAsync(IEnumerable<BaseDto> dtos)
        {
            IEnumerable<Entity> entities=_mapper.Map<IEnumerable<Entity>>(dtos);
            await _writeRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            if (await _readRepository.AnyAsync(expression,false))
            {
                return CustomResponseDto<bool>.Success(204,true);
            }
            return CustomResponseDto<bool>.Success(204,false);
        }

        public async Task<CustomResponseDto<bool>> DeleteAsync(string id)
        {
            var entity=await _readRepository.GetByIdAsync(id);
            if(_writeRepository.Delete(entity))
            {
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<bool>.Success(204);
            }
            return CustomResponseDto<bool>.Fail(500, "Beklenmeyen bir hata oluştu");
        }

        public async Task<CustomResponseDto<bool>> DeleteRangeAsync(IEnumerable<string> ids)
        {
            List<Entity> list=new();
            foreach(string id in ids) 
            { 
              list.Add(await _readRepository.GetByIdAsync(id));
            }
            if (_writeRepository.DeleteRange(list))
            {
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<bool>.Success(200);
            }
            return CustomResponseDto<bool>.Fail(500, "Beklenmeyen bir hata oluştu");
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync(Pagination pagination)
        {
            int dataTotalCount = _readRepository.DataTable.Count();
            var entities = await _readRepository.GetAll(pagination, false).ToListAsync();
            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);
            return CustomResponseDto<IEnumerable<Dto>>.Success(201, dtos,dataTotalCount);

        }
        public async Task<CustomResponseDto<Dto>> GetByIdAsync(string id)
        {
            var entity=await _readRepository.GetByIdAsync(id,false);
            var dto=_mapper.Map<Dto>(entity);
            return CustomResponseDto<Dto>.Success(201, dto);
        }

        public async Task<CustomResponseDto<Dto>> GetSingleValueAsync(Expression<Func<Entity, bool>> expression, bool tracking)
        {
            var dto=_mapper.Map<Dto>(await _readRepository.GetSingleValueAsync(expression,tracking));
            return CustomResponseDto<Dto>.Success(201,dto);
        }

        public async Task<CustomResponseDto<bool>> UpdateAsync(BaseDto dto)
        {

            var entity = _mapper.Map<Entity>(dto);
            if (_writeRepository.Update(entity)) { 
               await _unitOfWork.CommitAsync();
               return CustomResponseDto<bool>.Success(200,true);

            }
            return CustomResponseDto<bool>.Fail(500, "Beklenmeyen bir hata oluştu");

        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> WhereAsync(Expression<Func<Entity, bool>> expression)
        {
            var dtos=_mapper.Map<IEnumerable<Dto>>(await _readRepository.Where(expression,false).ToListAsync());
            return CustomResponseDto<IEnumerable<Dto>>.Success(201, dtos);
        }
    }
}
