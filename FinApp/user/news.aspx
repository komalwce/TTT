<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterUser.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="user_news" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="MySql.Data.MySqlClient" %>
<%@ Import Namespace="Newtonsoft.Json" %>
<script type="CS" runat="server">
    private static MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["localcon"].ConnectionString);
    private static string  news_name, news_link;
    private static int news_id;
    </script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- page content -->
        <div class="right_col" role="main">
          <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                  <%
                      if(Request.QueryString["id"]==null)
                      {
                          Response.Redirect("~/Error.aspx");
                      }
                      news_id = Convert.ToInt32(Request.QueryString["id"]);
                      con.Open();
                      MySqlCommand catcmd = new MySqlCommand("select * from news where status>@status AND news_id = @newsid", con);
                      catcmd.Parameters.AddWithValue("@status", 0);
                      catcmd.Parameters.AddWithValue("@newsid", news_id);
                      MySqlDataReader catdr = catcmd.ExecuteReader();
                      if (catdr.HasRows)
                      {
                          while (catdr.Read())
                          {
                              news_link = catdr["news_link"].ToString();
                              news_name = catdr["news_name"].ToString();
                          }
                      }
                      else
                      {
                          con.Close();
                          Response.Redirect("~/Error.aspx");
                      }
                      con.Close();
                      string endPoint = @"https://newsapi.org/v1/articles?source="+news_link+"&sortBy=top&apiKey="+Global.NewsAPIKey;

                      var client = new NewsAPI(endPoint);
                      var json = client.MakeRequest();
                      News djson = JsonConvert.DeserializeObject<News>(json);
                      Article[] articles = djson.articles;

             %>
                <div class="x_panel">
                        <div class="x_title">
                          <h2>Top News from <%= news_name %></h2>
                        
                          <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <% 
                                foreach(var article in articles)
                                {
                                 %>
                    <article class="media event">
                      <a class="pull-left date">
                        <p class="month">  <%= Convert.ToDateTime(article.publishedAt).ToString("MMM") %></p>
                        <p class="day">
                                   <%= Convert.ToDateTime(article.publishedAt).Day.ToString() %></p>
                      </a>
                      <div class="media-body">
                        <a class="title" target="_blank" href="<%=article.url %>"><%= article.title %></a>
                        <p><%= article.description %></p>
                      </div>
                    </article>
<% } %>
                  </div>
                      </div>
            </div>

          </div>
          <br />

        </div>
        <!-- /page content -->
</asp:Content>

