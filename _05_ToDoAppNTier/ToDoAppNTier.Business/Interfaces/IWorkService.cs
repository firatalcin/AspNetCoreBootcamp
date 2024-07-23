using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto dto);
        Task<WorkListDto> GetById(object id);
    }
}
