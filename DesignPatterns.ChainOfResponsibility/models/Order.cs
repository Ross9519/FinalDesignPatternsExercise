using DesignPatterns.ChainOfResponsibility.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPatterns.ChainOfResponsibility.models
{
    [Table("pizza_order")]
    internal class Order
    {
        [Key]
        [Column("pizza_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("pizza_base")]
        public string? Base {  get; set; }

        [Required]
        [Column("pizza_dough")]
        public string? Dough { get; set; }

        [Column("receipt_id")]
        public long ReceiptId { get; set; }

        public Receipt? Receipt { get; set; }

        public List<OrderIngredient> OrderIngredients { get; set; } = [];

        public override string ToString()
            => $"Base: {Base}, Dough: {Dough}, Ingredients: [{string.Join(", ", OrderIngredients.Select(i => (IngredientEnum)i.IngredientId - 1))}]";
    }
}
