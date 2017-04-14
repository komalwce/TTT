using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSignup_Click(object sender, EventArgs e)
    {
        if(Users.SignUp(TxtFName.Value,TxtLName.Value,TxtPhone.Value,TxtEmail.Value,TxtPassword.Value,TxtQuestion.Value,TxtAnswer.Value))
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

        }
    }
}