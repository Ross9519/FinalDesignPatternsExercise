using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPatterns.ChainOfResponsibility.models
{
    [Table("receipt")]
    internal class Receipt
    {
        [Key]
        [Column("receipt_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set;}

        [Required]
        [Column("receipt_cost")]
        public int Cost { get; set; }

        [Required]
        [Column("order_id")]
        public long OrderId { get; set; }

        public Order? Order { get; set; }

        public override string ToString()
            => $"Id: {Id}, OrderId: {OrderId}, Cost: {Cost} Euros";
    }
}
