using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spike.Api
{
    public interface ICommonError
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetErrCode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetErrMsg();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        ICommonError SetErrMsg(string errMsg);
    }
}
