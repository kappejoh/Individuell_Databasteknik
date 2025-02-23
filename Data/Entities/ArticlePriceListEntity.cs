using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ArticlePriceListEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ArticleId { get; set; }
    public ArticleEntity Article { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

}

