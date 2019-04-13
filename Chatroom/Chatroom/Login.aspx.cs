using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatroom
{
    public partial class Login : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            lblRes.Text = "";
            dbData conec = new dbData();
            Usuarios logUser = new Usuarios();
            string res = logUser.Login(txtUser.Text, txtPass.Text);
            if (res == txtUser.Text)
            {
                Session["userLog"] =res;
                Response.Redirect("theChatRoom.aspx");
            }else
            {
                lblRes.Text = res;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblRes.Text = "";
            dbData conec = new dbData();
            Usuarios logUser = new Usuarios();
            string res = logUser.Register(txtUser.Text, txtPass.Text);
            if (res == txtUser.Text)
            {
                Session["userLog"] = res;
                Response.Redirect("theChatRoom.aspx");
            }
            else
            {
                lblRes.Text = res;
            }
        }
    }
}