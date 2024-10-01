using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace User_Admin
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_Id) from Login_Tab where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = objcls.fun_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if(cid1==1)
            {
                string str1 = "select count(Reg_Id) from Login_Tab where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string regid = objcls.fun_scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Log_Type from Login_Tab where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string logtype = objcls.fun_scalar(str2);
                if(logtype=="admin")
                {
                    Label1.Text = "Admin";
                }
                else if(logtype=="user")
                {
                    Label1.Text = "User";
                }
            }
            else
            {
                Label1.Text = "Invalid Username and Password";
            }
        }
    }
}