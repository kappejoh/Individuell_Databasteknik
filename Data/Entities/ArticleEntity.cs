using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ArticleEntity
{
    [Key]
    public int Id { get; set; }
    public string ArticleName { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public bool IsProduct { get; set; }

    public ArticlePriceListEntity? ArticlePriceList { get; set; } = null!;
}

