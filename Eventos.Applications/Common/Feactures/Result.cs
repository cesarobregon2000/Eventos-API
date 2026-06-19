using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Common.Feactures
{
    public enum ResultStatus
    {
        Ok,
        NotFound,
        Error
    }
    public class Result<T>
    {
        public bool IsSuccess => Status == ResultStatus.Ok;
        public bool IsNotFound => Status == ResultStatus.NotFound;
        public bool IsError => Status == ResultStatus.Error;

        public ResultStatus Status { get; init; }
        public T? Data { get; init; }
        public List<string> Errors { get; init; }
        public string Message { get; init; }

        private Result(ResultStatus status, T? data, string message, List<string>? errors)
        {
            Status = status;
            Data = data;
            Message = message;
            Errors = errors ?? [];
        }

        public static Result<T> Ok(T data, string message = "Operación realizada con éxito")
            => new(ResultStatus.Ok, data, message, null);

        public static Result<T> Ok(string message = "Operación realizada con éxito")
            => new(ResultStatus.Ok, default, message, null);

        public static Result<T> Fail(string message = "Ha ocurrido un error")
            => new(ResultStatus.Error, default, message, null);

        public static Result<T> Fail(List<string> errors, string message = "Ha ocurrido un error")
            => new(ResultStatus.Error, default, message, errors);

        public static Result<T> Fail(string error, string message = "Ha ocurrido un error")
            => Fail([error], message);

        public static Result<T> NotFound(string message = "No se encontraron resultados")
            => new(ResultStatus.NotFound, default, message, null);
    }
}
