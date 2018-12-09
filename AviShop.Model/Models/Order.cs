using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AviShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tu tang ID
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        [StringLength(128)]
        [Column(TypeName = "nvarchar")]
        public string CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { set; get; }

        public virtual IEquatable<OrderDetail> OrderDetails { get; set; }
    }
}