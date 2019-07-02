using System;

namespace Spike.Utility
{
    public class AppException : ApplicationException
    {
        public int Code { get; private set; }
        public new string Message { get; private set; }

        public AppException(AppErrorEnum errorCode)
        {
            Code = (int)errorCode;
            Message = EnumHelper.GetEnumDescription(errorCode);
        }
    }
}
