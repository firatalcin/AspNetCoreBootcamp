using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppNTier.Common.ResponseObjects
{
    public class ResponseData<T> : Response, IResponseData<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }

        public ResponseData(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public ResponseData(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public ResponseData(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }


    }
}
