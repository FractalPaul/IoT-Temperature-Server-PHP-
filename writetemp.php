<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Write Temp File Service</title>
    </head>
    <body>
        <h2>Write Temp File from Arduino</h2>
        <?php
        // put your code here
        //echo "getting parameters";
        //echo "Date: " . date("Y-m-d H:i:s T");

        try {
            $d1 = filter_input(INPUT_GET, 'd1');
            $v1 = filter_input(INPUT_GET, 'v1');
            $d2 = filter_input(INPUT_GET, 'd2');
            $v2 = filter_input(INPUT_GET, 'v2');
            $d3 = filter_input(INPUT_GET, 'd3');
            $v3 = filter_input(INPUT_GET, 'v3');

//            $d1 = $_GET["d1"];            
//            $v1 = $_GET["v1"];
//            $d2 = $_GET["d2"];
//            $v2 = $_GET["v2"];
//            $d3 = $_GET["d3"];
//            $v3 = $_GET["v3"];
            //echo "d1 = $d1";
            $filename = "servertempdata.txt";

            if ($d1 !== null && $v1 !== null) {
                if (file_exists($filename)) {
                    $myfile = fopen($filename, "a") or die("Unable to open file!");
                    $txt = formatData($v1, $v2, $v3); //date("Y/m/d H:i:s T") . "," . $v1 . "," . $v2 . "," . $v3 . "\r\n";
                    fwrite($myfile, $txt);

                    fclose($myfile);
                } else {  // for the first time write the header line along with the data.
                    $myfile = fopen($filename, "a") or die("Unable to open file for the first time!");
                    $header = "DateTime," . $d1 . "," . $d2 . "," . $d3 . "\r\n";
                    fwrite($myfile, $header);
                    $txt = formatData($v1, $v2, $v3);  //date("Y/m/d H:i:s T") . "," . $v1 . "," . $v2 . "," . $v3 . "\r\n";
                    fwrite($myfile, $txt);

                    fclose($myfile);
                }
                echo "success\r\n";
            } else {
                echo "No data\r\n";
            }
        } catch (Exception $e) {
            echo "Caught exception: " . $e->getMessage() . "\r\n";
        }

        function formatData($v1, $v2, $v3) {
            $dt = new DateTime();
            $dt->setTimezone(new DateTimeZone('GMT'));
            $line = $dt->format('Y/m/d H:i:s') . "," . $v1 . "," . $v2 . "," . $v3 . "\r\n";
            return $line;
        }
        ?>
    </body>
</html>
