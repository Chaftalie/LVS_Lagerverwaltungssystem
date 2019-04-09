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
   ';

   $outputs = array();

   exec('decoder\LVS_Webtools.exe decoder\test.png', $outputs);

   foreach($outputs as $o) echo $o;

   echo '

            </main>
        </body>


    ';


?>



