<?php
    include("_header.php");


    echo '

        <body>
            <a href="/">
                <header>
                    <center>
                        <h1>LVS <span style="color: #00a1ff">| Storage</span></h1>
                    </center>
                </header>
            </a>
            <main>
                <center>
                    ';

                    if(isset($_GET['substorage'])) echo '<h2>'.MySQL::Scalar("SELECT storage_name FROM storage_location WHERE id = ?",'i',$_GET['substorage']).'</h2> ';
                    else echo '<h2>Storage Locations</h2>';

                    echo '<table class="dataTable">';

                    $storageData = MySQL::Cluster("SELECT * FROM storage_location WHERE parent_id = 0 ORDER BY storage_name ASC");

                    foreach($storageData as $storage)
                    {

                        $subStorageCount = MySQL::Count("SELECT * FROM storage_location WHERE parent_id = ?",'s',$storage['id']);


                        echo '
                            <tr>
                                <td>
                                    <a href="/storagedata.php?storage='.$storage['id'].'">
                                        <em>'.$storage['storage_dataID'].'</em> '.$storage['storage_name'].'<br>
                                        <blockquote>'.$storage['storage_description'].'</blockquote>
                                        ';
                                        if($subStorageCount != 0)  echo '<em>('.$subStorageCount.' Unterlager)</em>';
                                        echo '
                                    </a>
                                </td>
                            </tr>
                        ';

                    }

                    echo '
                    </table>
                </center>
            </main>
        </body>


    ';


?>



