using System;
using Microsoft.AspNet.Identity;
using Model = IdentityOwinIntegrationWithoutEF.Models;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class User : Model.MyUser, IUser<int>
    {

    }
}