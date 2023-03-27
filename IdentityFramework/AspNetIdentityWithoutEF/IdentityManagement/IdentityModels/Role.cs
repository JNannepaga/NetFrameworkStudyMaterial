using Model = IdentityOwinIntegrationWithoutEF.Models;
using Microsoft.AspNet.Identity;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class Role : Model.MyRole, IRole<int>
    {
    }
}