<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempChart.aspx.cs" Inherits="ServerTemp.TempChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server Temperature and Humidity Chart</title>
    <style>
        p {
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif
        }
    </style>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/highcharts.js"></script>
</head>
<body> 
    <h2 style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">Server Temperature and Humidity Chart</h2>

    <button type="button" onclick="window.location.href='./Default.html'">Home</button><br /><br />
    <button type="button" onclick="window.location.href='./ReadTemp.aspx'">Temperature and Humidity Data</button><br />

    <div id="container" style="width: 100%; height: 600px;"></div>

    <script>
        $(function () {
            var serverTemp = eval([<%= this.tempJSON %>]);

                for (var i = 0; i < serverTemp.length; i++) {
                    serverTemp[i][0] = eval(serverTemp[i][0]);
                    serverTemp[i][1] = eval(serverTemp[i][1]);
                }

                var humTemp = eval([<%= this.humJSON %>]);
             
                for (var i = 0; i < humTemp.length; i++) {
                    humTemp[i][0] = eval(humTemp[i][0]);
                    humTemp[i][1] = eval(humTemp[i][1]);
                }
                $('#container').highcharts({
                    chart: {
                        type: 'spline',
                        zoomType:'x'
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
    <form id="form1" runat="server">
    </form>

   
</body>
</html>
