using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_sell : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string endPoint = @"https://www.xignite.com/xGlobalHistorical.json/ListExchanges";
        var client = new NewsAPI(endPoint);
        var json = client.MakeRequest();
        Response.Write(json);
    }

}