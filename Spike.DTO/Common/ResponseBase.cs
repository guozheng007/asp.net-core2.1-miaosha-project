using System;
using System.Collections.Generic;
using System.Text;

namespace Spike.DTO.Common
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            ErrorCode = 200;
            ErrorMsg = "成功响应";
        }

        /// <summary>
        /// 返回编码，200之外的值都表示有错误
        /// </summary>     
        public int ErrorCode { get; set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
