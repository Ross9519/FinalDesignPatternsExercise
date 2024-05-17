using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPatterns.ChainOfResponsibility.models
{
    [Table("order_ingredient")]
    internal class OrderIngredient
    {
        [Key]
        [Column("order_id")]
        public long OrderId { get; set; }

        [Key]
        [Column("ingredient_id")]
        public long IngredientId { get; set; }

        public Order? Order { get; set; }

        public Ingredient? Ingredient { get; set; }
    }
}
