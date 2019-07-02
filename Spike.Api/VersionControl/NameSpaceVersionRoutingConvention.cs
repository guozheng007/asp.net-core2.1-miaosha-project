using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Spike.Api
{
    /// <summary>
    /// api version control
    /// </summary>
    public class NameSpaceVersionRoutingConvention: IApplicationModelConvention
    {
        private readonly string apiPrefix;
        private const string urlTemplate = "{0}/{1}/{2}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiPrefix"></param>
        public NameSpaceVersionRoutingConvention(string apiPrefix = "api")
        {
            this.apiPrefix = apiPrefix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {

                var hasRouteAttribute = controller.Selectors
                .Any(x => x.AttributeRouteModel != null);
                if (!hasRouteAttribute)
                {
                    continue;
                }
                var nameSpaces = controller.ControllerType.Namespace.Split('.');
                //获取namespace中版本号部分
                var version = nameSpaces.FirstOrDefault(x => Regex.IsMatch(x, @"^v(\d+)$"));
                if (string.IsNullOrEmpty(version))
                {
                    continue;
                }
                string template = string.Format(urlTemplate, apiPrefix, version,
                controller.ControllerName);
                controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = template
                };
            }
        }
    }
}
