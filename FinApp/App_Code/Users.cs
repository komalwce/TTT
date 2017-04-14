using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;

public class Users
{

    private static MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localcon"].ConnectionString);
    
    public static bool Login(string email, string password)
    {
        string EncryptedPwd = Encrypt(password);
        string dbpwd="";
        con.Open();
        MySqlCommand logincmd = new MySqlCommand("select password from users where email=@email AND status>0", con);
        logincmd.Parameters.AddWithValue("@email", email);
        MySqlDataReader logindr = logincmd.ExecuteReader();
        if (logindr.HasRows)
        {
            while (logindr.Read())
            {
                dbpwd = logindr["password"].ToString().Trim();
            }
            if (dbpwd == EncryptedPwd)
             {
                 UpdateSession(email);
                 con.Close();
                 return true;
             }
             else
             {
                 con.Close();
                 return false;
             }
         }
         else
         {
             con.Close();
             return false;
         }
    }

    public static bool SignUp(string f_name, string l_name, string contact, string email, string password, string security_question, string security_answer)
    {
        password = Encrypt(password);
        security_answer = Encrypt(security_answer);
        if(UserExists(email))
        {
            return false;
        }
        con.Open();
        MySqlCommand signupcmd = new MySqlCommand("insert into users(f_name,l_name,email,password,contact,security_question,security_answer,role_id,status) values(@f_name,@l_name,@email,@password,@contact,@security_question,@security_answer,@role,@status)", con);
        signupcmd.Parameters.AddWithValue("@f_name", f_name);
        signupcmd.Parameters.AddWithValue("@l_name", l_name);
        signupcmd.Parameters.AddWithValue("@email", email);
        signupcmd.Parameters.AddWithValue("@password", password);
        signupcmd.Parameters.AddWithValue("@contact", contact);
        signupcmd.Parameters.AddWithValue("@role", 3);
        signupcmd.Parameters.AddWithValue("@status", 1);
        signupcmd.Parameters.AddWithValue("@security_question", security_question);
        signupcmd.Parameters.AddWithValue("@security_answer", security_answer);
        int i = signupcmd.ExecuteNonQuery();
        if (i>0)
        {
            con.Close();
            return true;   
 
        }
        else
        {
            con.Close();
            return false;
        }
    }

    public static bool UpdateProfileInfo(string f_name, string l_name, string contact, string gender, DateTime dob,string about,string email)
    {
        con.Open();
        MySqlCommand signupcmd = new MySqlCommand("update users set f_name=@f_name,l_name=@l_name,contact=@contact,gender=@gender,dob=@dob, about=@about,status=@status where email=@email", con);
        signupcmd.Parameters.AddWithValue("@f_name", f_name);
        signupcmd.Parameters.AddWithValue("@l_name", l_name);
        signupcmd.Parameters.AddWithValue("@contact", contact);
        signupcmd.Parameters.AddWithValue("@gender", gender);
        signupcmd.Parameters.AddWithValue("@dob", dob);
        signupcmd.Parameters.AddWithValue("@about", about);
        signupcmd.Parameters.AddWithValue("@status", 2);
        signupcmd.Parameters.AddWithValue("@email", email);

        int i = signupcmd.ExecuteNonQuery();
        UpdateSession(email);
        if (i > 0)
        {
            con.Close();
            return true;

        }
        else
        {
            con.Close();
            return false;
        }
    }
    public static bool UserExists(string email)
    {
        con.Open();
        MySqlCommand logincmd = new MySqlCommand("select email from users where email=@email AND status>0", con);
        logincmd.Parameters.AddWithValue("@email", email);
        MySqlDataReader logindr = logincmd.ExecuteReader();
        if (logindr.HasRows)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }

    /* Helper Function */

    public static bool AddNewAddress(string address_1, string address_2, string landmark, string city, string state, string country, string pincode,string email)
    {
        int user_id = GetUserIdByEmail(email);
        if ( user_id < 1)
        {
            return false;
        }
        con.Open();
        MySqlCommand signupcmd = new MySqlCommand("insert into address(address_1,address_2,landmark,city,state,country,pincode, status,user_id) values(@address1,@address2,@landmark,@city,@state,@country,@pincode,@status,@userid", con);
        signupcmd.Parameters.AddWithValue("@address1", address_1 );
        signupcmd.Parameters.AddWithValue("@address2",address_2 );
        signupcmd.Parameters.AddWithValue("@landmark", landmark);
        signupcmd.Parameters.AddWithValue("@city", city);
        signupcmd.Parameters.AddWithValue("@state", state);
        signupcmd.Parameters.AddWithValue("@country", country);
        signupcmd.Parameters.AddWithValue("@pincode", pincode);
        signupcmd.Parameters.AddWithValue("@userid", user_id);
        int i = signupcmd.ExecuteNonQuery();
        if (i > 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }
    public static bool RemoveAddress(string address_id,string email)
    {
        int user_id = GetUserIdByEmail(email);
        if (user_id < 1)
        {
            return false;
        }
        con.Open();
        MySqlCommand signupcmd = new MySqlCommand("delete from address where address_id = @addressid where user_id = @userid", con);
        signupcmd.Parameters.AddWithValue("@addressid", address_id);
        signupcmd.Parameters.AddWithValue("@userid", user_id);
        int i = signupcmd.ExecuteNonQuery();
        if (i > 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }
    public static bool MakeDefaultAddress(string address_id, string email)
    {
        int user_id = GetUserIdByEmail(email);
        if (user_id < 1)
        {
            return false;
        }
        con.Open();
        MySqlCommand updatecmd = new MySqlCommand("update address set status = 0 where user_id = @userid", con);
        updatecmd.Parameters.AddWithValue("@userid", user_id);
        int i = updatecmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            con.Open();
            MySqlCommand addresscmd = new MySqlCommand("update address set status = 1 where address_id = @addressid", con);
            addresscmd.Parameters.AddWithValue("@addressid", address_id);
            int j = addresscmd.ExecuteNonQuery();
            con.Close();
            if (j > 0)
            {
                UpdateSession(email);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public static string GetSecurityQuestion(string email)
    {
        string question="";
        con.Open();
        MySqlCommand checkcmd = new MySqlCommand("select security_question from users where email = @email", con);
        checkcmd.Parameters.AddWithValue("@email", email);
        MySqlDataReader checkdr = checkcmd.ExecuteReader();
        if (checkdr.HasRows)
        {
            while (checkdr.Read())
            {
                question = checkdr["security_question"].ToString();
            }
            con.Close();
            return question;
        }
        else
        {
            con.Close();
            return question;
        }
    }
    
    public static bool CheckSecurityAnswer(string answer,string email)
    {
        answer = Encrypt(answer);
        con.Open();
        MySqlCommand checkcmd = new MySqlCommand("select security_answer from users where email = @email", con);
        checkcmd.Parameters.AddWithValue("@email", email);
        MySqlDataReader checkdr = checkcmd.ExecuteReader();
        if (checkdr.HasRows)
        {
            while (checkdr.Read())
            {
                string dbanswer = checkdr["security_answer"].ToString();
                if (dbanswer == answer)
                {

                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            return false;
        }
        else
        {
            con.Close();
            return false;
        }
    }
    public static bool ResetPassword(string password,string email)
    {
        password = Encrypt(password);
        con.Open();
        MySqlCommand updatecmd = new MySqlCommand("update users set password=@password where email = @email", con);
        updatecmd.Parameters.AddWithValue("@email", email);
        updatecmd.Parameters.AddWithValue("@password", password);
        int i = updatecmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
           
            return true;
        }
        else
        {
            return false;
        }

    }
    public static bool ChangePassword(string newpassword,string email)
    {
        newpassword = Encrypt(newpassword);
        con.Open();
        MySqlCommand updatecmd = new MySqlCommand("update users set password=@password where email = @email", con);
        updatecmd.Parameters.AddWithValue("@email", email);
        updatecmd.Parameters.AddWithValue("@password", newpassword);
        int i = updatecmd.ExecuteNonQuery();
        con.Close();
         
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool ChangeQuestion(string question, string answer,string email)
    {
        answer = Encrypt(answer);
        con.Open();
        MySqlCommand updatecmd = new MySqlCommand("update users set security_question=@question AND security_answer=@answer where email = @email", con);
        updatecmd.Parameters.AddWithValue("@email", email);
        updatecmd.Parameters.AddWithValue("@question", question);
        updatecmd.Parameters.AddWithValue("@answer", answer);
        int i = updatecmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static int GetUserIdByEmail(string email)
    {
        int id = 0;
        con.Open();
        MySqlCommand checkcmd = new MySqlCommand("select user_id from users where email = @email", con);
        checkcmd.Parameters.AddWithValue("@email", email);
        MySqlDataReader checkdr = checkcmd.ExecuteReader();
        if (checkdr.HasRows)
        {
            while (checkdr.Read())
            {
                id = Convert.ToInt32(checkdr["user_id"]);
            }
            con.Close();
            return id;
        }
        else
        {
            con.Close();
            return id;
        }
    }   
    public static bool CheckLogin()
    {
        if (HttpContext.Current.Session["LoggedInUser"] != null && HttpContext.Current.Session["IsLoggedIn"]!=null)
        {
            return true;
        }
        return false;
    }

    public static bool ChangePassword(string Email, string Password, string NewPassword)
    {
        if (Login(Email, Password))
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["remotecon"].ConnectionString);
            string EPassword = Encrypt(NewPassword);
            con.Open();
            MySqlCommand changecmd = new MySqlCommand("update users set password = @password where email= @email", con);
            changecmd.Parameters.AddWithValue("@password",EPassword);
            changecmd.Parameters.AddWithValue("@email", Email);
            int i = changecmd.ExecuteNonQuery();
            if (i > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
   
        }
        else
        {
            return false;
        }
    }
    public static bool Logout()
    {
        if (HttpContext.Current.Session["LoggedInUser"] != null || HttpContext.Current.Session["IsLoggedIn"] !=null )
        {
            HttpContext.Current.Session["LoggedInUser"] = null;
            HttpContext.Current.Session["IsLoggedIn"] = null;
            return true;
        }
        return false;
    }

    private static void UpdateSession(string email)
    {
        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localcon"].ConnectionString);
        con.Open();
        MySqlCommand sessioncmd = new MySqlCommand("select u.user_id,u.email,u.f_name,u.l_name,u.password,u.contact,u.dob,u.gender,u.about,u.profile_pic,r.role_name, u.status from users u inner join roles r on u.role_id = r.role_id where email='harshal@cbainc.in' AND u.status > 0 ", con);
        sessioncmd.Parameters.AddWithValue("@email",email);
        MySqlDataReader logindr = sessioncmd.ExecuteReader();
        if (logindr.HasRows)
        {
            var result = logindr;
            if (result.Read())
            {
                Dictionary<string, string> Loggedinuser = new Dictionary<string, string>();
                Loggedinuser.Add("user_id", result["user_id"].ToString());
                Loggedinuser.Add("f_name", result["f_name"].ToString());
                Loggedinuser.Add("l_name", result["l_name"].ToString());
                Loggedinuser.Add("full_name", result["f_name"].ToString() + " " + result["l_name"].ToString());
                Loggedinuser.Add("email", result["email"].ToString());
                Loggedinuser.Add("user_role", result["role_name"].ToString());
                Loggedinuser.Add("contact", result["contact"].ToString());
                Loggedinuser.Add("dob", result["dob"].ToString());
                Loggedinuser.Add("gender", result["gender"].ToString());
                Loggedinuser.Add("about", result["about"].ToString());
                Loggedinuser.Add("profile_pic", result["profile_pic"].ToString());
                Loggedinuser.Add("status", result["status"].ToString());
                
                HttpContext.Current.Session["IsLoggedIn"] = true;
                
                HttpContext.Current.Session["LoggedInUser"] = Loggedinuser;
            }
        }
        con.Close();

    }
    private static string Encrypt(string clearText)
    {

        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(clearText);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }
    
}