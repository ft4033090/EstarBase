﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EstarDXBase.Web.Common.Models;

namespace EstarDXBase.Web.Models.Oragnization.EduType
{
    public class EduTypeModel : EntityCommon
	{
        public EduTypeModel()
		{
			Search = new SearchModel();
			Enabled = true;
		}

        public int Id { get; set; }

        [Display(Name = "组织机构性质名称")]
        [Required(ErrorMessage = "组织机构性质名称不能为空")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "组织机构性质{2}～{1}个字符")]
        public string Name { get; set; }

        [Display(Name = "组织机构性质描述")]
        public string Description { get; set; }

        [Display(Name = "排序")]
		[Required(ErrorMessage = "排序不能为空")]
		[RegularExpression(@"\d+", ErrorMessage = "排序必须是数字")]
        public int OrderSort { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }

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
		}

		[Display(Name = "组织机构性质名称")]
		public string Name { get; set; }

		[Display(Name = "是否已激活")]
		public bool Enabled { get; set; }

		public List<SelectListItem> EnabledItems { get; set; }
	}
}
