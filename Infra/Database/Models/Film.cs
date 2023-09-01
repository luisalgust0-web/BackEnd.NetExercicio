using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Namespace;

namespace WebExercicios.Infra.Database.Models;
[Table("film")]
public class Film
{
    [Key]
    public int Film_id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Release_year { get; set; }
    [ForeignKey("Language")]
    public int Language_id { get; set; }
    [ForeignKey("Original_language")]
    public int? Original_language_id { get; set; }
    public int Rental_duration { get; set; }
    public int Rental_rate { get; set; }
    public int Length { get; set; }
    public int Replacement_cost { get; set; }
    public string Rating { get; set; }
    public string Special_features { get; set; }
    public DateTime Last_update { get; set; }

    public Language Language { get; set; }
    public Language Original_language { get; set; }
}
