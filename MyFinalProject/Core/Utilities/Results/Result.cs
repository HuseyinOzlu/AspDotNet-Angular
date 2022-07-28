using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
            //this ile bu dosyadaki tek parametreli constructur'a yönlendir 
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        // overdesign olacağı için klasörleme yapmadık
        public string Message { get; }
    }
}
