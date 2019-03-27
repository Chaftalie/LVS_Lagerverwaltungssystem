<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frame_camStream.aspx.cs" Inherits="LVS_WebInterface.frame_camStream" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>WebcamJS Test Page</title>
    <style type="text/css">
        body {
            font-family: Helvetica, sans-serif;
        }

        h2, h3 {
            margin-top: 0;
        }

        form {
            margin-top: 15px;
        }

            form > input {
                margin-right: 15px;
            }

        #results {
            float: right;
            margin: 20px;
            padding: 20px;
            border: 1px solid;
            background: #ccc;
        }
    </style>
</head>
<body>
    <form id="frmWebCam" runat="server">
        <div id="results">
            <h2>Here is your image:</h2>
            <asp:Image ID="imgCapture" runat="server" />
        </div>
        <h1>WebcamJS Test Page</h1>
        <h3>Demonstrates 640x480 cropped capture &amp; display</h3>
        <div id="my_camera"></div>
        <!-- First, include the Webcam.js JavaScript Library -->
        <script type="text/javascript" src="webcam.js"></script>
        <!-- Configure a few settings and attach camera -->
        <script language="JavaScript">
            Webcam.set({
                // live preview size
                width: 640,
                height: 480,

                // device capture size
                dest_width: 640,
                dest_height: 480,

                // final cropped size
                crop_width: 640,
                crop_height: 480,

                // format and quality
                image_format: 'jpeg',
                jpeg_quality: 100
            });
            Webcam.attach('#my_camera');
	</script>
        <!-- A button for taking snaps -->
        <asp:Button ID="btnTakeSnapshot" runat="server" Text="Take Snapshot" OnClientClick="take_snapshot(); return false;" />
        <!-- Code to handle taking the snapshot and displaying it locally -->
        <script language="JavaScript">
            function take_snapshot() {
                // take snapshot and get image data
                Webcam.snap(function (data_uri) {
                    // display results in page
                    document.getElementById('<%= imgCapture.ClientID %>').src = data_uri;
                });
            }

            setTimeout(function () {
                window.setInterval(function () {
                    Webcam.snap(function (data_uri) {
                        // display results in page
                        document.getElementById('<%= imgCapture.ClientID %>').src = data_uri;
                        window.parent.document.getElementById('imageOutput').value = data_uri; 
                    });
                }, 1000);
            }, 5000);

            
	</script>
    </form>
</body>
</html>
