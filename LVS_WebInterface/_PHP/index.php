<?php
    include("_header.php");

    if($_SERVER['REQUEST_METHOD'] == 'POST')
    {

        $imgName = "camUpload".uniqid();

        $fileUploader = new FileUploader();
        $fileUploader->SetFileElement("camImg");
        $fileUploader->SetPath("uploads/");
        $fileUploader->SetSQLEntry("");
        $fileUploader->SetName($imgName);
        $fileUploader->OverrideDuplicates(false);
        $fileUploader->Upload();

        $outputs = array();
        $path = "decoder\\LVS_Webtools.exe uploads\\$imgName.png";
        exec($path, $outputs);
        $codeData = $outputs[0];

        if($codeData != 'Error')
        {
            $itemID = MySQL::Scalar("SELECT id FROM storage_elements WHERE element_dataID = ?",'s',$codeData);
            Page::Redirect("/items.php?item=".$itemID);
        }
        else Page::Redirect(Page::This());


        die();
    }

    echo '
        <body>
            <header>
                <center>
                    <h1>LVS <span style="color: #00a1ff">| Systems</span></h1>
                </center>
            </header>
            <main>
                <form action="'.Page::This().'" method="post" accept-charset="utf-8" enctype="multipart/form-data" id="form1">
                    <center>

                        <button type="button" class="camButton">
                            <label for="camImg">
                                <div style="background: transparent; width: 100%; height: 100%;">
                                </div>
                            </label>
                        </button>
                        '.FileButton("camImg","camImg",false,"","",'" hidden a="',false).'


                        <a href="/dashboard.php"><button type="button" class="menuButton">Dashboard</button></a>
                        <a href="/storage.php"><button type="button" class="menuButton">Storage</button></a>
                        <a href="/items.php"><button type="button" class="menuButton">Items</button></a>
                        <a href="/settings.php"><button type="button" class="menuButton">Settings</button></a>
                    </center>
                </form>
            </main>
        </body>

        <script type="text/javascript">


            $("#camImg").change(function() {
                $("#form1").submit();
            });

        </script>

    ';


?>



