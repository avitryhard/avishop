using System;
using System.Collections.Generic;

namespace AviShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

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
        public bool Status { get; set; }
    }
}