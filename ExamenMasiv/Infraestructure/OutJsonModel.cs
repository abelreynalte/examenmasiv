using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMasiv.Constants;

namespace ExamenMasiv.Infraestructure
{
    public class OutJsonModel
    {
        protected OutJsonModel() { }
        public virtual string Code { get; set; }
        public virtual string Message { get; set; }
        public virtual object Data { get; set; }
        public static OutJsonModel Build(string code, string message, object data)
        {
            return new OutJsonModel
            {
                Code = code,
                Message = message,
                Data = data
            };
        }
        public static OutJsonModel BuildOk()
        {
            return Build(Constants.Constants.SUCCESS,
                Constants.Constants.Message[Constants.Constants.SUCCESS], null);
        }
        public static OutJsonModel BuildOk<T>(T data)
        {
            return Build(Constants.Constants.SUCCESS, Constants.Constants.Message[Constants.Constants.SUCCESS], data);
        }
        public static OutJsonModel BuildOk<T>(string message, T data)
        {
            return Build(Constants.Constants.SUCCESS, message, data);
        }
        public static OutJsonModel BuildError(string message)
        {
            return Build(Constants.Constants.ERROR_GENERIC, message, null);
        }
        public static OutJsonModel BuildError(string code, string message)
        {
            return Build(code, message, null);
        }
        public static OutJsonModel BuildError<T>(string code, string message, T data)
        {
            return Build(code, message, data);
        }
    }
}
