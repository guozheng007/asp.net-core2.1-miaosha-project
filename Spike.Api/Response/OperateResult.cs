using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spike.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class OperateResult
    {
        //表明对应请求的返回处理结果 "success" 或 "fail"
        private string status;

        //若status=success,则data内返回前端需要的json数据
        //若status=fail，则data内使用通用的错误码格式
        private object data;

        /// <summary>
        /// 定义一个通用的创建方法
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static OperateResult Create(object result)
        {
            return OperateResult.Create(result, "success");
        }

        /// <summary>
        /// 定义一个通用的创建方法
        /// </summary>
        /// <param name="result"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static OperateResult Create(object result, string status)
        {
            OperateResult type = new OperateResult();
            type.SetStatus(status);
            type.SetData(result);

            return type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(string status)
        {
            this.status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SetData(object data)
        {
            this.data = data;
        }
    }
}
