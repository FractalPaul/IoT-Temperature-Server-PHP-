using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerTemp
{
    public partial class ReadTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadFileContents();
        }

        protected void ReadFileContents()
        {
            String tempFile = Constants.CreateFileName();

            if (File.Exists(tempFile))
            {
                String[] lines = File.ReadAllLines(tempFile);

                Label1.Text = String.Join("<br/>", lines);
            }
        }
    }
}