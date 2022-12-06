<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Read Temp File Arduino</title>
    </head>
    <body>
        <h2>Temp Data Content</h2>
        <?php
       // put your code here
        $filename = "./servertempdata.txt";
        
        if (file_exists($filename)) {
            echo "file found";
        } else {
            echo "file NOT found.";
        }
         //$myfile = fopen("pdata.txt", "a") or die("Unable to open file!");
        echo "<br>" ;
       
        $fileLines = file($filename, true);
         
        foreach ($fileLines as $line) {
        echo $line;
        echo "<br>";
        }
        ?>
    </body>
</html>
