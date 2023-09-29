using System.Net;
using Cooprol.Data.Dto;

namespace Cooprol.Business;

public class Utils
{
    public static BaseMessage<T> BuildMessage<T>(HttpStatusCode statusCode, string message, List<T>? elements = null)
    where T: class
    {
        return new BaseMessage<T>(){
            StatusCode = statusCode,
            Message = message,
            TotalElements = (elements != null && elements.Any()) ? elements.Count : 0,
            ResponseElements = elements ?? new List<T>()
        };
    }
}
