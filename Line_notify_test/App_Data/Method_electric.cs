using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Method_Fish 的摘要描述
/// </summary>
public class Method_electric
{
    string web_sql = WebConfigurationManager.ConnectionStrings["electric_WEB"].ConnectionString;
    SqlConnection conn;
    public Method_electric()
    {
        conn = new SqlConnection(web_sql);
    }

    #region 爬蟲資料新增(建)
    public string electric_insert(string date, string time, string area)
    {
        string result = "";
        SqlCommand cmd = new SqlCommand
       (@"Insert into [test].[dbo].[stop_electric_plan](date,time,area) VALUES (@date,@time,@area)");

        cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
        cmd.Parameters.Add("@time", SqlDbType.VarChar).Value = time;
        cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = area;
        int check_num = electric_WEB.SqlHelper.cmdCheck(cmd);
        result = (check_num != 0) ? "success" : "fail";
        return result;
    }
    #endregion
    public DataTable electric_Select(string current_area)
    {
        //Console.WriteLine(current_area);
        SqlCommand cmd = new SqlCommand(@"SELECT * FROM [test].[dbo].[stop_electric_plan] WHERE area like  @area AND date = @date");
        
        cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
        cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = current_area;
        Console.WriteLine(cmd);
        DataTable dt = electric_WEB.SqlHelper.cmdTable(cmd);
        return dt;

    }
}