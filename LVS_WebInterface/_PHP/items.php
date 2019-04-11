<?php
    include("_header.php");

    if(isset($_GET['item']))
    {

        $data = MySQL::Scalar("SELECT element_dataID FROM storage_elements WHERE id = ?",'i',$_GET['item']);


    }


    echo '

        <body id="test">
            <a href="/">
                <header>
                    <center>
                        <h1>LVS <span style="color: #00a1ff">| Items</span></h1>
                    </center>
                </header>
            </a>
            <main>
                <center>






                ';

                if(isset($_GET['item']))
                {
                    $item = MySQL::Row("SELECT * FROM storage_elements WHERE id = ?",'s',$_GET['item']);

                    echo '

                        <script type="text/javascript">

                            window.addEventListener("scroll", function(e) {

                                var scrOffset = window.scrollY;

                                if(scrOffset > 90)
                                {

                                    document.getElementById("codeImg1").className = "itemCode1MoveUp";
                                    document.getElementById("codeImg2").className = "itemCode2MoveUp";
                                    document.getElementById("codeImg3").className = "itemCode3MoveUp";
                                    document.getElementById("codeImg4").className = "itemCode4MoveUp";

                                    document.getElementById("productImg").className = "productImageScrollFadeOut";

                                }
                                else
                                {
                                    if(document.getElementById("codeImg1").className=="itemCode1MoveUp")
                                    {
                                        document.getElementById("codeImg1").className = "itemCode1MoveDown";
                                        document.getElementById("codeImg2").className = "itemCode2MoveDown";
                                        document.getElementById("codeImg3").className = "itemCode3MoveDown";
                                        document.getElementById("codeImg4").className = "itemCode4MoveDown";

                                        document.getElementById("productImg").className = "productImageScrollFadeIn";
                                    }
                                }

                                if(scrOffset > 300) document.getElementById("topBar").style.display = "block";
                                else document.getElementById("topBar").style.display = "none";
                            });
                        </script>


                        <h2>'.$item['element_name'].'</h2>
                        <div id="topBar" style="position: fixed; top: 0px; left: 0px; width: 100%; height: 180px; display: none; background: #333333"></div>
                        <div style="height: 600px;">
                            <img id="codeImg1" src="/lib/barcode.lib.php?s=dmtx&d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeImage"/>

                            <img id="codeImg2" src="/lib/barcode.lib.php?s=qr&d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeVar1 itemCodeVars"/>
                            <img id="codeImg3" src="/lib/barcode.lib.php?s=code-128 &d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeVar2 itemCodeVars"/>

                            <img id="codeImg4" src="data:image/jpeg;base64,'.$item['element_image'].'" class="itemCodeVar3 itemCodeVars"/>

                            <img id="productImg" src="data:image/jpeg;base64,'.$item['element_image'].'" alt="" class="itemProductImage"/>
                        </div>
                        <br>
                        <table class="infoTable">
                            <tr><td>Name:</td></tr>
                            <tr><td>'.$item['element_name'].'</td></tr>
                            <tr><td>Description:</td></tr>
                            <tr><td>'.$item['element_description'].'<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br></td></tr>
                            <tr><td>Dimensions:</td></tr>
                            <tr><td>'.$item['element_size_l'].' x '.$item['element_size_w'].' x '.$item['element_size_h'].' (LxWxH)</td></tr>
                        </table>

                    ';
                }
                else
                {
                    $items = MySQL::Cluster("SELECT * FROM storage_elements ORDER BY element_name ASC LIMIT 0,50");

                    echo '<h2>Items</h2>';

                        echo '<table class="dataTable">';

                        foreach($items as $item)
                        {
                            echo '
                                <tr>
                                    <td>
                                        <a href="/items.php?item='.$item['id'].'">
                                            <em>'.$item['element_dataID'].'</em> '.$item['element_name'].'<br>
                                            <blockquote>'.$item['element_description'].'</blockquote>
                                        </a>
                                    </td>
                                </tr>
                            ';
                        }

                        echo '</table>';

                }

                echo '
                </center>
            </main>
        </body>


    ';





?>



