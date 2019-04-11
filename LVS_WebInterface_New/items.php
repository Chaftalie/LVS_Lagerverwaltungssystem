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
                    $item = MySQL::Row("SELECT * FROM storage_elements INNER JOIN categories ON storage_elements.element_category_id = categories.id INNER JOIN units ON storage_elements.element_unit_id = units.id WHERE storage_elements.id = ?",'s',$_GET['item']);
                    $propertyList = MySQL::Cluster("SELECT * FROM required_properties INNER JOIN properties ON required_properties.property_id = properties.id WHERE required_properties.element_id = ?",'s',$_GET['item']);


                    if(isset($_GET['fromStorage']))
                    {
                        $storageCountTitle = "In this storage:";
                        $itemCount = MySQL::Scalar("SELECT storage_count FROM element_location WHERE element_id = ? AND storage_id = ?",'@s',$_GET['item'],$_GET['fromStorage']);

                        if($itemCount == null) $itemCount = 0; 
                    }
                    else
                    {
                        $storageCountTitle = "In store total:";
                        $itemCount = MySQL::Scalar("SELECT SUM(storage_count) FROM element_location WHERE element_id = ?",'@s',$_GET['item']);

                        if($itemCount == null) $itemCount = 0;
                    }

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
                            <a href="#modalCell1"><img id="codeImg1" src="/lib/barcode.lib.php?s=dmtx&d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeImage"/></a>

                            <a href="#modalCell2"><img id="codeImg2" src="/lib/barcode.lib.php?s=qr&d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeVar1 itemCodeVars"/></a>
                            <a href="#modalCell3"><img id="codeImg3" src="/lib/barcode.lib.php?s=code-128 &d='.$data.'&cs=1E90FF&sf=4&cm=333333&bc=1E90FF" class="itemCodeVar2 itemCodeVars"/></a>

                            <a href="#modalCell4"><img id="codeImg4" src="data:image/jpeg;base64,'.$item['element_image'].'" class="itemCodeVar3 itemCodeVars"/></a>

                            <img id="productImg" src="data:image/jpeg;base64,'.$item['element_image'].'" alt="" class="itemProductImage"/>
                        </div>
                        <br>

                        ';

                        echo '
                        <table class="infoTable">
                            <tr><td>'.$storageCountTitle.'</td></tr>
                            <tr><td>'.$itemCount.' '.$item['unit_si'].'</td></tr>
                        </table>

                        <a href="#modalOperations"><button type="button" class="menuButton">Operations</button></a>

                        <table class="infoTable">
                            <tr><td>Name:</td></tr>
                            <tr><td>'.$item['element_name'].'</td></tr>
                            <tr><td>Product Nr.:</td></tr>
                            <tr><td>'.$item['element_dataID'].'</td></tr>
                            <tr><td>Description:</td></tr>
                            <tr><td>'.$item['element_description'].'</td></tr>
                            <tr><td>Category:</td></tr>
                            <tr><td>'.$item['category_name'].'</td></tr>
                            <tr><td>Properties:</td></tr>
                            <tr><td>
                            ';
                                foreach($propertyList as $prop) echo $prop['property_name'].'<br>';
                            echo '
                            </td></tr>
                            <tr><td>Dimensions [mm]:</td></tr>
                            <tr><td>'.$item['element_size_l'].' x '.$item['element_size_w'].' x '.$item['element_size_h'].' (LxWxH)</td></tr>
                        </table>



                        <br><br><br>


                        <div class="modal_wrapper" id="modalCell1">
                            <a href="#c"><div class="modal_bg"></div></a>
                            <div class="modal_container" style="width: 90%; height: 1200px;">
                                <h1>DataMatrix</h1>
                                <img id="codeImg1" src="/lib/barcode.lib.php?s=dmtx&d='.$data.'" style="" class="codeImgLarge"/>
                            </div>
                        </div>

                        <div class="modal_wrapper" id="modalCell2">
                            <a href="#c"><div class="modal_bg"></div></a>
                            <div class="modal_container" style="width: 90%; height: 1200px;">
                                <h1>QR-Code</h1>
                                <img id="codeImg1" src="/lib/barcode.lib.php?s=qr&d='.$data.'" style="" class="codeImgLarge"/>
                            </div>
                        </div>

                        <div class="modal_wrapper" id="modalCell3">
                            <a href="#c"><div class="modal_bg"></div></a>
                            <div class="modal_container" style="width: 90%; height: 1200px;">
                                <h1>Code 128</h1>
                                <img id="codeImg1" src="/lib/barcode.lib.php?s=code-128&d='.$data.'" style="" class="codeImgLarge"/>
                            </div>
                        </div>

                        <div class="modal_wrapper" id="modalCell4">
                            <a href="#c"><div class="modal_bg"></div></a>
                            <div class="modal_container" style="width: 90%; height: 1200px;">
                                <h1>Product Img</h1>
                                <img id="codeImg1" src="data:image/jpeg;base64,'.$item['element_image'].'" style="" class="codeImgLarge"/>
                            </div>
                        </div>

                        <div class="modal_wrapper" id="modalOperations">
                            <a href="#c"><div class="modal_bg"></div></a>
                            <div class="modal_container" style="width: 90%; height: 1200px;">
                                <h1>Operations</h1>

                                <button type="button" class="menuButton">Add Elements</button>
                                <button type="button" class="menuButton">Remove Elements</button>
                                <br>
                                <button type="button" class="menuButton">Move Elements</button>
                                <button type="button" class="menuButton">Clear Elements</button>

                            </div>
                        </div>
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



