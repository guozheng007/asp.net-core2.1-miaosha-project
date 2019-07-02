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
        private readonly BusinessFacade _businessFacade;

        public ValuesController(BusinessFacade businessFacade)
        {
            this._logger = FrameworkExtensions.LoggerFactory.CreateLogger<ValuesController>();
            this._businessFacade = businessFacade;
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
            
            var tmp = ConfigurationManager.Configuration["add:SpikeDB_SELECT:connectionString"];
            string AppID = ConfigurationManager.Configuration["section:section0:key:AppID"];
            string EncryptKey = ConfigurationManager.Configuration["section:section0:key:EncryptKey"];

            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
