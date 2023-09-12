using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Line_notify_test
{
    public partial class line_notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += new EventHandler(this.notify_click);//按下按鈕呼叫事件
        }
        protected void notify_click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "ztZlrGBh1AOeZD4KcP1Ag1uoE7KuCbhv7bsj4JC9y7b");
            var content = new Dictionary<string, string>();
            content.Add("message", "測試訊息發送成功拉!!!讚喔!");
            httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));
        }
    }
}