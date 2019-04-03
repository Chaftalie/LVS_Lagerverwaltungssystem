<?php

class Page
{
##########################################################################################

    private static function StartsWith($haystack, $needle)
    {
        return (substr($haystack, 0, strlen($needle)) === $needle);
    }

    private static function SubStringFind($string,$search)
    {
        return (str_replace($search,'',$string)!=$string);
    }

##########################################################################################

    public static function This()
    {
        // DESCRIPTION:
        // Can be used in the "action"-argument of a <form>-Tag
        // or in combination with the Redirect()-Function
        // Unlimited Parameters possible
        //          "+name=value"   Adds something to the URL
        //          "-name=value"   Removes something from the URL
        //          "!name"         Removes the Get-Query that starts with "name"
        //          "#name"         Adds a anchor/CSS-Target. Use only as last parameter
        // Returns the current pagename


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
                    if(self::SubStringFind($thisPage,'?'))
                    {
                        $thisPage .= "&".$nUrl;
                    }
                    else
                    {
                        $thisPage .= "?".$nUrl;
                    }
                }
                if(self::StartsWith($urlex, '-'))
                {
                    $nUrl = ltrim($urlex,'-');
                    $pageParts = explode('?',$thisPage);

                    if(isset($pageParts[1]))
                    {
                        $getParts = explode('&',$pageParts[1]);
                        $newPage = $pageParts[0];

                        $firstAddition = true;
                        foreach ($getParts as $g)
                        {
                            if($g != $nUrl)
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
                            if(!self::SubStringFind($g,$nUrl))
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
                if(self::StartsWith($urlex, '#'))
                {
                    $thisPage .= $urlex;
                }
            }
        }

        return  $thisPage;
    }

    public static function Redirect($path,$delay=0)
    {
        // DESCRIPTION:
        // Use Redirect() to change to another page.
        // Usefull afer POST-Instructions with SQL-Querys like: INSERT, DELETE, etc.
        // $path    relative or absolute path: "/testpage", "google.at"
        // $delay   time afer which the redirect is executed. default: 0s

        echo '<meta http-equiv="refresh" content="'.$delay.'; url='.$path.'" />';
    }

    public static function Back($steps = 1)
    {
        echo '<script> window.history.back('.$steps.'); </script>';
    }

##########################################################################################
}

?>