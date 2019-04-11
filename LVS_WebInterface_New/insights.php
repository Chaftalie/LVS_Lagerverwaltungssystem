<?php

//=====================
// Hattinger Tobias
//=====================

    include("_header.php");


    function Meter($id,$value,$size)
    {

        return '
            <div class="customMeter" style="width: '.$size.'px; height: '.$size.'px">
                <div class="needle" id="meterNeedle'.$id.'"></div>
                <input type="range" min="0" max="100" value="'.$value.'" id="meterValue'.$id.'" hidden/>
            </div>
        ';
    }

    $storageData = MySQL::Row("SELECT * FROM storage_location WHERE id = ?",'s',$_GET['storage']);

    $storedElementCount = MySQL::Scalar("SELECT SUM(storage_count) FROM element_location WHERE storage_id = ?",'s',$_GET['storage']);

    if($storedElementCount == null) $storedElementCount = 0;

    if($storageData['storage_max_elements'] != 0) $storedElementPercentage = $storedElementCount/($storageData['storage_max_elements']/100);
    else $storedElementPercentage = 0;

    echo '

        <body>
            <a href="/">
                <header>
                    <center>
                        <h1>LVS <span style="color: #00a1ff">| Insights</span></h1>
                    </center>
                </header>
            </a>
            <main>
                <center>
                    <br>
                    '.Meter(1,$storedElementPercentage,500).'
                    <span style="color: #FFFFFF">Capacity: '.$storedElementCount.'/'.$storageData['storage_max_elements'].'</span>


                    <br><br>

                </center>
            </main>
        </body>


    ';


?>


<script type="text/javascript">

    $(window).ready(function () {
        UpdateMeter("meterValue1","meterNeedle1")

    });

    function UpdateMeter(elementID,meterNeedleID)
    {
        var sliderValue = document.getElementById(elementID).value;

        var physMin = -130;
        var physMax = 130;

        var physStep = (physMax-physMin)/100;
        var physRotation = sliderValue * physStep - physMax;

        var hueMin = 0;
        var hueMax = 220;

        var hueStep = (hueMax-hueMin)/100;
        var hueRotation = sliderValue * hueStep;

        document.getElementById(meterNeedleID).style.transform = "rotate(" + physRotation + "deg)";

        document.getElementById(meterNeedleID).style.filter = "drop-shadow(0px 0px 2px black) hue-rotate(" + (hueMax-hueRotation) + "deg)";
    }


</script>

