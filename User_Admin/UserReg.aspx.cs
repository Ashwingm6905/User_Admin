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
    public partial class UserReg : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_Id) from Login_Tab";
            string maxregid = objcls.fun_scalar(sel);
            int reg_id = 0;
            if (maxregid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }
            string ins = "insert into User_Reg values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "')";
            int i = objcls.fun_non_query(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_Tab values(" + reg_id + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','user','active')";
                int j = objcls.fun_non_query(inslog);
            }
        }
    }
}