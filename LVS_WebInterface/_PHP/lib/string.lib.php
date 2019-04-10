<?php

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
        // Replacing "ฤ,ไ,ึ,๖,Ü,ü,฿" and "-" (HTML-Characters)
        $sstr = str_replace(' ','-',$string);
        $sstr = str_replace('&Auml;','AE',$sstr);
        $sstr = str_replace('&auml;','ae',$sstr);
        $sstr = str_replace('&Ouml;','OE',$sstr);
        $sstr = str_replace('&ouml;','oe',$sstr);
        $sstr = str_replace('&Uuml;','UE',$sstr);
        $sstr = str_replace('&uuml;','ue',$sstr);
        $sstr = str_replace('&szlig;','ss',$sstr);

        // Replacing "ฤ,ไ,ึ,๖,Ü,ü,฿" (UTF-Characters/Database)
        $sstr = str_replace('ร','AE',$sstr);
        $sstr = str_replace('รค','ae',$sstr);
        $sstr = str_replace('ร–','OE',$sstr);
        $sstr = str_replace('รถ','oe',$sstr);
        $sstr = str_replace('ร','UE',$sstr);
        $sstr = str_replace('รผ','ue',$sstr);
        $sstr = str_replace('ร','ss',$sstr);

        // Remove everything but Alphanumeric letters and numbers and "-"
        $sstr = preg_replace('/[^0-9A-Za-z-'.$specialCharacters.'\|]/', '', $sstr);

        return $sstr;
    }

    public static function GermanSpecialChars($string)
    {
        $sstr = str_replace('ร','&Auml;',$string);
        $sstr = str_replace('รค','&auml;',$sstr);
        $sstr = str_replace('ร–','&Ouml;',$sstr);
        $sstr = str_replace('รถ','&ouml;',$sstr);
        $sstr = str_replace('ร','&Uuml;',$sstr);
        $sstr = str_replace('รผ','&uuml;',$sstr);
        $sstr = str_replace('ร','&szlig;',$sstr);

        return $sstr;
    }
}

?>