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


    $storedElementCountMax = MySQL::Scalar("SELECT SUM(storage_max_elements) FROM storage_location");

    $storedElementCountIs = MySQL::Scalar("SELECT SUM(storage_count) FROM element_location");

    if($storedElementCountMax != 0) $storedElementPercentage = $storedElementCountIs/($storedElementCountMax/100);
    else $storedElementPercentage = 0;

    echo '

        <body>
            <a href="/">
                <header>
                    <center>
                        <h1>LVS <span style="color: #00a1ff">| Dashboard</span></h1>
                    </center>
                </header>
            </a>
            <main>
                <br><br>
                <center>
                    <div class="customMeter" style="width: 500px; height: 500px">

                        '.Meter(1,$storedElementPercentage,500).'
                        <span style="color: #FFFFFF">Capacity: '.$storedElementCountIs.'/'.$storedElementCountMax.'</span>


                    </div>

                    <br>

                </center>
            </main>
        </body>


    ';


?>

<script type="text/javascript">

    $( document ).ready(function() {
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


