<?php

//=====================
// Hattinger Tobias
//=====================


function EditButton($link,$short = false,$targetTop = false,$customText = "")
{
    return '<a '.(($targetTop) ? 'target="_top"' : '').' style="margin: 0px 3px" href="'.$link.'"> &#9998; '.((!$short) ? (($customText!="") ? $customText : 'Bearbeiten') : '').'</a>';
}

function CheckEditPermission()
{
    $rank = MySQL::Scalar("SELECT rank FROM users WHERE id = ?",'s',$_SESSION['userID']);
    if($rank>=95) return true;
    else return false;
}

function PageContent($paragraphIndex,$allowEdit=false,$reactToCustomPage="",$isIndex = false)
{
    // DESCRIPTION:
    // Gets the text/description for the current page
    // With $paragraphIndex, several entries can be saved in one page.

    // !editContent for PageContent()-function
    // !editSC for Special Containers
    $page = Page::This("!editSC","!editContent");

    if($reactToCustomPage!="") $page = $reactToCustomPage;

    $content = nl2br(MySQL::Scalar("SELECT content AS x FROM pagecontents WHERE page = ? AND paragraphIndex = ?",'@s',$page,$paragraphIndex));

    if(!$allowEdit)
    {
        $retval = FroalaContent($content);
    }
    else if(($allowEdit AND !isset($_GET['editContent'])) OR ($allowEdit AND isset($_GET['editContent']) AND $_GET['editContent']!=$paragraphIndex))
    {
        if($isIndex) $retval = FroalaContent($content).EditButton('index'.str_replace('index','',Page::This("!editSC","editContent",'+editContent='.$paragraphIndex)));
        else $retval = FroalaContent($content).EditButton(Page::This("!editSC","editContent",'+editContent='.$paragraphIndex));
    }
    else if($allowEdit AND isset($_GET['editContent']) AND $_GET['editContent']==$paragraphIndex)
    {
        $uniqID = uniqid();
        $retval = '
            <form action="'.Page::This().'" method="post" accept-charset="utf-8" enctype="multipart/form-data">
                '.TextareaPlus("contentEdit","contentEdit",$content).'
                <br>
                <button type="submit" name="changeContent" value="'.$page.'||'.$paragraphIndex.'">&Auml;ndern</button>
                <a href="'.Page::This("!editContent").'"><button type="button">Abbrechen</button></a>

                <a href="#editFileUpload'.$uniqID.'"><button type="button" style="float: right;"><i class="fas fa-upload"></i> Datei hochladen</button></a>

                <div class="modal_wrapper" id="editFileUpload'.$uniqID.'">
                    <a href="#c">
                        <div class="modal_bg"></div>
                    </a>
                    <div class="modal_container" style="width: 300px; height: 280px">
                        <iframe src="/froalapl-upload-file?parent='.urlencode(Page::This()).'" frameborder="0" style="width: 100%; height: 100%;"></iframe>
                    </div>
                </div>
            </form>';
    }

    return $retval;
}

function Message($fromUserID, $toUserID, $message, $tradeID = "", $isNotification = false)
{
    $date = date("Y-m-d");
    $time = date("H:i:s");
    $type = $isNotification ? 'info' : 'chat';

    MySQL::NonQuery("INSERT INTO messages (id,type,senderID,receiverID,tradeID,date,time,message) VALUES ('',?,?,?,?,?,?,?)",'sssssss',$type,$fromUserID,$toUserID,$tradeID,$date,$time,$message);
}


?>