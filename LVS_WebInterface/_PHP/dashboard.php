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
                    <div class="customMeter">

                        <div class="needle" id="meterNeedle"></div>

                    </div>

                    <br>
                    <input type="range" min="0" max="100" id="meterValue" oninput="UpdateMeter(this)"/>
                </center>
            </main>
        </body>


    ';


?>

<script type="text/javascript">

    function UpdateMeter(e)
    {
        var sliderValue = e.value;

        var physMin = -130;
        var physMax = 130;

        var physStep = (physMax-physMin)/100;
        var physRotation = sliderValue * physStep - physMax;

        var hueMin = 0;
        var hueMax = 220;

        var hueStep = (hueMax-hueMin)/100;
        var hueRotation = sliderValue * hueStep;

        document.getElementById("meterNeedle").style.transform = "rotate(" + physRotation + "deg)";

        document.getElementById("meterNeedle").style.filter = "drop-shadow(0px 0px 2px black) hue-rotate(" + (hueMax-hueRotation) + "deg)";
    }


</script>


