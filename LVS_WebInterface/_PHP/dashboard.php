<?php
    include("_header.php");


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

                        <div class="needle" id="meterNeedle1"></div>
                        <input type="range" min="0" max="100" value="40" id="meterValue1" hidden/>
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


