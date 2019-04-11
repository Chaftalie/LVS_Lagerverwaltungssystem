<?php
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
                    <table style="width: 90%; color:#FFFFFF;">
                        <tr>
                            <td>'.Meter(1,10,400).'</td>
                            <td>Capacity</td>
                        </tr>
                        <tr>
                            <td>'.Meter(2,80,400).'</td>
                            <td>Level 2</td>
                        </tr>
                        <tr>
                            <td>'.Meter(3,55,400).'</td>
                            <td>Level 3</td>
                        </tr>
                    </table>
                </center>
            </main>
        </body>


    ';


?>


<script type="text/javascript">

    $( document ).ready(function() {
        UpdateMeter("meterValue1","meterNeedle1")
        UpdateMeter("meterValue2","meterNeedle2")
        UpdateMeter("meterValue3","meterNeedle3")
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

