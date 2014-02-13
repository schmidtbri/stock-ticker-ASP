using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class StockTickerSOAP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        net.webservicex.www.StockQuote quote = new net.webservicex.www.StockQuote();
        string value = "";

        try
        {
            value = quote.GetQuote(TextBox1.Text);
        }
        catch 
        {
            Label1.Text = "Error retrieving data.";
        }
        
        string price = "";
        string time = "";

        using (XmlReader reader = new XmlTextReader(new StringReader(value)))
        {
            while (reader.Read())
            {
                if (reader.ReadToFollowing("Last"))
                {
                    price = reader.ReadElementContentAsString();
                }
                if (reader.ReadToFollowing("Time"))
                {
                    time = reader.ReadElementContentAsString();
                }
            }
        }

        if (time.Equals("N/A"))
            Label1.Text = "Symbol not found.";
        else
            Label1.Text = "The stock is worth: $" + price;
    }
}