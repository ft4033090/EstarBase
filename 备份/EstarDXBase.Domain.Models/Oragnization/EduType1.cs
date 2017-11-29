using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstarDXBase.Infrastructure.Tool.Entity;
namespace EstarDXBase.Domain.Models.Oragnization
{
    public class EduType1:EntityBase<int>
    {
        public EduType1() 
        {
            this.SystemOragnization = new List<SystemOragnization>();
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


        public virtual ICollection<SystemOragnization> SystemOragnization { get; set; }
    }
}
