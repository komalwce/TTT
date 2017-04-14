using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;

public partial class user_buy : System.Web.UI.Page
{
    private static MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localcon"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string endPoint = @"https://www.quandl.com/api/v3/datasets/WIKI/FB/data.json?api_key=-ya2sqK7xxbRbbBekB-f";
        var client = new NewsAPI(endPoint);
        var json = client.MakeRequest();
        Response.Write(json);
        Rootobject djson = JsonConvert.DeserializeObject<Rootobject>(json);

    }
}

public class Rootobject
{
    public Dataset_Data dataset_data { get; set; }
}

public class Dataset_Data
{
    public object limit { get; set; }
    public object transform { get; set; }
    public object column_index { get; set; }
    public string[] column_names { get; set; }
    public string start_date { get; set; }
    public string end_date { get; set; }
    public string frequency { get; set; }
    public object[][] data { get; set; }
    public object collapse { get; set; }
    public string order { get; set; }
}

    

