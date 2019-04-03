<?php

    function SendEMail($email,$subject,$message)
    {
        ini_set("SMTP", "smtp.easyname.com");
        ini_set("sendmail_from", "noreply@kro-ko-deal.com");

        $headers = "From: noreply@kro-ko-deal.com\r\n";
        $headers .= "MIME-Version: 1.0\r\n";
        $headers .= "Content-Type: text/html; charset=ISO-8859-1\r\n";

        mail($email, $subject, $message, $headers);
    }

    function MailFormater($message,$subject)
    {
        $mail='
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Transitional //EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><!--[if IE]><html xmlns="http://www.w3.org/1999/xhtml" class="ie-browser" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office"><![endif]--><html style="margin: 0;padding: 0;" xmlns="http://www.w3.org/1999/xhtml"><!--<![endif]--><head>
    <!--[if gte mso 9]><xml>
     <o:OfficeDocumentSettings>
      <o:AllowPNG/>
      <o:PixelsPerInch>96</o:PixelsPerInch>
     </o:OfficeDocumentSettings>
    </xml><![endif]-->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width">
    <!--[if !mso]><!--><meta http-equiv="X-UA-Compatible" content="IE=edge"><!--<![endif]-->
    <title>Template Base</title>


    <style type="text/css" id="media-query">
      body {
  margin: 0;
  padding: 0; }

table {
  border-collapse: collapse;
  table-layout: fixed; }

* {
  line-height: inherit; }

a[x-apple-data-detectors=true] {
  color: inherit !important;
  text-decoration: none !important; }

.ie-browser .col, [owa] .block-grid .col {
  display: table-cell;
  float: none !important;
  vertical-align: top; }

.ie-browser .corner__x {
  display: none; }

.mso-container .corner__x {
  font-size: 0; }

.ie-browser .col.num12, .ie-browser .block-grid, [owa] .col.num12, [owa] .block-grid {
  width: 500px !important; }

.ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
  line-height: 100%; }

.ie-browser .block-grid.mixed-two-up .col.num4, [owa] .block-grid.mixed-two-up .col.num4 {
  width: 164px !important; }

.ie-browser .block-grid.mixed-two-up .col.num8, [owa] .block-grid.mixed-two-up .col.num8 {
  width: 328px !important; }

.ie-browser .block-grid.two-up .col, [owa] .block-grid.two-up .col {
  width: 250px !important; }

.ie-browser .block-grid.three-up .col, [owa] .block-grid.three-up .col {
  width: 166px !important; }

.ie-browser .block-grid.four-up .col, [owa] .block-grid.four-up .col {
  width: 125px !important; }

.ie-browser .block-grid.five-up .col, [owa] .block-grid.five-up .col {
  width: 100px !important; }

.ie-browser .block-grid.six-up .col, [owa] .block-grid.six-up .col {
  width: 83px !important; }

.ie-browser .block-grid.seven-up .col, [owa] .block-grid.seven-up .col {
  width: 71px !important; }

.ie-browser .block-grid.eight-up .col, [owa] .block-grid.eight-up .col {
  width: 62px !important; }

.ie-browser .block-grid.nine-up .col, [owa] .block-grid.nine-up .col {
  width: 55px !important; }

.ie-browser .block-grid.ten-up .col, [owa] .block-grid.ten-up .col {
  width: 50px !important; }

.ie-browser .block-grid.eleven-up .col, [owa] .block-grid.eleven-up .col {
  width: 45px !important; }

.ie-browser .block-grid.twelve-up .col, [owa] .block-grid.twelve-up .col {
  width: 41px !important; }

@media only screen and (min-width: 520px) {
  .block-grid {
    width: 500px !important; }
  .block-grid .col {
    display: table-cell;
    Float: none !important;
    vertical-align: top; }
    .block-grid .col.num12 {
      width: 500px !important; }
  .block-grid.mixed-two-up .col.num4 {
    width: 164px !important; }
  .block-grid.mixed-two-up .col.num8 {
    width: 328px !important; }
  .block-grid.two-up .col {
    width: 250px !important; }
  .block-grid.three-up .col {
    width: 166px !important; }
  .block-grid.four-up .col {
    width: 125px !important; }
  .block-grid.five-up .col {
    width: 100px !important; }
  .block-grid.six-up .col {
    width: 83px !important; }
  .block-grid.seven-up .col {
    width: 71px !important; }
  .block-grid.eight-up .col {
    width: 62px !important; }
  .block-grid.nine-up .col {
    width: 55px !important; }
  .block-grid.ten-up .col {
    width: 50px !important; }
  .block-grid.eleven-up .col {
    width: 45px !important; }
  .block-grid.twelve-up .col {
    width: 41px !important; } }

@media (max-width: 520px) {
  .block-grid, .col {
    min-width: 320px !important;
    max-width: 100% !important; }
  .block-grid {
    width: calc(100% - 40px) !important; }
  .col {
    width: 100% !important; }
    .col > div {
      margin: 0 auto; }
  img.fullwidth {
    max-width: 100% !important; } }

    </style>
</head>
<!--[if mso]>
<body class="mso-container" style="background-color:#FFFFFF;">
<![endif]-->
<!--[if !mso]><!-->
<body class="clean-body" style="margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #FFFFFF">
<!--<![endif]-->
  <div class="nl-container" style="min-widht: 320px;Margin: 0 auto;background-color: #FFFFFF">

    <div style="background-color:#3B3B3B;">
      <div rel="col-num-container-box" style="Margin: 0 auto;min-width: 320px;max-width: 500px;width: 320px;width: calc(19000% - 98300px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;" class="block-grid ">
        <div style="border-collapse: collapse;display: table;width: 100%;">
          <!--[if (mso)|(IE)]><table width="100%" cellpadding="0" cellspacing="0" border="0"><tr><td bgcolor=&quot;3B3B3B&quot; style="background-color:#3B3B3B;" align="center"><table cellpadding="0" cellspacing="0" border="0" style="width: 500px;"><tr class="layout-full-width" style="background-color:transparent;"><td class="corner__x">&nbsp;</td><![endif]-->

              <!--[if (mso)|(IE)]><td align="center"  width="500" style=" width:500px; border-top: 0px solid transparent; border-left: 0px solid transparent;  border-bottom: 0px solid transparent; border-right: 0px solid transparent;" valign="top"><![endif]-->
            <!--[if !mso]><!--><div rel="col-num-container-box" class="col num12" style="min-width: 320px;max-width: 500px;width: 320px;width: calc(18000% - 89500px);background-color: transparent;">
               <div style="background-color: transparent; border-top: 0px solid transparent; border-left: 0px solid transparent; border-bottom: 0px solid transparent; border-right: 0px solid transparent;"><!--<![endif]-->
                  <div style="line-height: 5px; font-size:1px">&nbsp;</div>


<div align="center" style="Margin-right: 0px;Margin-left: 0px;">

  <img class="center fullwidth" align="center" border="0" src="http://www.kro-ko-deal.com/content/banner.png" alt="Image" title="Image" style="outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block;border: 0;height: auto;width: 100%;max-width: 500px" width="500">
</div>

                                  <div style="line-height: 5px; font-size: 1px">&nbsp;</div>
              <!--[if !mso]><!--></div>
            </div><!--<![endif]-->
          <!--[if (mso)|(IE)]></td><td class="corner__x">&nbsp;</td></tr></table></td></tr></table><![endif]-->
        </div>
      </div>
    </div>    <div style="background-color:#E0E0DC;">
      <div rel="col-num-container-box" style="Margin: 0 auto;min-width: 320px;max-width: 500px;width: 320px;width: calc(19000% - 98300px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;" class="block-grid ">
        <div style="border-collapse: collapse;display: table;width: 100%;">
          <!--[if (mso)|(IE)]><table width="100%" cellpadding="0" cellspacing="0" border="0"><tr><td bgcolor=&quot;E0E0DC&quot; style="background-color:#E0E0DC;" align="center"><table cellpadding="0" cellspacing="0" border="0" style="width: 500px;"><tr class="layout-full-width" style="background-color:transparent;"><td class="corner__x">&nbsp;</td><![endif]-->

              <!--[if (mso)|(IE)]><td align="center"  width="500" style=" width:500px; border-top: 0px solid transparent; border-left: 0px solid transparent;  border-bottom: 0px solid transparent; border-right: 0px solid transparent;" valign="top"><![endif]-->
            <!--[if !mso]><!--><div rel="col-num-container-box" class="col num12" style="min-width: 320px;max-width: 500px;width: 320px;width: calc(18000% - 89500px);background-color: transparent;">
               <div style="background-color: transparent; border-top: 0px solid transparent; border-left: 0px solid transparent; border-bottom: 0px solid transparent; border-right: 0px solid transparent;"><!--<![endif]-->


<div style="Margin-right: 0px; Margin-left: 0px;">
</div>

<div style="Margin-right: 10px; Margin-left: 10px;">
  <div style="line-height: 20px; font-size: 1px">&nbsp;</div>
    <div style="font-size:12px;line-height:14px;color:#555555;font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif;text-align:left;"><p style="margin: 0;font-size: 14px;line-height: 17px">
                    <h3>'.$subject.'</h3>
                    '.$message.
                    '</p></div>

  <div style="line-height: 20px; font-size: 1px">&nbsp;</div>
</div>


<div style="Margin-right: 10px; Margin-left: 10px;">
  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
    <div style="font-size:12px;line-height:14px;color:#555555;font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif;text-align:left;">&nbsp;<br></div>

  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
</div>



<div align="center" class="button-container center" style="Margin-right: 10px;Margin-left: 10px;">
    <div style="line-height:15px;font-size:1px">&nbsp;</div>
  <a href="http://www.kro-ko-deal.com/sign-in" target="_blank" style="color: #ffffff; text-decoration: none;">
    <!--[if mso]>
      <v:roundrect xmlns:v="urn:schemas-microsoft-com:vml" xmlns:w="urn:schemas-microsoft-com:office:word" href="" style="height:46px; v-text-anchor:middle; width:362px;" arcsize="55%" strokecolor="#FF8000" fillcolor="#FF8000" >
      <w:anchorlock/><center style="color:#ffffff; font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif; font-size:18px;">
    <![endif]-->
    <!--[if !mso]><!--><div style="color: #ffffff; background-color: #FF8000; border-radius: 25px; -webkit-border-radius: 25px; -moz-border-radius: 25px; max-width: 342px; width: 70%; border-top: 0px solid transparent; border-right: 0px solid transparent; border-bottom: 0px solid transparent; border-left: 0px solid transparent; padding-top: 5px; padding-right: 20px; padding-bottom: 5px; padding-left: 20px; font-family: Arial, \'Helvetica Neue\', Helvetica, sans-serif; text-align: center;"><!--<![endif]-->
      <span style="font-size:16px;line-height:32px;"><span style="font-size: 18px; line-height: 36px;" data-mce-style="font-size: 18px; line-height: 28px;">Zu Ihrem Account</span></span>
      <!--[if !mso]><!--></div><!--<![endif]-->
    <!--[if mso]>
          </center>
      </v:roundrect>
    <![endif]-->
  </a>
    <div style="line-height:10px;font-size:1px">&nbsp;</div>
</div>


<div align="center" style="Margin-right: 0px;Margin-left: 0px;">

  <img class="center" align="center" border="0" src="http://www.kro-ko-deal.com/content/logo.png" alt="Image" title="Image" style="outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block;border: 0;height: auto;width: 150px;max-width: 150px" width="150">
</div>


<div style="Margin-right: 10px; Margin-left: 10px;">
  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
    <div style="font-size:12px;line-height:14px;color:#555555;font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif;text-align:left;">&nbsp;<br></div>

  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
</div>

                              <!--[if !mso]><!--></div>
            </div><!--<![endif]-->
          <!--[if (mso)|(IE)]></td><td class="corner__x">&nbsp;</td></tr></table></td></tr></table><![endif]-->
        </div>
      </div>
    </div>    <div style="background-color:#3B3B3B;">
      <div rel="col-num-container-box" style="Margin: 0 auto;min-width: 320px;max-width: 500px;width: 320px;width: calc(19000% - 98300px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;" class="block-grid ">
        <div style="border-collapse: collapse;display: table;width: 100%;">
          <!--[if (mso)|(IE)]><table width="100%" cellpadding="0" cellspacing="0" border="0"><tr><td bgcolor=&quot;3B3B3B&quot; style="background-color:#3B3B3B;" align="center"><table cellpadding="0" cellspacing="0" border="0" style="width: 500px;"><tr class="layout-full-width" style="background-color:transparent;"><td class="corner__x">&nbsp;</td><![endif]-->

              <!--[if (mso)|(IE)]><td align="center"  width="500" style=" width:500px; border-top: 0px solid transparent; border-left: 0px solid transparent;  border-bottom: 0px solid transparent; border-right: 0px solid transparent;" valign="top"><![endif]-->
            <!--[if !mso]><!--><div rel="col-num-container-box" class="col num12" style="min-width: 320px;max-width: 500px;width: 320px;width: calc(18000% - 89500px);background-color: transparent;">
               <div style="background-color: transparent; border-top: 0px solid transparent; border-left: 0px solid transparent; border-bottom: 0px solid transparent; border-right: 0px solid transparent;"><!--<![endif]-->
                  <div style="line-height: 30px; font-size:1px">&nbsp;</div>


<div style="Margin-right: 0px; Margin-left: 0px;">
  <div style="line-height: 15px; font-size: 1px">&nbsp;</div>
    <div style="font-size:12px;line-height:14px;color:#959595;font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif;text-align:left;"><p style="margin: 0;font-size: 14px;line-height: 17px;text-align: center"><span style="font-size: 12px; line-height: 14px;">&nbsp; Diese Nachricht wurde Automatisch vom Kro-Ko-Deal - AutoResponder verschickt.</span><br><span style="font-size: 12px; line-height: 14px;"> Um diese Nachrichten abzustellen, klicken Sie <a href="http://www.kro-ko-deal.com/unsubscribe">hier</a></span></p></div>

  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
</div>


<div align="center" style="Margin-right: 10px;Margin-left: 10px;">
  <div style="line-height: 10px; font-size:1px">&nbsp;</div>
  <!--[if (mso)|(IE)]><table width="100%" align="center" cellpadding="0" cellspacing="0" border="0"><tr><td><![endif]-->
  <div style="border-top: 0px solid transparent; width:100%; font-size:1px;">&nbsp;</div>
  <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
  <div style="line-height:10px; font-size:1px">&nbsp;</div>
</div>

                                  <div style="line-height: 30px; font-size: 1px">&nbsp;</div>
              <!--[if !mso]><!--></div>
            </div><!--<![endif]-->
          <!--[if (mso)|(IE)]></td><td class="corner__x">&nbsp;</td></tr></table></td></tr></table><![endif]-->
        </div>
      </div>
    </div>    <div style="background-color:#ffffff;">
      <div rel="col-num-container-box" style="Margin: 0 auto;min-width: 320px;max-width: 500px;width: 320px;width: calc(19000% - 98300px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;" class="block-grid ">
        <div style="border-collapse: collapse;display: table;width: 100%;">
          <!--[if (mso)|(IE)]><table width="100%" cellpadding="0" cellspacing="0" border="0"><tr><td bgcolor=&quot;ffffff&quot; style="background-color:#ffffff;" align="center"><table cellpadding="0" cellspacing="0" border="0" style="width: 500px;"><tr class="layout-full-width" style="background-color:transparent;"><td class="corner__x">&nbsp;</td><![endif]-->

              <!--[if (mso)|(IE)]><td align="center"  width="500" style=" width:500px; border-top: 0px solid transparent; border-left: 0px solid transparent;  border-bottom: 0px solid transparent; border-right: 0px solid transparent;" valign="top"><![endif]-->
            <!--[if !mso]><!--><div rel="col-num-container-box" class="col num12" style="min-width: 320px;max-width: 500px;width: 320px;width: calc(18000% - 89500px);background-color: transparent;">
               <div style="background-color: transparent; border-top: 0px solid transparent; border-left: 0px solid transparent; border-bottom: 0px solid transparent; border-right: 0px solid transparent;"><!--<![endif]-->
                  <div style="line-height: 30px; font-size:1px">&nbsp;</div>


<div style="Margin-right: 0px; Margin-left: 0px;">
    <div style="font-size:12px;line-height:18px;color:#B8B8C0;font-family:Arial, \'Helvetica Neue\', Helvetica, sans-serif;text-align:left;"><p style="margin: 0;font-size: 14px;line-height: 21px;text-align: center">&nbsp; Alle auf dieser Website gezeigten Inhalte<br> (Mit ausnahme von Brauereinamen und Logos)<br> sind Eigentum von Kro-Ko-Deal.com und somit<br> unter Eigentum des Inhabers Peter Hattinger.</p></div>

  <div style="line-height: 10px; font-size: 1px">&nbsp;</div>
</div>

                                  <div style="line-height: 30px; font-size: 1px">&nbsp;</div>
              <!--[if !mso]><!--></div>
            </div><!--<![endif]-->
          <!--[if (mso)|(IE)]></td><td class="corner__x">&nbsp;</td></tr></table></td></tr></table><![endif]-->
        </div>
      </div>
    </div>  </div>


</body></html>';

        return $mail;
    }


?>