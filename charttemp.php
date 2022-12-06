<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Server Temperature Chart</title>
        <script src="jquery-2.1.3.min.js"></script>
        <script src="highcharts.js"></script>
    </head>
    <body>

        <h2>Server Temp Chart</h2>

        <div id="container" style="width:100%; height:600px;"></div>
        <script>
            $(function () {
                var serverTemp = [<?php
// put your code here
$filename = "servertempdata.txt";
$fileLines = file($filename, true);
$lineArr = array();
$valHold = array();
$humHold = array();
$tempJSON = array();
$humJSON = array();
$firstLine = true;
foreach ($fileLines as $line) {
    if (!$firstLine) {
        $lineArr = str_getcsv($line);
        $dt = str_replace("/", ",", $lineArr[0]);
        $dt = str_replace(" ", ",", $dt);
        $dt = str_replace(":", ",",$dt);
        $mon = str_getcsv($dt); 
        $mon[1] = \intval( $mon[1]) -1;
        $dt = implode(",", $mon);
        $valHold[0] = "Date.UTC(" . $dt . ")";
        $valHold[1] = (float) $lineArr[1];
        
        $humHold[0] = $valHold[0];
        $humHold[1] = (float)$lineArr[2];
        $tempJSON[$i++] = json_encode( $valHold);
        $humJSON[$i] = json_encode($humHold);
    }
    $firstLine = false;
}
echo implode(",", $tempJSON); // json_encode($tempJSON); //
?>];

           for (var i =0; i < serverTemp.length;i++) {
             serverTemp[i][0] = eval(serverTemp[i][0]);
             }

             var humTemp = [
                 <?php echo implode(",", $humJSON); ?>
             ];
             
             for (var i = 0; i < humTemp.length;i++) {
                 humTemp[i][0] = eval(humTemp[i][0]);
             }
                $('#container').highcharts({
                    chart: {
                        type: 'spline',
                        zoomType: 'x'
                    },
                    title: {
                        text: 'Server Temperature and Humidity'
                    },
                    xAxis: {
                        type: 'datetime',
                        title: {
                            text: 'Date'
                        }
                    },
                    yAxis: {
                        title: {
                            text: 'Temp (F):: Humidity (%)'
                        },
                        min: 0
                    },
                    series: [{
                            name: 'Server Temp (F)',
                            data: serverTemp
                        }, {
                            name: 'Humidity (%)',
                            data: humTemp
                        }]
                });
            });
        </script>

    </body>
</html>
