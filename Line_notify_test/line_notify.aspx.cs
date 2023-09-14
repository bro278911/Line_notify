using AngleSharp;
using AngleSharp.Dom;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
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
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "ztZlrGBh1AOeZD4KcP1Ag1uoE7KuCbhv7bsj4JC9y7b");
            var content = new Dictionary<string, string>();
            content.Add("message", "測試訊息發送成功拉!!!讚喔!");
            httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));
        }
        private void Climb_click(object sender, EventArgs e)
        {
            //Main_test();
            Task climbgTask = Task.Run(() => Main_test2Async());
        }
        private void Main_test()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("日期");
            //dt.Columns.Add("時間");
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("https://branch.taipower.com.tw/d103/xcnotice?xsmsid=0M242581312675626779");
            // 開始撈每一筆資料
            //for (int i = 1; i <= 12; i++)
            //{
            //    DataRow dr = dt.NewRow();
            HtmlNodeCollection Node1 = doc.DocumentNode.SelectNodes($"//*[@id='MainForm']/article/div/div[1]/div/div[2]/ul/li[1]");
            //    dr["日期"] = Node1[0].InnerText.ToString().Replace("\r\n", "").Replace("\t", "");
            //    dt.Rows.Add(dr);
            //}
            HtmlNodeCollection Node2 = doc.DocumentNode.SelectNodes($"//*[@id='MainForm']/article/div/div[1]/div/div[3]/table");
            Console.WriteLine(Node1[0].InnerText.ToString());
            Console.WriteLine(Node2[0].InnerText.ToString());
        }
        private async Task Main_test2Async()
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());

            // 目標連結:
            string url = "https://branch.taipower.com.tw/d103/xcnotice?xsmsid=0M242581312675626779";

            // 取得目標網頁的 HTML 內容
            var document = await context.OpenAsync(url);

            // 選擇所有包含 id 屬性的 tr 元素
            var trElements = document.QuerySelectorAll(".time");

            // 遍歷每個 tr 元素，並抽取 id、rank 和 title 屬性
            foreach (var i in trElements)
            {
                //var id = tr.GetAttribute("id");
                //var rank = tr.QuerySelector(".title > .rank")?.TextContent;
                //var title = tr.QuerySelector(".titleline")?.TextContent;

                // 文章連結
                //var link = tr.QuerySelector(".titleline > a[href]")?.GetAttribute("href");

                // 標題下方的資訊
                //var data = tr.NextElementSibling?.QuerySelector(".subline")?.TextContent.Trim();

                Console.WriteLine(i);
            }
        }
    }
}