using AngleSharp;
using AngleSharp.Dom;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
            Button2.Click += new EventHandler(this.Climb_click);//按下按鈕呼叫事件
        }
        protected void notify_click(object sender, EventArgs e)
        {
            var current_area = "%觀音區%";
            string result = Select_SQL(current_area);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "ztZlrGBh1AOeZD4KcP1Ag1uoE7KuCbhv7bsj4JC9y7b");
            var content = new Dictionary<string, string>();
            content.Add("message", result);
            httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));
        }
        private void Climb_click(object sender, EventArgs e)
        {
            Task climbgTask = Task.Run(() => Main_test2Async());
        }
        private async Task Main_test2Async()
        {
            
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            // 目標連結:
            string url = "https://branch.taipower.com.tw/d103/xcnotice?xsmsid=0M242581312675626779";

            // 取得目標網頁的 HTML 內容
            var document = await context.OpenAsync(url);

            // 選擇所有包含 id 屬性的 tr 元素
            //DataTable dt = new DataTable();
            //dt.Columns.Add("日期", typeof(string));
            //dt.Columns.Add("時間", typeof(string));
            //dt.Columns.Add("停電區域", typeof(string));
            //Console.WriteLine(dt);
            //dt.Rows.Add(dr);
            var dateElements = document.QuerySelectorAll("table caption");
            var timeElements = document.QuerySelectorAll(".time");
            var areaElements = document.QuerySelectorAll(".note");
            var date = "";
            var time = "";
            var area = "";
            int j = -1;
            //// 遍歷每個 tr 元素，並抽取 id、rank 和 title 屬性
            for (int i = 0; i < timeElements.Length; i++)
            {
                //DataRow dr = dt.NewRow();
                //Console.WriteLine(timeElements[i].TextContent);
                if (timeElements[i].TextContent == "停電時段")
                {
                    j++;
                }
                else
                {
                    date = (dateElements[j].TextContent).Split('：')[1];
                    time = timeElements[i].TextContent;
                    area = areaElements[i].TextContent;
                    CultureInfo culture = new CultureInfo("zh-TW");
                    culture.DateTimeFormat.Calendar = new TaiwanCalendar();
                    var Transfer_date = DateTime.Parse(date, culture);
                    var full_ymd = Transfer_date.ToString("yyyy-MM-dd");
                    Insert_SQL(full_ymd, time, area);
                    //Console.WriteLine(test2);
                    //dr["日期"] = (dateElements[j].TextContent).Split('：')[1];
                    //dr["時間"] = timeElements[i].TextContent;
                    //dr["停電區域"] = areaElements[i].TextContent;
                    //dt.Rows.Add(dr);
                } 
            }
            //Console.WriteLine(dt);
        }
        void Insert_SQL(string date,string time,string area)
        {
            Method_electric method = new Method_electric();
            string re_ = method.electric_insert(date,time,area);
            Console.WriteLine(re_);//success or fail
        }
        string Select_SQL(string current_area)
        {
            Method_electric method = new Method_electric();
            DataTable re_ = method.electric_Select(current_area);
            string area = re_.Rows[0]["area"].ToString();
            return area;
        }
    }
}