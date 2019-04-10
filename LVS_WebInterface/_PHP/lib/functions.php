<?php

function BottlecapSingleBox($bottlecapID,$isEditMode = false)
{
    $sqlStatement = "SELECT *,
    capColor.colorShort AS bottlecapCapColorShort,
    capColor.colorDE AS bottlecapCapColorName,
    baseColor.hex AS bottlecapBaseColorValue,
    baseColor.colorDE AS bottlecapBaseColorName,
    textColor.hex AS bottlecapTextColorValue,
    textColor.colorDE AS bottlecapTextColorName
    FROM bottlecaps
    INNER JOIN breweries ON bottlecaps.breweryID = breweries.id
    INNER JOIN countries ON breweries.countryID = countries.id
    INNER JOIN flavors ON bottlecaps.flavorID = flavors.id
    INNER JOIN sidesigns ON bottlecaps.sidesignID = sidesigns.id
    INNER JOIN colors AS capColor ON bottlecaps.capColorID = capColor.id
    INNER JOIN colors AS baseColor ON bottlecaps.baseColorID = baseColor.id
    INNER JOIN colors AS textColor ON bottlecaps.textColorID = textColor.id
    WHERE bottlecaps.id = ?";


    $row = MySQL::Row($sqlStatement,'s',$bottlecapID);

    $altMessage = '';
    $imagePath = '/files/bottlecaps/'.$row['countryShort'].'/'.$row['breweryFilepath'].'/'.$row['capImage'];
    if(!file_exists(ltrim($imagePath,'/')) OR $row['capImage']=="")
    {
        $altMessage = $imagePath;
        $imagePath = '/content/not_found.png';
    }

    $retval = '
    <div class="bottlecapSingleContainer">
        <table class="capDisplay">
            <tr>
                <td colspan=5>Neueste Kronkorken</td>
            </tr>
            <tr>
                <td>
                    <img src="'.$imagePath.'" alt="'.$altMessage.'" />

                </td>
                <td>
                    <center>
                        <img src="/files/breweries/'.$row['countryShort'].'/'.$row['breweryImage'].'" alt="" />
                        <img src="/files/sidesigns/'.$row['sidesignImage'].'" alt="" />
                        <br>
                        <img src="/content/blank.gif" class="flag flag-'.strtolower($row['countryShort2']).'" id="flag_img"  alt="" />
                    </center>
                </td>
                <td>
                    <b>Brauerei:</b><br>
                    '.$row['breweryName'].'<br><br>
                    <b>Name:</b><br>
                    '.$row['name'].'<br><br>
                    <b>Sorte:</b>
                    <br>'.$row['flavorDE'].'
                </td>
                <td>
                    <b>Land:</b><br>
                    '.$row['countryDE'].' <br><br>
                    <b>Gekauft:</b><br>
                    '.$row['locationAquired'].'<br><br>
                    <b>In Sammlung seit:</b><br>
                    '.$row['dateAquired'].'
                </td>
                <td>
                    '.(($row['breweryLink']!='') ? '<a target="_blank" href="'.$row['breweryLink'].'"><button type="button" class="cel_100"><i class="fas fa-home"></i> Zur Brauerei</button></a><br><br>' : '').'

                    <a href="#zusatzinfos" ><button type="button" class="cel_100"><i class="fas fa-info-circle"></i> Zusatzinfos</button></a>
                </td>
            </tr>


        </table>

        <div class="additionalInformationContainer" id="zusatzinfos">
            <div class="additionalInformationOverlay">
                <table class="capData">
                    <tr>
                        <td rowspan=7>'.BottlecapColorScheme($row['bottlecapCapColorShort'],$row['bottlecapBaseColorValue'],$row['bottlecapTextColorValue'],$row['isUsed'],$row['isTwistlock']).'</td>
                        <td>Kronkorkenfarbe: </td>
                        <td>'.$row['bottlecapCapColorName'].'</td>

                        <td>Qualit&auml;t: </td>
                        <td>'.$row['quality'].'</td>
                    </tr>
                    <tr>
                        <td>Grundfarbe: </td>
                        <td>'.$row['bottlecapBaseColorName'].'</td>
                        ';

                        if($isEditMode)
                        {
                            $retval .= '
                                <td>Auf Lager:</td>
                                <td>'.$row['stock'].' St&uuml;ck</td>
                            ';
                        }
                        else
                        {
                            $retval .= '
                                <td></td>
                                <td></td>
                            ';
                        }

                        $retval .= '
                    </tr>
                    <tr>
                        <td>Textfarbe: </td>
                        <td>'.$row['bottlecapTextColorName'].'</td>

                        <td>Tauschbar: </td>
                        <td>'.($row['isTradeable'] ? 'Ja' : 'Nein').'</td>
                    </tr>
                    <tr>
                        <td><br></td>
                        <td><br></td>
                        <td><br></td>
                        <td><br></td>
                    </tr>
                    <tr>
                        <td>Set-Teil:</td>
                        <td>'.($row['isSet'] ? 'Ja' : 'Nein').'</td>

                        <td>Randzeichen: </td>
                        <td>'.$row['sidesignName'].'</td>
                    </tr>
                    <tr>
                        <td>Zustand: </td>
                        <td>'.($row['isUsed'] ? 'Gebraucht' : 'Neu').'</td>

                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Drehverschluss: </td>
                        <td>'.($row['isTwistlock'] ? 'Ja' : 'Nein').'</td>

                        <td></td>
                        <td></td>
                    </tr>
                </table>




                <a href="#"><div class="close">Schlie&szlig;en</div></a>
            </div>
        </div>
    ';

    return $retval;
}

function SetsAndA2ZButtons($ISOcode,$showBottlecapCount=false,$linkToCountries=false)
{
    $link = '';

    // A-Z Button
    if($linkToCountries) $link = '/kronkorken/'.$ISOcode;

    $retval = '
        '.($linkToCountries ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons setsAndA2ZButtons">
                <img src="/content/buttons/DE/a-z.png" alt="" />
    ';

    if($showBottlecapCount) $retval .= '<div>'.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND countries.countryShort = ?",'s',$ISOcode).' St&uuml;ck</div>';

    $retval .= '</div>'.($linkToCountries ? '</a>' : '');

    // Set Button
    if($linkToCountries) $link = '/sets/'.$ISOcode;

    $retval .= '
        '.($linkToCountries ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons setsAndA2ZButtons">
                <img src="/content/buttons/DE/sets.png" alt="" />
    ';

    if($showBottlecapCount) $retval .= '<div>'.MySQL::Count("SELECT DISTINCT bottlecaps.setID FROM sets INNER JOIN bottlecaps ON sets.id = bottlecaps.setID INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE bottlecaps.isCounted='1' AND countries.countryShort = ?",'s',$ISOcode).' Sets</div>';

    $retval .= '</div>'.($linkToCountries ? '</a>' : '');

    return $retval;
}

function ContinentButton($ISOcode,$showBottlecapCount=false,$linkToCountries=false)
{
    $link = '';

    if($linkToCountries) $link = '/laender/kontinent/'.$ISOcode;

    $retval = '
        '.($linkToCountries ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons continentButton">
                <img src="/content/regionButtons/DE/continent/'.$ISOcode.'.png" alt="" />
    ';

    if($showBottlecapCount)
    {
        $retval .= '
            <div>
                '.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id INNER JOIN continents ON countries.continentID = continents.id WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND continents.continentShort = ?",'s',$ISOcode).' St&uuml;ck
            </div>
        ';
    }

    $retval .= '
            </div>
        '.($linkToCountries ? '</a>' : '').'
    ';

    return $retval;
}

function CountryButton($ISOcode,$showBottlecapCount=false, $showSetCount=false,$linkToCollectionOrSubmenu = false, $showBreweryCount = false)
{
    $link = '';

    if($linkToCollectionOrSubmenu AND ($showBottlecapCount OR $showBreweryCount))
    {
        if(MySQL::Exist("SELECT regions.id FROM regions INNER JOIN countries ON regions.countryID = countries.id WHERE countries.countryShort = ?",'s',$ISOcode)) $link = '/laender/regionen/'.$ISOcode;
        else $link = '/kronkorken/'.$ISOcode;
    }

    if($linkToCollectionOrSubmenu AND $showSetCount)
    {
        $link = '/sets/'.$ISOcode;
    }

    $retval = '
        '.($linkToCollectionOrSubmenu ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons countryButton">
                <img src="/content/regionButtons/DE/country/'.$ISOcode.'.png" alt="" />
    ';

    if($showBottlecapCount)
    {
        $retval .= '
            <div>
                '.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND countries.countryShort = ?",'s',$ISOcode).' St&uuml;ck
            </div>
        ';
    }

    if($showSetCount)
    {
        $retval .= '
            <div>
                '.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE isSet = '1' AND countries.countryShort = ? GROUP BY setID",'s',$ISOcode).' Sets
            </div>
        ';
    }

    if($showBreweryCount)
    {
        $retval .= '
            <div style="width: 120px;">
                '.MySQL::Count("SELECT * FROM breweries INNER JOIN countries ON breweries.countryID = countries.id WHERE countries.countryShort = ?",'s',$ISOcode).' Brauereien
            </div>
        ';
    }

    $retval .= '
            </div>
        '.($linkToCollectionOrSubmenu ? '</a>' : '').'
    ';

    return $retval;
}

function TradeCountryButton($ISOcode,$showBottlecapCount=false, $showSetCount=false,$linkToCollectionOrSubmenu = false)
{
    $link = '';

    if($linkToCollectionOrSubmenu AND $showBottlecapCount)
    {
        $link = '/tauschen/kronkorken/'.$ISOcode;
    }

    if($linkToCollectionOrSubmenu AND $showSetCount)
    {
        $link = '/tauschen/sets/'.$ISOcode;
    }

    $retval = '
        '.($linkToCollectionOrSubmenu ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons tradeCountryButton">
                <img src="/content/regionButtons/DE/trade/'.$ISOcode.'.png" alt="" />
    ';

    if($showBottlecapCount)
    {
        $retval .= '
            <div style="width: 125px;">
                '.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND countries.countryShort = ? AND isTradeable = '1'",'s',$ISOcode).' Tauschbar
            </div>
        ';
    }

    if($showSetCount)
    {
        $tradeSetCtr = 0;
        $setCluster = MySQL::Cluster("SELECT * FROM sets INNER JOIN bottlecaps ON sets.id = bottlecaps.setID INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE countries.countryShort = ? GROUP BY sets.id",'s',$ISOcode);
        foreach($setCluster AS $setData)
        {
            $allTradeable = true;

            $capCluster = MySQL::Cluster("SELECT * FROM bottlecaps WHERE setID = ?",'s',$setData['setID']);
            foreach($capCluster AS $capData)
            {
                if($capData['isTradeable'] != '1' OR ($capData['isTradeable'] != '1' AND $capData['stock'] < 0)) $allTradeable = false;
            }

            if($allTradeable) $tradeSetCtr++;
        }


        $retval .= '
            <div style="width: 165px;">
                '.$tradeSetCtr.' Tauschbare(s) Set(s)
            </div>
        ';
    }

    $retval .= '
            </div>
        '.($linkToCollectionOrSubmenu ? '</a>' : '').'
    ';

    return $retval;
}

function RegionButton($ISOcode,$showBottlecapCount=false,$linkToCollection = false)
{
    $link = '';

    if($linkToCollection)
    {
        $countryShort = MySQL::Scalar("SELECT countries.countryShort FROM regions INNER JOIN countries ON regions.countryID = countries.id WHERE  regions.regionShort = ?",'s',$ISOcode);
        $link = '/kronkorken/'.$countryShort.'/'.$ISOcode;
    }

    $retval = '
        '.($linkToCollection ? ('<a href="'.$link.'">') : '').'
            <div class="regionButtons federalButton">
                <img src="/content/regionButtons/DE/region/'.$ISOcode.'.png" alt="" />
    ';

    if($showBottlecapCount)
    {
        $retval .= '
            <div>
                '.MySQL::Count("SELECT * FROM bottlecaps INNER JOIN breweries ON bottlecaps.breweryID = breweries.ID INNER JOIN regions ON breweries.regionID = regions.id WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND regions.regionShort = ?",'s',$ISOcode).' St&uuml;ck
            </div>
        ';
    }

    $retval .= '
            </div>
        '.($linkToCollection ? '</a>' : '').'
    ';

    return $retval;
}




function BottlecapColorScheme($capColorCode,$baseColor,$textColor,$isUsed = false,$isTwistlock = false)
{
    $retval = '

        <div class="bottlecapColorSchemeContainer">
            <div><img id="'.$capColorCode.'" src="/content/cap'.($isUsed ? 'Used' : 'New').'Colored.png" alt="" /></div>
            <div style="background: #'.$baseColor.'"></div>
            <div style="color: #'.$textColor.'">K-K-D</div>
            '.($isTwistlock ? '<div></div>' : '').'
        </div>

    ';

    return $retval;
}

function BreweryListTile($breweryID,$showRegional=false,$tradeableLink=false)
{
    if($showRegional) $breweryData = MySQL::Row("SELECT *,breweries.id AS breweryID FROM breweries INNER JOIN countries ON breweries.countryID = countries.id INNER JOIN regions ON breweries.regionID = regions.id WHERE breweries.id = ? ORDER BY breweries.breweryName ASC",'i',$breweryID);
    else $breweryData = MySQL::Row("SELECT *,breweries.id AS breweryID FROM breweries INNER JOIN countries ON breweries.countryID = countries.id  WHERE breweries.id = ? ORDER BY breweries.breweryName ASC",'i',$breweryID);

    $bottleCapCount = MySQL::Count("SELECT * FROM bottlecaps WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND breweryID = ?",'i',$breweryData['breweryID']);
    $tradeableCount = MySQL::Count("SELECT * FROM bottlecaps WHERE ((bottlecaps.isSet = 0 AND bottlecaps.isCounted = 1) OR (bottlecaps.isSet = 1 AND bottlecaps.isOwned = 1)) AND isTradeable = '1' AND bottlecaps.stock > 0  AND breweryID = ?",'i',$breweryData['breweryID']);

    if($tradeableLink) $link = '/tauschen/kronkorken/sammlung/'.$breweryData['countryShort'].'/brauerei/'.$breweryData['breweryFilepath'];
    else $link = '/kronkorken/sammlung/'.$breweryData['countryShort'].'/brauerei/'.$breweryData['breweryFilepath'];

    $retval = '
        <tr>
            <td><img src="/files/breweries/'.$breweryData['countryShort'].'/'.$breweryData['breweryImage'].'" alt="" /></td>
            <td>
                <i>Brauerei:</i> '.$breweryData['breweryName'].'<br><br>
                <i>Land:</i> '.$breweryData['countryDE'].'<br><br>
                '.($showRegional ? ('<i>Bundesland:</i> '.$breweryData['regionDE']) : '').'
            </td>
            <td>
                <i>Kronkorken:</i> '.$bottleCapCount.'<br>
                <i>Tauschbar:</i> '.$tradeableCount.'
            </td>
            <td>
                '.(($breweryData['breweryLink']!='') ? '<a target="_blank" href="'.$breweryData['breweryLink'].'"><button type="button" class="cel_100"><i class="fas fa-home"></i> Zur Brauerei</button></a><br><br>' : '').'

                <a href="'.$link.'"><button type="button" class="cel_100">Kronkorken dieser<br>Brauerei</button></a>
            </td>
        </tr>
    ';

    return $retval;
}

function SetTile($setID,$isEditMode = false,$tradeableLink=false)
{
    $setData = MySQL::Row("SELECT * FROM sets INNER JOIN bottlecaps ON sets.id = bottlecaps.setID INNER JOIN breweries ON bottlecaps.breweryID = breweries.id INNER JOIN countries ON breweries.countryID = countries.id WHERE sets.id = ?",'i',$setID);



    if($tradeableLink AND $setData['thumbnailTradeID'] != 0)
    {
        $setThumbnail = MySQL::Scalar("SELECT capImageTrade FROM bottlecaps WHERE id = ?",'i',$setData['thumbnailTradeID']);
    }
    else $setThumbnail = MySQL::Scalar("SELECT capImage FROM bottlecaps WHERE id = ?",'i',$setData['thumbnailID']);

    $retval = '
        <table class="setTileTable">
            <tr><td colspan=3>'.$setData['setName'].'</td></tr>
            <tr>
                <td><img src="/files/sets/'.$setData['countryShort'].'/'.$setData['setFilepath'].'/'.$setThumbnail.'" alt="" /></td>
                <td>
                    <b>Brauerei: </b> '.$setData['breweryName'].'<br><br>
                    <b>Set-Gr&ouml;&szlig;e: </b>'.$setData['setSize'].'<br><br>
                    <b>Land: </b>'.$setData['countryDE'].'
                </td>
                <td>
                ';

                if($isEditMode)
                {
                    $retval .= '<a href="'.($tradeableLink ? '/tauschen' : '').'/sets/'.$setData['countryShort'].'/'.$setData['setFilepath'].'"><button type="button" class="cel_100">Set betrachten</button></a>';

                    if($tradeableLink) $retval .= '<br><br><a href="/_iframe_addCapToCart?objID='.$setData['setID'].'&isSet=1" target="cartAddFrame"><button type="button" class="cel_100" style="margin-bottom: 5px; background: #32CD32"><i class="fas fa-shopping-cart"></i> Zum Tausch-Korb</button></a>';

                    else
                    {
                        $retval .= '
                            <a href="/bearbeiten/erweitern/'.$setData['setID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #32CD32">KK hinzuf&uuml;gen</button></a><br>
                            <a href="/bearbeiten/set/'.$setData['setID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #32CD32">Bearbeiten</button></a><br>
                            <a href="/entfernen/set/'.$setData['setID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #D60000">L&ouml;schen</button></a><br><br>
                        ';
                    }
                }
                else
                {
                    $retval .= '<a href="'.($tradeableLink ? '/tauschen' : '').'/sets/'.$setData['countryShort'].'/'.$setData['setFilepath'].'"><button type="button" class="cel_100">Set betrachten</button></a>';

                    if($tradeableLink) $retval .= '<br><br><a href="/_iframe_addCapToCart?objID='.$setData['setID'].'&isSet=1" target="cartAddFrame"><button type="button" class="cel_100" style="margin-bottom: 5px; background: #32CD32"><i class="fas fa-shopping-cart"></i> Zum Tausch-Korb</button></a>';
                }

                $retval .= '


                </td>
            </tr>
        </table>
    ';

    return $retval;
}

function BottleCapRowData($capData, $isSet, $countryHasRegions,$isEditMode = false, $isTradeDisplay = false)
{
    $setName = '';
    if($isSet)
    {
        $imagePath = '/files/sets/'.$capData['countryShort'].'/'.$capData['setFilepath'].'/'.$capData['capImage'];
        $capName = $capData['setName'].' - '.$capData['name'];
        $setName = $capData['setName'];

        if($isTradeDisplay AND $capData['capImageTrade'] != "")  $imagePath = '/files/sets/'.$capData['countryShort'].'/'.$capData['setFilepath'].'/'.$capData['capImageTrade'];
    }
    else
    {
        if($capData['isSet'])
        {
            $setData = MySQL::Row("SELECT * FROM sets WHERE id = ?",'s',$capData['setID']);

            $imagePath = '/files/sets/'.$capData['countryShort'].'/'.$setData['setFilepath'].'/'.$capData['capImage'];
            $capName = $setData['setName'].' - '.$capData['name'];
            $setName = $setData['setName'];

            if($isTradeDisplay AND $capData['capImageTrade'] != "") $imagePath = '/files/sets/'.$capData['countryShort'].'/'.$setData['setFilepath'].'/'.$capData['capImageTrade'];
        }
        else
        {
            $imagePath = '/files/bottlecaps/'.$capData['countryShort'].'/'.$capData['breweryFilepath'].'/'.$capData['capImage'];
            $capName = $capData['name'];

            if($isTradeDisplay AND $capData['capImageTrade'] != "") $imagePath = '/files/bottlecaps/'.$capData['countryShort'].'/'.$capData['breweryFilepath'].'/'.$capData['capImageTrade'];
        }
    }

    if($isTradeDisplay)
    {
        if($capData['quality'] == '' AND $capData['qualityTrade'] == '') $capQuality = '<span title="Keine Angaben">K.A.</span>';
        if($capData['quality'] != '' AND $capData['qualityTrade'] == '') $capQuality = $capData['quality'];
        if($capData['quality'] != '' AND $capData['qualityTrade'] != '') $capQuality = $capData['qualityTrade'];
        if($capData['quality'] == '' AND $capData['qualityTrade'] != '') $capQuality = $capData['qualityTrade'];
    }
    else $capQuality = $capData['quality'];

    $altMessage = '';
    if(!file_exists(ltrim($imagePath,'/')) OR $capData['capImage']=="")
    {
        $altMessage = $imagePath;
        $imagePath = '/content/not_found.png';
    }

    $retval = '
        <tr>
            <td>
                <div>
                    '.($isSet ? '<a name="cap'.$capData['bottlecapID'].'">' : '').'
                    <img src="'.$imagePath.'" alt="'.$altMessage.'" />
                    <img src="'.$imagePath.'" alt="'.$altMessage.'" class="capImageEnlarged"/>
                </div>
            </td>
            <td>
                <center>
                    <img src="/files/breweries/'.$capData['countryShort'].'/'.$capData['breweryImage'].'" alt="" />
                    <img src="/files/sidesigns/'.$capData['sidesignImage'].'" alt="" />
                    <br>
                    <img src="/content/blank.gif" class="flag flag-'.strtolower($capData['countryShort2']).'" id="flag_img"  alt="" />
                </center>
            </td>
            <td>
                <b>Brauerei:</b><br>
                '.$capData['breweryName'].'<br><br>
                <b>Name:</b><br>
                '.$capName.'<br><br>
                <b>Sorte:</b>
                <br>'.$capData['flavorDE'].'
                '.($isSet ? ('<br><br><b>In Sammlung: </b> '.($capData['isOwned'] ? 'Ja' : 'Nein' )) : '').'
                '.($isTradeDisplay ? ('<br><br><b>Qualit&auml;t: </b> '.$capQuality) : '').'
            </td>
            <td>
                <b>Land:</b>
                '.$capData['countryDE'].' <br><br>
                '.($countryHasRegions ? ('<b>Bundesland: </b>'.$capData['regionDE'].'<br><br>') : '').'
                <b>Gekauft:</b><br>
                '.$capData['locationAquired'].'<br><br>
                <b>In Sammlung seit:</b><br>
                '.$capData['dateAquired'].'
            </td>
            <td>
    ';



    if($isEditMode)
    {
        if($isSet) $retval .= '<a href="/optionen/'.($isTradeDisplay ? 'tausch' : '').'vorschau/'.$capData['bottlecapID'].'/'.$capData['setID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #1E90FF">F&uuml;r Vorschau verw.</button></a><br>';

        $retval .= '<a href="/bearbeiten/'.($isTradeDisplay ? 'tausch' : '').'kronkorken/'.$capData['bottlecapID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #32CD32">Bearbeiten</button></a><br>';

        if(!$isTradeDisplay) $retval .= '<a href="/entfernen/kronkorken/'.$capData['bottlecapID'].'"><button type="button" class="cel_100 cel_h25" style="margin-bottom: 5px; background: #D60000">L&ouml;schen</button></a><br><br>';

        $retval .= '
            '.(($capData['breweryLink']!='') ? '<a target="_blank" href="'.$capData['breweryLink'].'"><button type="button" style="margin-bottom: 5px;" class="cel_100 cel_h25"><i class="fas fa-home"></i> Zur Brauerei</button></a>' : '').'
            <a href="#zusatzinfos'.$capData['bottlecapID'].'" class="quickInfoButton">
                <button type="button" onclick="bgenScroll();" class="cel_100 cel_h25"><i class="fas fa-info-circle"></i> Zusatzinfos</button>
                <div>
                    <span>
                        <b>Kapsel-Nummer:</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'.$capData['capNumber'].'
                    </span>
                    <br>

                    <p>
                        <b>Set-Teil:</b>
                        '.($capData['isSet'] ? 'Ja <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<i>'.$setName.'</i>)' : 'Nein').'
                    </p>

                    <p>
                        <b>Zustand: </b>
                        '.($capData['isUsed'] ? 'Gebraucht' : 'Neu').'
                    </p>
                    <p>
                        <b>Drehverschluss: </b>
                        '.($capData['isTwistlock'] ? 'Ja' : 'Nein').'
                        <br>
                        <em>
                            F&uuml;r mehr Infos klicken
                        </em>
                    </p>
                </div>
            </a>
        ';

        if($isTradeDisplay)
        {
            $retval .= '<br><br><a href="/_iframe_addCapToCart?objID='.$capData['bottlecapID'].'&isSet=0" target="cartAddFrame"><button type="button" class="cel_100" style="margin-bottom: 5px; background: #32CD32"><i class="fas fa-shopping-cart"></i> Zum Tausch-Korb</button></a>';
        }
    }
    else
    {
        $retval .= '
            '.(($capData['breweryLink']!='') ? '<a target="_blank" href="'.$capData['breweryLink'].'"><button type="button" class="cel_100"><i class="fas fa-home"></i> Zur Brauerei</button></a><br><br>' : '').'
            <a href="#zusatzinfos'.$capData['bottlecapID'].'" class="quickInfoButton">
                <button type="button" onclick="bgenScroll();" class="cel_100"><i class="fas fa-info-circle"></i> Zusatzinfos</button>
                <div>
                    <span>
                        <b>Kapsel-Nummer:</b>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'.$capData['capNumber'].'
                    </span>
                    <br>

                    <p>
                        <b>Set-Teil:</b>
                        '.($capData['isSet'] ? 'Ja <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<i>'.$setName.'</i>)' : 'Nein').'
                    </p>

                    <p>
                        <b>Zustand: </b>
                        '.($capData['isUsed'] ? 'Gebraucht' : 'Neu').'
                    </p>
                    <p>
                        <b>Drehverschluss: </b>
                        '.($capData['isTwistlock'] ? 'Ja' : 'Nein').'
                        <br>
                        <em>
                            F&uuml;r mehr Infos klicken
                        </em>
                    </p>
                </div>
            </a>
        ';

        if($isTradeDisplay)
        {
            $retval .= '<br><br><a href="/_iframe_addCapToCart?objID='.$capData['bottlecapID'].'&isSet=0" target="cartAddFrame"><button type="button" class="cel_100" style="margin-bottom: 5px; background: #32CD32"><i class="fas fa-shopping-cart"></i> Zum Tausch-Korb</button></a>';
        }
    }

    $retval .= '
            </td>
        </tr>
    ';

    return $retval;
}

function BottleCapRowInfoOverlay($capData,$isEditMode = false)
{


    $retval = '
        <div class="additionalInformationContainer" id="zusatzinfos'.$capData['bottlecapID'].'">
            <div class="additionalInformationOverlay">
                <table class="capData">
                    <tr>
                        <td rowspan=7>'.BottlecapColorScheme($capData['bottlecapCapColorShort'],$capData['bottlecapBaseColorValue'],$capData['bottlecapTextColorValue'],$capData['isUsed'],$capData['isTwistlock']).'</td>
                        <td>Kronkorkenfarbe: </td>
                        <td>'.$capData['bottlecapCapColorName'].'</td>

                        <td>Qualit&auml;t: </td>
                        <td>'.($capData['quality'] == "" ? '<span style="color: #696969">Nicht angegeben</span>' : $capData['quality']).'</td>
                    </tr>
                    <tr>
                        <td>Grundfarbe: </td>
                        <td>'.$capData['bottlecapBaseColorName'].'</td>
                    ';

                    if($isEditMode)
                    {
                        $retval .= '
                            <td>Auf Lager:</td>
                            <td>'.$capData['stock'].' St&uuml;ck</td>
                        ';
                    }
                    else
                    {
                        $retval .= '
                            <td></td>
                            <td></td>
                        ';
                    }

                    $retval .= '

                    </tr>
                    <tr>
                        <td>Textfarbe: </td>
                        <td>'.$capData['bottlecapTextColorName'].'</td>

                        <td>Tauschbar: </td>
                        <td>'.($capData['isTradeable'] ? 'Ja' : 'Nein').'</td>
                    </tr>
                    <tr>
                        <td><br></td>
                        <td><br></td>
                        <td><br></td>
                        <td><br></td>
                    </tr>
                    <tr>
                        <td>Set-Teil:</td>
                        <td>'.($capData['isSet'] ? 'Ja' : 'Nein').'</td>

                        <td>Randzeichen: </td>
                        <td>'.$capData['sidesignName'].'</td>
                    </tr>
                    <tr>
                        <td>Zustand: </td>
                        <td>'.($capData['isUsed'] ? 'Gebraucht' : 'Neu').'</td>

                        <td>KK-Nummer</td>
                        <td>'.$capData['capNumber'].'</td>
                    </tr>
                    <tr>
                        <td>Drehverschluss: </td>
                        <td>'.($capData['isTwistlock'] ? 'Ja' : 'Nein').'</td>

                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <a href="#"><div class="close" onclick="bgenScroll();">Schlie&szlig;en</div></a>
            </div>
        </div>
    ';

    return $retval;
}


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

function NavBar(...$linkKeywords)
{
    $pathStr = '';
    $i=0;
    $lastSection = '';
    foreach($linkKeywords AS $link)
    {
        if($i > 0) $pathStr .= '<i>&gt;</i>';
        $i++;

        $fragment = explode(':',$link);

        switch($fragment[0])
        {
            case 'Home': $pathStr .= '<a href="/"><span>Home</span></a>';$lastSection = 'Home';   break;
            case 'Laender': $pathStr .= '<a href="/laender"><span>L&auml;nder</span></a>';$lastSection = 'L&auml;nder';   break;
            case 'Sets': $pathStr .= '<a href="/sets"><span>Sets</span></a>'; break;$lastSection ='Sets';
            case 'Kronkorken': $pathStr .= '<a href="/kronkorken/alle"><span>Alle</span></a>';$lastSection = 'Alle';   break;
            case 'TradeCountries': $pathStr .= '<a href="/tauschen/laender"><span>L&auml;nder</span></a>';$lastSection = 'L&auml;nder';   break;
            case 'TradeSets': $pathStr .= '<a href="/tauschen/sets"><span>Sets</span></a>';$lastSection = 'Sets';   break;
            case 'CountrySub':
                $navData = MySQL::Row("SELECT * FROM countries WHERE countryShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/laender/regionen/'.$navData['countryShort'].'"><span>Regionen in '.$navData['countryDE'].'</span></a>';
                $lastSection = $navData['countryDE'];
                break;
            case 'Country':
                $navData = MySQL::Row("SELECT * FROM countries WHERE countryShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/kronkorken/'.$navData['countryShort'].'"><span>'.$navData['countryDE'].'</span></a>';
                $lastSection = $navData['countryDE'];
                break;
            case 'TradeCountry':
                $navData = MySQL::Row("SELECT * FROM countries WHERE countryShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/tauschen/kronkorken/'.$navData['countryShort'].'"><span>'.$navData['countryDE'].'</span></a>';
                $lastSection = $navData['countryDE'];
                break;
            case 'Continent':
                $navData = MySQL::Row("SELECT * FROM continents WHERE continentShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/laender/kontinent/'.$navData['continentShort'].'"><span>'.$navData['continentDE'].'</span></a>';
                $lastSection = $navData['continentDE'];
                break;
            case 'CountrySets':
                $navData = MySQL::Row("SELECT * FROM countries WHERE countryShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/sets/'.$navData['countryShort'].'"><span>'.$navData['countryDE'].'</span></a>';
                $lastSection = $navData['countryDE'];
                break;
            case 'TradeCountrySets':
                $navData = MySQL::Row("SELECT * FROM countries WHERE countryShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/tauschen/sets/'.$navData['countryShort'].'"><span>'.$navData['countryDE'].'</span></a>';
                $lastSection = $navData['countryDE'];
                break;
            case 'Region':
                $navData = MySQL::Row("SELECT * FROM regions INNER JOIN countries ON regions.countryID = countries.id WHERE regionShort = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/kronkorken/'.$navData['countryShort'].'/'.$navData['regionShort'].'"><span>'.$navData['regionDE'].'</span></a>';
                $lastSection = $navData['regionDE'];
                break;
            case 'Brewery':
                $navData = MySQL::Row("SELECT * FROM breweries INNER JOIN countries ON breweries.countryID = countries.id WHERE breweryFilepath = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/kronkorken/sammlung/'.$navData['countryShort'].'/brauerei/'.$navData['breweryFilepath'].'"><span>'.$navData['breweryName'].'</span></a>';
                $lastSection = $navData['breweryName'];
                break;
            case 'Set':
                $navData = MySQL::Row("SELECT * FROM breweries INNER JOIN countries ON breweries.countryID = countries.id INNER JOIN bottlecaps ON breweries.id = bottlecaps.breweryID INNER JOIN sets ON bottlecaps.setID = sets.id WHERE setFilepath = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/sets/'.$navData['countryShort'].'/'.$navData['setFilepath'].'"><span>'.$navData['setName'].'</span></a>';
                $lastSection = $navData['setName'];
                break;
            case 'TradeSet':
                $navData = MySQL::Row("SELECT * FROM breweries INNER JOIN countries ON breweries.countryID = countries.id INNER JOIN bottlecaps ON breweries.id = bottlecaps.breweryID INNER JOIN sets ON bottlecaps.setID = sets.id WHERE setFilepath = ?",'s',$fragment[1]);
                $pathStr .= '<a href="/tauschen/sets/'.$navData['countryShort'].'/'.$navData['setFilepath'].'"><span>'.$navData['setName'].'</span></a>';
                $lastSection = $navData['setName'];
                break;
            case 'Letter': $pathStr .= '<a href="#"><span>'.$fragment[1].'</span></a>'; $lastSection = 'Sortieren: '.$fragment[0]; break;
            case 'Sammlung': $pathStr .= '<a href="#"><span>Sammlung</span></a>'; $lastSection = 'Sammlung'; break;
            default: $pathStr .= '<a href="#"><span>'.$fragment[0].'</span></a>'; $lastSection = $fragment[0];break;
        }
    }


    echo '
        <head><title>Kro-Ko-Deal - '.$lastSection.'</title></head>
        <script type="text/javascript">
            document.getElementById("navigationBar").innerHTML = \''.$pathStr.'\';
        </script>
    ';
}

?>