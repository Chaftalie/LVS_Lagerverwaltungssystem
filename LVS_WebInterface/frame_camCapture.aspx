<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frame_camCapture.aspx.cs" Inherits="LVS_WebInterface.frame_camCapture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src='<%=ResolveUrl("~/jsfiles/jquery.webcam.js") %>' type="text/javascript"></script>

    <title></title>
</head>
<body>


        <script type="text/javascript">
            var pageUrl = '<%=ResolveUrl("~/Default.aspx") %>';
            $(function () {
                jQuery("#Camera").webcam({
                    width: 320,
                    height: 240,
                    mode: "save",
                    swffile: '<%=ResolveUrl("~/jsfiles/jscam.swf") %>',
                    debug: function (type, status) {
                        //$('#Status').append(type + ": " + status + '<br /><br />');
                    },
                    onSave: function (data) {
                        $.ajax({
                            type: "POST",
                            url: pageUrl + "/GetCapturedImage",
                            data: '',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                $("[id*=imgCapture]").css("visibility", "visible");
                                $("[id*=imgCapture]").attr("src", r.d);
                                alert("Live Image Captured Successfully");
                            },
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                    },
                    onCapture: function () {
                        webcam.save(pageUrl);
                    }
                });
            });
            function Capture() {
                webcam.capture();
                return false;
            }
</script>

    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Hariti Study Hub"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Capture Live Photo with Webcam in Asp.Net Using C#, Jquery WebCam Plugin"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnCapture" Text="Capture Image" runat="server" OnClientClick="return Capture();" BackColor="#FF9933" />
        <br />
        <br />
        <br />
        <table border="1">
            <tr>
                <td>
                    Live Image From WebCam<br />
                    <div id="Camera"></div>
                </td>
                <td>
                    Captured Image<br />
                    <asp:Image ID="imgCapture" runat="server" Style="visibility: hidden; width: 320px;
                height: 240px" />
                </td>
            </tr>
        </table>
    </form>
  
    <p>
        <input id="Submit1" type="submit" value="submit" /></p>
</body>
</html>
