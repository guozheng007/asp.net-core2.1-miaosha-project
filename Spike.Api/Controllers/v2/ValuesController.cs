using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spike.Business;
using Spike.Utility;

namespace Spike.Api.Controllers.v2
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger ;
        

        /// <summary>
        /// 
        /// </summary>
        public ValuesController()
        {
            this._logger = FrameworkExtensions.LoggerFactory.CreateLogger<ValuesController>();
        }

        /// <summary>
        ///  GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("日志记录成功!");
            _logger.LogDebug("debug日志记录成功");
            _logger.LogCritical("致命错误");
            _logger.LogError("异常错误");
            _logger.LogWarning("警告");
            _logger.LogTrace("追踪");
            

            return new string[] { "value1", "value2" };
        }
    }
}
