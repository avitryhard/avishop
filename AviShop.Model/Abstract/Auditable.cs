using System;
using System.ComponentModel.DataAnnotations;

namespace AviShop.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        // Auditable
        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        // Seoable
        [MaxLength(256)]
        public string MetaKeyword { get; set; }

        [MaxLength(256)]
        public string MetaDescription { get; set; }

        //Switchable
        public bool Status { get; set; }
    }
}