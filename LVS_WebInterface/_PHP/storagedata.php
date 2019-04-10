<?php
    include("_header.php");


    $storageData = MySQL::Row("SELECT * FROM storage_location WHERE id = ?",'i',$_GET['storage']);

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

                $storages = MySQL::Cluster("SELECT * FROM storage_location WHERE parent_id = ? ORDER BY storage_name ASC",'i',$_GET['storage']);
                $items = MySQL::Cluster("SELECT * FROM storage_elements INNER JOIN element_location ON storage_elements.id = element_location.element_id WHERE element_location.storage_id = ? ORDER BY element_name ASC",'i',$_GET['storage']);

                if(count($storages) != 0)
                {
                    echo '<h2>Storages: '.$storageData['storage_name'].'</h2>';

                    echo '<table class="dataTable">';

                    foreach($storages as $storage)
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

                    echo '</table>';
                }

                if(count($items) != 0)
                {
                    echo '<h2>Items: '.$storageData['storage_name'].'</h2>';

                    echo '<table class="dataTable">';

                    foreach($items as $item)
                    {
                        echo '
                            <tr>
                                <td>
                                    <a href="/items.php?item='.$item['id'].'">
                                        <em>'.$item['element_dataID'].'</em> '.$item['element_name'].'<br>
                                        <blockquote>'.$item['element_description'].'</blockquote>
                                    </a>
                                </td>
                            </tr>
                        ';
                    }

                    echo '</table>';
                }


                echo '
                </center>
            </main>
        </body>


    ';


?>



