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

        <script language="JavaScript">

            setTimeout(function () {
                window.setInterval(function () {
                    Webcam.snap(function (data_uri) {
                        // display results in page
                        var base64String = data_uri.replace("data:image/jpeg;base64,","")
                        window.parent.document.getElementById('imageOutput').value = base64String; 
                    });
                }, 50);
            }, 5000);

            
	</script>
    </form>
</body>
</html>
