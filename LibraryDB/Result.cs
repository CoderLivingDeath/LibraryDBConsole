using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Result<T>
    {
        public ResultStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }

        public static implicit operator Result(Result<T> v)
        {
            return new Result()
            {
                ErrorMessage = v.ErrorMessage,
                Status = v.Status,
            };
        }

    }

    public class Result
    {
        public ResultStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
    }


    public enum ResultStatus
    {
        Success, Error
    }
}
