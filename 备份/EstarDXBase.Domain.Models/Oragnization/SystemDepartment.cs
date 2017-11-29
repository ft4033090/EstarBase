using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstarDXBase.Infrastructure.Tool.Entity;
namespace EstarDXBase.Domain.Models.Oragnization
{
    public class SystemDepartment : EntityBase<int>
    {
        public SystemDepartment() {

            this.UserDepartment = new List<UserDepartment>();
        
        }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public int OrderSort { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool Enabled { get; set; }

        //组织机构ID
        public int SystemOragnizationID { get; set; }
        public virtual SystemOragnization SystemOragnization { get; set; }

        public virtual ICollection<UserDepartment> UserDepartment { get; set; }
    }
}
