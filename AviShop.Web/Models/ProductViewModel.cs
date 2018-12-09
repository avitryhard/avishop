using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviShop.Web.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; } //ten khong dau

        public int CategoryID { get; set; }

        public string Image { get; set; }

        public string MoreImages { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public int Quantity { get; set; }
        public virtual ProductCategoryViewModel ProductCategories { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }

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

        public string Tags { get; set; }
    }
}