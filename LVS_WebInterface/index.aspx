<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LVS_WebInterface.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <style type="text/css">
        #imageOutput {
            height: 213px;
            width: 960px;
        }
    </style>
</head>
<body>


    <iframe src="frame_camStream.aspx" frameborder="1" style="height: 465px; width: 478px"></iframe>

    <iframe src="frame_camCapture.aspx" frameborder="1" style="height: 465px; width: 478px"></iframe>

    <textarea id="imageOutput" hidden></textarea>

    <form id="frmWebCam" runat="server">
        
    </form>
</body>
</html>
