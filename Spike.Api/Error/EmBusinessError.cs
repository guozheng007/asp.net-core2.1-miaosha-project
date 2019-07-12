using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spike.Api
{
    /// <summary>
    /// 枚举类
    /// </summary>
    public class EmBusinessError : Enumeration, ICommonError
    {
        private int errCode;
        private string errMsg;

        /// <summary>
        /// 参数不合法
        /// </summary>
        public static readonly EmBusinessError parameterValidationError = new EmBusinessError(10001, "参数不合法");
        /// <summary>
        /// 不存在该枚举
        /// </summary>
        public static readonly EmBusinessError enumNotFound = new EmBusinessError(10002,"不存在该枚举");
        /// <summary>
        /// 私有构造函数不允许调用
        /// </summary>
        public static readonly EmBusinessError privateConstructor = new EmBusinessError(10003, "私有构造函数不允许调用");
        private EmBusinessError(int value, string displayName) : base(value, displayName)
        {
            this.errCode = value;
            this.errMsg = displayName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetErrCode()
        {
            return this.errCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetErrMsg()
        {
            return this.errMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errCode"></param>
        public void SetErrCode(int errCode)
        {
            this.errCode = errCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public ICommonError SetErrMsg(string errMsg)
        {
            this.errMsg = errMsg;

            return this;
        }
    }
}
