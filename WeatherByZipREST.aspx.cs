using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class WeatherByZipREST : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string value = "";

        // Create web client simulating IE6.
        using (WebClient client = new WebClient())
        {
            client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " + "(compatible; MSIE 6.0; Windows NT 5.1; " + ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";

            try
            {
                value = client.DownloadString("http://wsf.cdyne.com/WeatherWS/Weather.asmx/GetCityWeatherByZIP?ZIP=" + TextBox1.Text);
            }
            catch
            {
                Label1.Text = "Error retriving data.";
            }

            Label1.Text = value;
            string result = "";

            using (XmlReader reader = new XmlTextReader(new StringReader(value)))
            {
                while (reader.Read())
                {
                    if (reader.ReadToFollowing("Temperature"))
                    {
                        result = reader.ReadElementContentAsString();
                    }
                    Label1.Text = "Temperature: " + result + " degrees.";
                }
            }
            if (result == "")
            {
                Label1.Text = "Zip code not found";
            }
        }
    }
}