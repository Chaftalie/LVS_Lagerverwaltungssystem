<?php
    session_start();
    require("_headerlinks.php");
    require("_headerincludes.php");

    if(!isset($_SESSION['userID']) AND Page::This() != 'login' AND Page::This() != 'login?error') Page::Redirect("login.php");

    echo '

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                <title></title>
            </head>
    ';


?>