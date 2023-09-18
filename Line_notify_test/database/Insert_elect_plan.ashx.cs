using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Line_notify_test.database
{
    /// <summary>
    /// Insert_elect_plan 的摘要描述
    /// </summary>
    public class Insert_elect_plan : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string date = context.Request.Form["date"].ToString();
            string time = context.Request.Form["time"].ToString();
            string area = context.Request.Form["area"].ToString();

            Method_electric method = new Method_electric();
            string re_ = method.electric_insert(date, time, area);
            context.Response.Write(re_);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}