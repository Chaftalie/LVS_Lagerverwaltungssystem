<?php

    require('lib/QrReader.php');

    Test::Show();

    $files = scandir("uploads");

    foreach($files as $file)
    {
        if($file == '.' || $file == '..')
        {
            continue;
        }
        else
        {
            $qrcode = new QrReader("uploads/".$file);
            $text = $qrcode->text();
            echo $text.'<br>';
        }
    }

?>