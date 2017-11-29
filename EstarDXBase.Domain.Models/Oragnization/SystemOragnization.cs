using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstarDXBase.Infrastructure.Tool.Entity;
using EstarDXBase.Domain.Models.Authen;

namespace EstarDXBase.Domain.Models.Oragnization
{
    public class SystemOragnization:EntityBase<int>
    {
        public SystemOragnization() {

            this.SystemDepartment = new List<SystemDepartment>();
            this.Role = new List<Role>();
            this.User = new List<User>();
        
        }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string LayerFlag { get; set; }
        public string StandardID { get; set; }
        public string Adderss { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ContactPost { get; set; }
        public bool IsLocking { get; set; }
        public int OrderSort { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool Enabled { get; set; }

        //组织机构性质ID
        public int EduTypeID { get; set; }
        public virtual EduType EduType { get; set; }

        public virtual ICollection<SystemDepartment> SystemDepartment { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
