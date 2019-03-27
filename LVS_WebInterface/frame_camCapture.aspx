<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frame_camCapture.aspx.cs" Inherits="LVS_WebInterface.frame_camCapture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script>

            window.setInterval(function(){
                if (window.parent.document.getElementById('imageOutput').value != "")
                {
                    document.getElementById("imgOut").value = window.parent.document.getElementById('imageOutput').value;
                    document.forms["form1"].submit();

                }
            }, 100);


        </script>
    
        <textarea id="imgOut" name="imgOut" hidden></textarea>
        <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label>

        <p>
        <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
