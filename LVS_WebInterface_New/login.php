<?php

    include("_header.php");

    if(isset($_POST['login']))
    {
        $email = strtolower(trim($_POST['email']));
        $pass = trim($_POST['password']);

        $pwhash = hash("sha256","LVS".$pass.$email);

        $userID = MySQL::Scalar("SELECT id FROM users WHERE user = ? AND password = ?",'@s',$email,$pwhash);

        if($userID != "" AND $userID !=null)
        {
            $_SESSION['userID'] = $userID;
            Page::Redirect("/");
            die();
        }
        else
        {
            Page::Redirect(Page::This("+error"));
            die();
        }

    }

    echo '



        <body>
            <header>
                <center>
                    <h1>LVS <span style="color: #00a1ff">| Login</span></h1>
                </center>
            </header>
            <main>
                <form action="'.Page::This("-error").'" method="post" accept-charset="utf-8" enctype="multipart/form-data" id="form1">
                    <center>

                        <h1>Login</h1>
                        <br>
                        '.(isset($_GET['error']) ? '<h2><span style="color: #CC0000">Login fehlgeschlagen</span></h2>' : '').'

                        <input type="text" placeholder="E-Mail" name="email" style="width:90%; font-size: 90pt;"/><br><br>
                        <input type="password" placeholder="Password" name="password" style="width:90%; font-size: 90pt;"/><br><br>
                        <button type="submit" name="login" style="width:90%; height: 300px; font-size: 90pt;">Sign In</button>

                    </center>
                </form>
            </main>
        </body>

    ';



?>