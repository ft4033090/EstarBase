using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstarDXBase.Infrastructure.Tool.Entity;
using EstarDXBase.Domain.Models.Authen;
namespace EstarDXBase.Domain.Models.Oragnization
{
    public class UserDepartment:EntityBase<int>
    {
        public int UserId { get; set; }
        public int SystemDepartmentID { get; set; }
        public virtual User User { get; set; }
        public virtual SystemDepartment SystemDepartment { get; set; }
    }
}
