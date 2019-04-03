<?php
    include("_header.php");

    if(isset($_GET['item']))
    {
        $PNG_TEMP_DIR = dirname(__FILE__).DIRECTORY_SEPARATOR.'temp'.DIRECTORY_SEPARATOR;
        $PNG_WEB_DIR = 'temp/';
        if (!file_exists($PNG_TEMP_DIR)) mkdir($PNG_TEMP_DIR);


        $errorCorrectionLevel = 'H';
        $matrixPointSize = 10;
        $data = MySQL::Scalar("SELECT element_dataID FROM storage_elements WHERE id = ?",'i',$_GET['item']);

        if (trim($data) == '') $data = "No-Data";

        $filename = $PNG_TEMP_DIR.'img'.md5($data.'|'.$errorCorrectionLevel.'|'.$matrixPointSize).'.png';
        QRcode::png($data, $filename, $errorCorrectionLevel, $matrixPointSize, 2);
    }


    echo '

        <body>
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
                        <h2>'.$item['element_name'].'</h2>
                        <img src="temp/'.basename($filename).'" style="width: 60%;"/>
                        <br>
                        <table class="infoTable">
                            <tr><td>Name:</td></tr>
                            <tr><td>'.$item['element_name'].'</td></tr>
                            <tr><td>Description:</td></tr>
                            <tr><td>'.$item['element_description'].'</td></tr>
                            <tr><td>Dimensions:</td></tr>
                            <tr><td>'.$item['element_size_l'].' x '.$item['element_size_w'].' x '.$item['element_size_h'].' (LxWxH)</td></tr>
                        </table>

                    ';
                }
                else
                {
                    $items = MySQL::Cluster("SELECT * FROM storage_elements ORDER BY element_name ASC");

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



