using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstarDXBase.Infrastructure.Tool.Entity;
using EstarDXBase.Domain.Models.Oragnization;

namespace EstarDXBase.Domain.Models.Authen
{
    public class Role : EntityBase<int>
    {
        public Role()
        {
			this.UserRole = new List<UserRole>();
			this.RoleModulePermission = new List<RoleModulePermission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderSort { get; set; }
        public bool Enabled { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        //添加组织机构ID
        public int SystemOragnizationID { get; set; }
        public virtual SystemOragnization SystemOragnization { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
		public virtual ICollection<RoleModulePermission> RoleModulePermission { get; set; }
    }
}
