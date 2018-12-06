using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập tên danh mục")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên SEO")]
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập thứ tự")]
        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }

        // Auditable
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        // Seoable
        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        //Switchable
        [Required]
        public bool Status { get; set; }
    }
}