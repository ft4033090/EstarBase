using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EstarDXBase.Web.Common.Models;

namespace EstarDXBase.Web.Models.Oragnization.SystemDepartments
{
    public class SystemDepartmentsModel : EntityCommon
	{
        public SystemDepartmentsModel()
		{
            Enabled = true;
			Search = new SearchModel();
            ParentItems = new List<SelectListItem>() {
                new SelectListItem { Text = "--- 父节点 ---", Value = "0"}, 
            };

		}
        public int Id { get; set; }

        [Display(Name = "部门名称")]
        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "部门{2}～{1}个字符")]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int SystemOragnizationID { get; set; }

        [Display(Name = "排序")]
		[Required(ErrorMessage = "排序不能为空")]
		[RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "上级部室")]
        public string ParentName { get; set; }
        public List<SelectListItem> ParentItems { get; set; }

		public string EnabledText
		{
			get
			{
				if (Enabled == true)
				{
					return "是";
				}
				else
				{
					return "否";
				}
			}
			set { }
		}

		public SearchModel Search { get; set; }
    }

	public class SearchModel
	{
		public SearchModel()
		{
            EnabledItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- 请选择 ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "是", Value = "1" }, 
                new SelectListItem { Text = "否", Value = "0" }
            };
            ParentItems = new List<SelectListItem>() {
                new SelectListItem { Text = "--- 请选择 ---", Value = "0"}, 
            };
		}
        [Display(Name = "上级部门")]
        public string ParentName { get; set; }

        public List<SelectListItem> ParentItems { get; set; }

        public int ParentId{ get; set; }

        public int SystemOragnizationID { get; set; }

		[Display(Name = "部门名称")]
		public string Name { get; set; }

		[Display(Name = "是否已激活")]
		public bool Enabled { get; set; }

        public List<SelectListItem> EnabledItems { get; set; }
	}
}
