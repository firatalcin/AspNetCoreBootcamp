using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppNTier.Common.ResponseObjects
{
    public interface IResponseData<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
