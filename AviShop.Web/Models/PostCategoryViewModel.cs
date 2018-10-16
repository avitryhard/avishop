using System;
using System.Collections.Generic;

namespace AviShop.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int DisplayOder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<PostViewModel> Posts { set; get; }

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