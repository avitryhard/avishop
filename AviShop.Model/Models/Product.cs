using AviShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviShop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tu tang ID
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; } //ten khong dau

        [Required]
        public int CategoryID { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategories { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public virtual IEnumerable<ProductTag> ProductTags { get; set; }


    }
}