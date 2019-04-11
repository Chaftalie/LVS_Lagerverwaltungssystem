<?php

//=====================
// Hattinger Tobias
//=====================

class StringOp
{
    public static function StringContains()
    {
        // Case insensitive
        $paramAmount = func_num_args();
        $needles = func_get_args();

        $haystack = strtolower($needles[0]);
        $retval=false;

        for($i=1;$i<$paramAmount;$i++)
        {
            if(str_replace(strtolower($needles[$i]),'',$haystack)!=$haystack) return true;
        }
        return false;
    }

    public static function StringContainsCS()
    {
        // Case sensitive
        $paramAmount = func_num_args();
        $needles = func_get_args();

        $haystack = $needles[0];
        $retval=false;

        for($i=1;$i<$paramAmount;$i++)
        {
            if(str_replace(strtolower($needles[$i]),'',$haystack)!=$haystack) return true;
        }
        return false;
    }

    public static function SReplace($string,$specialCharacters='')
    {
        // Replacing "�,�,�,�,�,�,�" and "-" (HTML-Characters)
        $sstr = str_replace(' ','-',$string);
        $sstr = str_replace('&Auml;','AE',$sstr);
        $sstr = str_replace('&auml;','ae',$sstr);
        $sstr = str_replace('&Ouml;','OE',$sstr);
        $sstr = str_replace('&ouml;','oe',$sstr);
        $sstr = str_replace('&Uuml;','UE',$sstr);
        $sstr = str_replace('&uuml;','ue',$sstr);
        $sstr = str_replace('&szlig;','ss',$sstr);

        // Replacing "�,�,�,�,�,�,�" (UTF-Characters/Database)
        $sstr = str_replace('Ä','AE',$sstr);
        $sstr = str_replace('ä','ae',$sstr);
        $sstr = str_replace('Ö','OE',$sstr);
        $sstr = str_replace('ö','oe',$sstr);
        $sstr = str_replace('Ü','UE',$sstr);
        $sstr = str_replace('ü','ue',$sstr);
        $sstr = str_replace('ß','ss',$sstr);

        // Remove everything but Alphanumeric letters and numbers and "-"
        $sstr = preg_replace('/[^0-9A-Za-z-'.$specialCharacters.'\|]/', '', $sstr);

        return $sstr;
    }

    public static function GermanSpecialChars($string)
    {
        $sstr = str_replace('Ä','&Auml;',$string);
        $sstr = str_replace('ä','&auml;',$sstr);
        $sstr = str_replace('Ö','&Ouml;',$sstr);
        $sstr = str_replace('ö','&ouml;',$sstr);
        $sstr = str_replace('Ü','&Uuml;',$sstr);
        $sstr = str_replace('ü','&uuml;',$sstr);
        $sstr = str_replace('ß','&szlig;',$sstr);

        return $sstr;
    }
}

?>