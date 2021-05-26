using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;

namespace KsuEmployment.BusinessLogic.Services
{
    public class SchoolsService : ISchoolsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SchoolsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<SchoolDTO> CreateEntityAsync(SchoolRequest modelRequest)
        {
            var entity = _mapper.Map<SchoolRequest, School>(modelRequest);

            entity = await _uow.SchoolsRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<School, SchoolDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.SchoolsRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<SchoolDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.SchoolsRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<School>, List<SchoolDTO>>(entities);

            return dtos;
        }

        public async Task<SchoolDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.SchoolsRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<School, SchoolDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(SchoolRequest modelRequest, int id)
        {
            var entity = _mapper.Map<SchoolRequest, School>(modelRequest);
            entity.Id = id;

            var updated = await _uow.SchoolsRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
