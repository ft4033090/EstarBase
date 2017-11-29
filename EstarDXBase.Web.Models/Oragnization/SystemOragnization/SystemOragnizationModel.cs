using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EstarDXBase.Web.Common.Models;

namespace EstarDXBase.Web.Models.Oragnization.SystemOragnization
{
    public class SystemOragnizationModel : EntityCommon
	{
        public SystemOragnizationModel()
		{
            Enabled = true;
            IsLocking = false;
			Search = new SearchModel();
            EduTypeItems = new List<SelectListItem>();
            ParentItems = new List<SelectListItem>();
		}
        public int Id { get; set; }

        [Display(Name = "组织机构名称")]
        [Required(ErrorMessage = "组织机构名称不能为空")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "组织机构{2}～{1}个字符")]
        [Remote("CheckNameExists", "SystemOragnization", ErrorMessage = "组织机构名称已存在")] // 远程验证（Ajax）
        public string Name { get; set; }

        [Display(Name = "标准代码")]
        [RegularExpression(@"[^\u4e00-\u9fa5]+", ErrorMessage = "只能是数字字母和符号")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "最小4位最大20位")]
        [Remote("CheckStandardIdExists", "SystemOragnization", ErrorMessage = "标准码已存在")] // 远程验证（Ajax）
        public string StandardID { get; set; }

        public int ParentId { get; set; }

        public string LayerFlag { get; set; }

        public int EduTypeID { get; set; }

        [Display(Name = "地址")]
        [StringLength(200, ErrorMessage = "地址长度不能超过200字")]
        public string Address { get; set; }

        [Display(Name = "邮编")]
        [RegularExpression(@"^[1-9]\d{5}$", ErrorMessage = "邮编格式不正确")]
        public string ZipCode { get; set; }

        [Display(Name = "电话")]
        [RegularExpression(@"^[0-9][0-9-]+$", ErrorMessage = "电话号码格式不正确")]
        public string Phone { get; set; }

        [Display(Name = "Email地址")]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email地址格式不正确")]
        public string Email { get; set; }

        [Display(Name = "联系人")]
        [StringLength(50, ErrorMessage = "联系人不能超过50字")]
        public string Contact { get; set; }

        [Display(Name = "联系人职位")]
        [StringLength(50, ErrorMessage = "联系人职务不能超过50字")]
        public string ContactPost { get; set; }

        [Display(Name = "是否锁定")]
        public bool IsLocking { get; set; }

        [Display(Name = "排序")]
		[Required(ErrorMessage = "排序不能为空")]
		[RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

        [Display(Name = "组织机构性质")]
        public string EduTypeName { get; set; }
        public List<SelectListItem> EduTypeItems { get; set; }

        [Display(Name = "上级组织机构")]
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

        public string IsLockingText
        {
            get
            {
                if (IsLocking == true)
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
            IsLockingItems = new List<SelectListItem> { 
                new SelectListItem { Text = "--- 请选择 ---", Value = "-1", Selected = true }, 
                new SelectListItem { Text = "是", Value = "1" }, 
                new SelectListItem { Text = "否", Value = "0" }
            };
            EduTypeItems = new List<SelectListItem>() {
                new SelectListItem { Text = "--- 请选择 ---", Value = "0"}, 
            };
            ParentItems = new List<SelectListItem>() {
                new SelectListItem { Text = "--- 请选择 ---", Value = "0"}, 
            };
		}
        [Display(Name = "上级组织机构")]
        public string ParentName { get; set; }

        public List<SelectListItem> ParentItems { get; set; }

        public int ParentId{ get; set; }

        [Display(Name = "组织机构性质")]
        public string EduTypeName { get; set; }

        public int EduTypeID { get; set; }

        public List<SelectListItem> EduTypeItems { get; set; }

		[Display(Name = "组织机构名称")]
		public string Name { get; set; }

		[Display(Name = "是否已激活")]
		public bool Enabled { get; set; }

        [Display(Name = "是否审核")]
        public bool IsLocking { get; set; }

		public List<SelectListItem> EnabledItems { get; set; }

        public List<SelectListItem> IsLockingItems { get; set; }
	}
}
