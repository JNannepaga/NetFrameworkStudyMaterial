using System;
using System.Web.Security;

namespace FormsAuthenticationDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bt_Login_Click(object sender, EventArgs e)
        {
            if(FormsAuthentication.Authenticate(Tb_UserName.Text, Tb_Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(Tb_UserName.Text, Cb_RememberMe.Checked);
            }
            else
            {
                Lb_Message.Text = "Invalid Credentials";
            }
        }
    }
}