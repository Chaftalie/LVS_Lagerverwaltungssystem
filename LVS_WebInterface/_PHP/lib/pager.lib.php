<?php

class Pager
{
##########################################################################################

	private static $sqlConnectionLink;

	private $pagerSize;
	private $customURL;
	private $offset;
	private $pagerColorSet;

    /*
    ################################

    CSS-Style for Pager

    .pager span
    {
        color: colorDisabled;
    }
    .pager a span
    {
        color: colorDefault;
    }

    ################################

    SASS-Style for Pager

    .pager{
        span{
            color: colorDisabled;
        }

        a{
            span{
                color: colorDefault;
            }
        }
    }

    ################################
    */

##########################################################################################

	public function __construct($_pagerSize)
	{
		$this->SetPagerSize($_pagerSize);
        $this->SetCustomURL("");
        $this->offset = $this->SetOffset();
        $this->pagerColorSet = 1;
	}
	
	public static function init()
	{
		require("pager.lib.config.php");
		
		self::$sqlConnectionLink = mysqli_connect($pagerConfigDatabaseHost,$pagerConfigDatabaseUser,$pagerConfigDatabasePass,$pagerConfigDatabaseName) OR die("<br><br><b>Error in pager.lib.php :</b> Could not connect to Database (Code 1)<br><br>");
	}
	
##########################################################################################

    private static function GetParamTypeList($paramTypeList,$paramAmt)
    {
        if(substr($paramTypeList,0,1) == "@")
        {
            $broadcastType = str_replace("@","",$paramTypeList);
            $mySQLParamTypes = '';

            for($i=0;$i<$paramAmt;$i++) $mySQLParamTypes .= $broadcastType;
        }
        else
        {
            if($paramAmt == strlen($paramTypeList) OR ($paramTypeList == "" AND $paramAmt == -1)) $mySQLParamTypes = $paramTypeList;
            else die("<b>Not enought parameters provided!</b> <br> <b>Provided: </b> ".strlen($paramTypeList)." <br><b>Required:</b> $paramAmt");
        }

        return $mySQLParamTypes;
    }

    private static function SubStringFind($string,$search)
    {
        return !(str_replace($search,'',$string)==$string);
    }

    private static function StartsWith($haystack, $needle)
    {
        $length = strlen($needle);
        return (substr($haystack, 0, $length) === $needle);
    }

    private static function ThisPage()
    {
        $param_amt = func_num_args();
        $urlParams = func_get_args();

        $thisPage = basename($_SERVER["REQUEST_URI"], '.php');

        if($param_amt != 0)
        {
            foreach($urlParams as $urlex)
            {
                if(self::StartsWith($urlex, '+'))
                {
                    $nUrl = ltrim($urlex,'+');
                    if(Pager::SubStringFind($thisPage,'?'))
                    {
                        $thisPage .= "&".$nUrl;
                    }
                    else
                    {
                        $thisPage .= "?".$nUrl;
                    }
                }
                if(self::StartsWith($urlex, '!'))
                {
                    $nUrl = ltrim($urlex,'!');
                    $pageParts = explode('?',$thisPage);

                    if(isset($pageParts[1]))
                    {
                        $getParts = explode('&',$pageParts[1]);
                        $newPage = $pageParts[0];

                        $firstAddition = true;
                        foreach ($getParts as $g)
                        {
                            if(!Pager::SubStringFind($g,$nUrl))
                            {
                                if($firstAddition)
                                {
                                    $newPage .= '?'.$g;
                                    $firstAddition = false;
                                }
                                else $newPage .= '&'.$g;
                            }
                        }
                        $thisPage = $newPage;
                    }
                }
            }
        }

        return  $thisPage;
    }

##########################################################################################

	public function SetPagerSize($size)
	{
		if($size > 0) $this->pagerSize = $size;
		else throw new Exception("<br><br><b>Error in pager.lib.php :</b> Invalid Pager-Size (Code 2)<br><br>");
	}

    public function SetCustomURL($url)
	{
		$this->customURL = $url;
	}

    public function SetOffset()
    {
        $currentPage = (isset($_GET['page']) ? $_GET['page'] : 1 );

        return ($currentPage-1) * $this->pagerSize;
    }

    public function SetColorSet($colorSet)
    {
        $this->pagerColorSet = $colorSet;
    }


##########################################################################################

	public function SQLAuto($sqlStatement,$parameterTypes="", &...$sqlParameters)
	{
	    $retval = '';

        $thisPage = ($this->customURL == "") ? basename($_SERVER["REQUEST_URI"], '.php') : $this->customURL;

        $currentPage = (isset($_GET['page']) ? $_GET['page'] : 1 );

        // Get Amount of entries
        $parameterAmount = func_num_args() - 2;
        $parameterTypeList = self::GetParamTypeList($parameterTypes,$parameterAmount);
        $stmt = self::$sqlConnectionLink->prepare($sqlStatement);
        if($parameterTypes != "") call_user_func_array(array($stmt, "bind_param"), array_merge(array($parameterTypeList), $sqlParameters));
        $stmt->execute();
        $stmt->store_result();
        $entryCounts = $stmt->num_rows;
        $stmt->close();

        $pages = 0;

        while($entryCounts > 0)
        {
            $pages++;
            $entryCounts -= $this->pagerSize;
        }

        $URLEx = self::ThisPage("!page=","+page=");

        $back = ($currentPage == 1) ? true : false;
        $next = ($currentPage >= $pages) ? true : false;

        $retval .= '<div class="pager"><div class="colorset'.$this->pagerColorSet.'">';

        $retval .= ($back) ? '<span title="Zur ersten Seite">&#10074;&#9664;</span>' : '<a href="'.$URLEx.'1"><span title="Zur ersten Seite">&#10074;&#9664;</span></a>' ;
        $retval .= ($back) ? '<span title="Zur vorherigen Seite">&#9664;</span>' : '<a href="'.$URLEx.($currentPage-1).'"><span title="Zur vorherigen Seite">&#9664;</span></a>' ;

        if($pages > 7)
        {
            $showEllipsisLeft = true;
            $showEllipsisRight = true;
            // Propper page display at the ends of each sides
            // beginning of list
            if($currentPage == 1)
            {
                $startPage = 1;
                $endPage = $currentPage + 6;
                $showEllipsisLeft = false;
            }
            else if($currentPage == 2)
            {
                $startPage = 1;
                $endPage = $currentPage + 5;
                $showEllipsisLeft = false;
            }
            else if($currentPage == 3)
            {
                $startPage = 1;
                $endPage = $currentPage + 4;
                $showEllipsisLeft = false;
            }
            else if($currentPage == 4)
            {
                $startPage = 1;
                $endPage = $currentPage + 3;
                $showEllipsisLeft = false;
            }
            // end of list
            else if($currentPage == $pages)
            {
                $startPage = $currentPage - 6;
                $endPage = $currentPage;
                $showEllipsisRight = false;
            }
            else if($currentPage == $pages - 1)
            {
                $startPage = $currentPage - 5;
                $endPage = $currentPage + 1;
                $showEllipsisRight = false;
            }
            else if($currentPage == $pages - 2)
            {
                $startPage = $currentPage - 4;
                $endPage = $currentPage + 2;
                $showEllipsisRight = false;
            }
            else if($currentPage == $pages - 3)
            {
                $startPage = $currentPage - 3;
                $endPage = $currentPage + 3;
                $showEllipsisRight = false;
            }
            // default
            else
            {
                $startPage = $currentPage - 3;
                $endPage = $currentPage + 3;
            }

            // Show ellipsis and first pages left
            if($showEllipsisLeft)
            {
                if($currentPage - 5 > 1) $retval .= '<a href="'.$URLEx.'1"><span title="Zu Seite 1">1</span></a><a href="'.$URLEx.'2"><span title="Zu Seite 2">2</span></a>';
                $retval .= '<span>...</span>';
            }

            for($i=$startPage;$i<=$endPage;$i++)
            {
                $retval .= ($currentPage == $i) ? '<span title="Zu Seite '.$i.'">'.$i.'</span>' : '<a href="'.$URLEx.$i.'"><span title="Zu Seite '.$i.'">'.$i.'</span></a>' ;
            }

            // Show ellipsis and last pages right
            if($showEllipsisRight)
            {
                $retval .= '<span>...</span>';
                if($currentPage + 5 < $pages) $retval .= '<a href="'.$URLEx.($pages-1).'"><span title="Zu Seite '.($pages-1).'">'.($pages-1).'</span></a><a href="'.$URLEx.$pages.'"><span title="Zu Seite '.$pages.'">'.$pages.'</span></a>';
            }
        }
        else
        {
            for($i=1;$i<=$pages;$i++)
            {
                $retval .= ($currentPage == $i) ? '<span title="Zu Seite '.$i.'">'.$i.'</span>' : '<a href="'.$URLEx.$i.'"><span title="Zu Seite '.$i.'">'.$i.'</span></a>' ;
            }
        }

        $retval .= ($next) ? '<span title="Zur n&auml;chsten Seite">&#9654;</span>' : '<a href="'.$URLEx.($currentPage+1).'"><span title="Zur n&auml;chsten Seite">&#9654;</span></a>' ;
        $retval .= ($next) ? '<span title="Zur letzten Seite">&#9654;&#10074;</span>' : '<a href="'.$URLEx.$pages.'"><span title="Zur letzten Seite">&#9654;&#10074;</span></a>' ;

        $retval .= '</div></div>';

        $this->offset = $this->pagerSize * $currentPage;

        return $retval;
	}

    public function GetOffset()
    {
        return $this->offset;
    }

    public function GetPagerSize()
    {
        return $this->pagerSize;
    }

	public function Manual()
	{
        $amt = func_num_args();
        $links = func_get_args();

        $retval = '<div class="pager"><div class="colorset'.$this->pagerColorSet.'">';

        $retval .= '<a href="'.$links[0].'"><span title="Zur ersten Seite">&#9664;&#9664;</span></a>';

        $i=0;
        foreach($links as $link)
        {
            $retval .= '<a href="'.$links[$i].'"><span title="Zu Seite '.($i + 1).'" style="color: #696969; font-size: 16pt;">'.($i++ + 1).'</span></a>';
        }

        $retval .= '<a href="'.$links[$amt-1].'"><span title="Zur letzten Seite">&#9654;&#9654;</span></a>';

        $retval .= '</div></div>';

        return $retval;
	}

##########################################################################################
}
Pager::init();

?>