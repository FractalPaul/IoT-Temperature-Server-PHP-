<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Test PHP</title>
    </head>
    <body>
        <h2>PHP test code:</h2>
        <?php
        // put your code here
        echo "Now Date: " . strtotime('now');
        ?>

        <p>Javascript date sample from PHP:</p>
        <div id="jsdate"></div>
        <p>PHP Date GMT</p>
        <p><?php
            $dt = new DateTime();
            $dt->setTimezone(new DateTimeZone('GMT'));
            echo $dt->format('Y/m/d H:i:s');
            ?></p>
        <script>
            var js_date = new Date("<?php echo date('Y/m/d H:i:s T'); ?>");
            var divHnd = document.getElementById('jsdate');
            divHnd.innerHTML = js_date;
        </script>
    </body>
</html>
