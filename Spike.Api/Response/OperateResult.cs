using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Spike.Api
{
    /// <summary>
    /// 统一返回结果
    /// </summary>
    [Serializable]
    public class OperateResult
    {
        /// <summary>
        /// 表明对应请求的返回处理结果 "success" 或 "fail"
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// 若status=success,则data内返回前端需要的json数据
        /// 若status=fail，则data内使用通用的错误码格式
        /// </summary>
        [DataMember]
        public JObject Data { get; set; }

        /// <summary>
        /// 定义一个通用的创建方法
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static OperateResult Create(JObject result)
        {
            return Create(result, "success");
        }

        /// <summary>
        /// 定义一个通用的创建方法
        /// </summary>
        /// <param name="result"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static OperateResult Create(JObject result, string status)
        {
            OperateResult type = new OperateResult();
            type.SetStatus(status);
            type.SetData(result);

            return type;
        }

        /// <summary>
        /// 获取返回结果状态
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            return Status;
        }

        /// <summary>
        /// 设置返回结果状态
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(string status)
        {
            this.Status = status;
        }

        /// <summary>
        /// 获取返回数据
        /// </summary>
        /// <returns></returns>
        public object GetData()
        {
            return Data;
        }

        /// <summary>
        /// 设置返回数据
        /// </summary>
        /// <param name="data"></param>
        public void SetData(JObject data)
        {
            this.Data = data;
        }
    }
}
