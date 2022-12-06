using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerTemp
{
    public partial class TempChart : System.Web.UI.Page
    {
        public String humJSON { get; set; }
        public String tempJSON { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConvertTempToChartJSON();
        }

        protected void ConvertTempToChartJSON()
        {

            String filename = Constants.CreateFileName();

            string[] fileLines = File.ReadAllLines(filename);
            String[] lineArr = null;
            List<string> valHold = new List<string>();
            List<String> humHold = new List<string>();
            List<Object> tempData = new List<Object>();
            List<Object> humData = new List<Object>();
            String dt = "";
            String[] mon = null;
            bool firstLine = true;
            char[] delimiter = new char[] { ',' };
            foreach (String line in fileLines)
            {
                if (!firstLine)
                {
                    // split the line from the file by the comma.
                    lineArr = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    dt = lineArr[0].Replace("/", ",");
                    dt = dt.Replace(" ", ",");
                    dt = dt.Replace(":", ",");
                    mon = dt.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    mon[1] = (Convert.ToInt32(mon[1]) - 1).ToString();
                    dt = String.Join(",", mon);
                    valHold.Add(String.Concat("Date.UTC(", dt, ")"));
                    valHold.Add(Convert.ToSingle(lineArr[1]).ToString());

                    humHold.Add( valHold[0]);
                    humHold.Add( Convert.ToSingle(lineArr[2]).ToString());

                    tempData.Add(JsonConvert.SerializeObject(valHold));
                    humData.Add(JsonConvert.SerializeObject(humHold));
                    valHold.Clear();
                    humHold.Clear();
                }
                firstLine = false;
            }

            tempJSON = String.Join(",", tempData); //JsonConvert.SerializeObject(tempData);
            humJSON = String.Join(",", humData); // JsonConvert.SerializeObject(humData);
        }
    }
}