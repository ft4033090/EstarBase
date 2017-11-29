using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstarDXBase.Core.Service.Authen;
using System.ComponentModel.Composition;
namespace EstarDXBase.Web.Common.User
{
    [Export]
    public class UserMembership 
    {
        [Import]
        public IUserService UesrService { get; set; }

        [Import]
        public IUserRoleService UserRoleService { get; set; }



    }
}
