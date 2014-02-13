using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeatherByZipSOAP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            com.cdyne.wsf.Weather wethr = new com.cdyne.wsf.Weather();

            com.cdyne.wsf.WeatherReturn data = wethr.GetCityWeatherByZIP(TextBox1.Text);

            if(data.WeatherID.ToString().Equals("-1"))
                Label1.Text = "Invalid zip code";
            else
                Label1.Text = "The temperature is: " + data.Temperature;
        }
        catch 
        {
            Label1.Text = "Temperature could not be retrieved.";
        }
        

        
    }
}