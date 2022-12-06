using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerTemp
{
    public partial class WriteTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             string d1 = Request.QueryString["d1"];
             string v1 = Request.QueryString["v1"];
             String d2 = Request.QueryString["d2"];
             String v2 = Request.QueryString["v2"];
             String d3 = Request.QueryString["d3"];
             String v3 = Request.QueryString["v3"];

             Label1.Text = String.Concat("D1 = ", d1, " & V1 = ", v1);
             Label2.Text = String.Concat("D2 = ", d2, " & V2 = ", v2);
             Label3.Text = String.Concat("D3 = ", d3, " & V3 = ", v3);

             List<KeyValuePair<String, String>> keyVals = ConvertToKeyValuePair(new String[] { d1, d2, d3 }, new String[] { v1, v2, v3 });
             PersistData(keyVals);
        }

        protected List<KeyValuePair<string, string>> ConvertToKeyValuePair(string[] keys, string[] vals)
        {
            List< KeyValuePair<String,String>> keyVals = new List<KeyValuePair<String, String>>();

            for (int i=0; i < keys.Length; i++) {
                keyVals.Add(new KeyValuePair<String, String>(keys[i], vals[i]));
            }

            return keyVals;
        }


        protected void PersistData(List< KeyValuePair<String, String>> keyVals)
        {
            if (Constants.IsNullKeys(keyVals))
            {
                String line = Constants.ExtractValsFrom(keyVals, new String[] { DateTime.UtcNow.ToString() });
                
                String tempFileName = Constants.CreateFileName();

                if (File.Exists(tempFileName))
                {
                    File.AppendAllText(tempFileName, line);
                }
                else
                {
                    String header = Constants.ExtractKeysFrom(keyVals, new String[] { "DateTimeUTC" });

                    File.WriteAllText(tempFileName, String.Concat(header, Environment.NewLine, line));
                }
            }
        }

        
       
    }
}