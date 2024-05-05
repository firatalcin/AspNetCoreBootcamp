using Azure;
using ToDoAppNTier.Common.ResponseObjects;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<IResponseData<List<WorkListDto>>> GetAll();
                      
        Task<IResponseData<WorkCreateDto>> Create(WorkCreateDto dto);
                      
        Task<IResponseData<IDto>> GetById<IDto>(int id);
                      
        Task<IResponse> Remove(int id);
                      
        Task<IResponseData<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
