using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace YoYoMooc.StudentManagement.RazorPage
{
    /// <summary>
    /// 我们只希望允许偶数作为有效的学生ID值
    /// </summary>
    public class EvenConstraint : IRouteConstraint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext">包含有关HTTP请求的信息</param>
        /// <param name="route">该约束所属的路由</param>
        /// <param name="routeKey">包含route参数的名称</param>
        /// <param name="values">包含route参数值的字典</param>
        /// <param name="routeDirection">它是一个对象，告知ASP.NET Core 路由是否从HTTP请求中处理url或者生成url。</param>
        /// <returns></returns>
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int id;

            if (Int32.TryParse(values["id"].ToString(), out id))
            {
                if (id % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
