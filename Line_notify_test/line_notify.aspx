<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="line_notify.aspx.cs" Inherits="Line_notify_test.line_notify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form runat="server">
        <div>
           <asp:Button id="Button1" Text="發送訊息"  runat="server"/>
        </div>
    </form>
</body>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="/js/line_notify.js"></script>
</html>
