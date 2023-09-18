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

    #region 餵養紀錄新增(建)
    public string electric_insert(string date, string time, string area)
    {
        string result = "";
        SqlCommand cmd = new SqlCommand
       (@"Insert into [test].[dbo].[stop_electric_plan](date,time,area) VALUES (@date,@time,@area)");

        cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
        cmd.Parameters.Add("@time", SqlDbType.VarChar).Value = time;
        cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = area;
        int check_num = electric_WEB.SqlHelper.cmdCheck(cmd);
        result = (check_num != 0) ? "success" : "fail";
        return result;
    }

    #endregion
}