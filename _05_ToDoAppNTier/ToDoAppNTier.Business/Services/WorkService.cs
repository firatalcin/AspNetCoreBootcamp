using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.DataAccess.UnitOfWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.Business.Services
{
    internal class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new Work
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });

            await _uow.SaveChangesAsync();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();
            List<WorkListDto> workList = new List<WorkListDto>();
            if (list == null && list.Count > 0) 
            {
                foreach (var item in list)
                {
                    workList.Add(new WorkListDto
                    {
                        Id = item.Id,
                        Definition = item.Definition,
                        IsCompleted = item.IsCompleted
                    });
                }

                return workList;
            }
            return null;
        }
    }
}
