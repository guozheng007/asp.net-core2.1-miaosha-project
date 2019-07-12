using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Spike.Api
{
    /// <summary>
    /// 包装器业务异常类实现
    /// </summary>
    [Serializable]
    public class BusinessException : Exception, ICommonError
    {
        private readonly ICommonError commonError;

        /// <summary>
        /// 直接接收EmBusinessError的传参用于构造业务异常
        /// </summary>
        /// <param name="commonError"></param>
        public BusinessException(ICommonError commonError) : base()
        {
            this.commonError = commonError;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonError"></param>
        /// <param name="errMsg"></param>
        public BusinessException(ICommonError commonError, string errMsg) : base()
        {
            this.commonError = commonError;
            this.commonError.SetErrMsg(errMsg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetErrCode()
        {
            return this.commonError.GetErrCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetErrMsg()
        {
            return this.commonError.GetErrMsg();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public ICommonError SetErrMsg(string errMsg)
        {
            this.commonError.SetErrMsg(errMsg);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICommonError GetCommonError()
        {
            return commonError;
        }
    }
}
