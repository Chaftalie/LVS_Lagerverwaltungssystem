<?php
    include("_header.php");

    if($_SERVER['REQUEST_METHOD'] == 'POST')
    {

        $fileUploader = new FileUploader();
        $fileUploader->SetFileElement("camImg");
        $fileUploader->SetPath("uploads/");
        #$fileUploader->SetSQLEntry("");
        $fileUploader->SetName("camUpload".uniqid());
        $fileUploader->OverrideDuplicates(false);
        $fileUploader->Upload();

        Page::Redirect(Page::This());
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



