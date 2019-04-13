using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chatroom
{
    public partial class theChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if  (Session["userLog"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else{
                if (Session["userLog"].ToString().Length > 0)
                {
                    displayname1.Text = Session["userLog"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
           
        }
    }
}