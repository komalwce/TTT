using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PanelError.Visible = false;
            PanelSuccess.Visible = false;
        }

        if (Request.QueryString["logout"] != null)
        {
            if(Request.QueryString["logout"]=="true")
            {
                LblSuccess.Text = "You have logged out successfully!";
            }
            else
            {
                LblError.Text = "Unable to logout! Please try again!";
            }
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string email = TxtEmail.Value.ToString().Trim();
        string password = TxtPassword.Value.ToString().Trim();
        if (Users.Login(email, password))
        {
            dynamic u = HttpContext.Current.Session["LoggedInUser"];
            Response.Redirect(u["user_role"] + "/Default.aspx");
        }
        else
        {
            PanelSuccess.Visible = false;
            PanelError.Visible = true;
            LblError.Text = "Incorrect username or password!";
        }
    }
}
