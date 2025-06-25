
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.DAL.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    public DateOnly PublishDate { get; set; }

    [MaxLength(100)]
    public string Genre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
}