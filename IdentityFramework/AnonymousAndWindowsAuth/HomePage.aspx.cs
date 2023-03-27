using System;
using System.Security.Principal;

namespace AnonymousAndWindowsAuth
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write($"Application Account : {WindowsIdentity.GetCurrent().Name} <br/>User Account : {User.Identity.Name}");
        }
    }
}