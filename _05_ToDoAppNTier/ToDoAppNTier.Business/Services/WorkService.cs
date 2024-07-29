using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Business.ValidationRules;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.Business.Services
{
    internal class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtovalidator;
        private readonly IValidator<WorkUpdateDto> _updateDtovalidator;

        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtovalidator, IValidator<WorkUpdateDto> updateDtovalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtovalidator = createDtovalidator;
            _updateDtovalidator = updateDtovalidator;
        }

        public async Task Create(WorkCreateDto dto)
        {
            var validationResult = _createDtovalidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChangesAsync();
            }          
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            return  _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id, true));
            
        }

        public async Task Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id, true);
            if(removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.SaveChangesAsync();
            }
            await _uow.SaveChangesAsync();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            var validationResult = _updateDtovalidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity != null) 
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
                    await _uow.SaveChangesAsync();
                }            
            }
        }
    }
}
