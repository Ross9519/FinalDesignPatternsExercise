using DesignPatterns.ChainOfResponsibility.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPatterns.ChainOfResponsibility.models
{
    [Table("ingredient")]
    internal class Ingredient
    {
        [Key]
        [Column("ingredient_id")]
        public long Id { get; set; }

        [Required]
        [Column("ingredient_name")]
        public string Name { get; set; }

        public List<OrderIngredient>? OrderIngredients { get; set; }
    }
}
