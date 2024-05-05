using AutoMapper;
using Azure;
using FluentValidation;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Common.ResponseObjects;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponseData<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new ResponseData<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new ResponseData<WorkCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponseData<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new ResponseData<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponseData<IDto>> GetById<IDto>(int id)
        {

            var data = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new ResponseData<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new ResponseData<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.SaveChanges();
                return new Common.ResponseObjects.Response(ResponseType.Success);
            }
            return new Common.ResponseObjects.Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }


        public async Task<IResponseData<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new ResponseData<WorkUpdateDto>(ResponseType.Success, dto);
                }
                return new ResponseData<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in result.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new ResponseData<WorkUpdateDto>(ResponseType.ValidationError, dto, errors);
            }

        }
    }
}
