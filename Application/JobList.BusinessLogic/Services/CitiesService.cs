using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;
using KsuEmployment.DataAccess.Entities;
using KsuEmployment.DataAccess.Interfaces;
using KsuEmployment.BusinessLogic.Interfaces;
using KsuEmployment.Common.DTOS;
using KsuEmployment.Common.Requests;

namespace KsuEmployment.BusinessLogic.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CitiesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.CitiesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<City>, List<CityDTO>>(entities);

            return dtos;
        }

        public async Task<CityDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.CitiesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<City, CityDTO>(entity);

            return dto;
        }

        public async Task<CityDTO> CreateEntityAsync(CityRequest request)
        {
            var entity = _mapper.Map<CityRequest, City>(request);

            entity = await _uow.CitiesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<City, CityDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(CityRequest request, int id)
        {
            var entity = _mapper.Map<CityRequest, City>(request);
            entity.Id = id;

            var updated = await _uow.CitiesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.CitiesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
