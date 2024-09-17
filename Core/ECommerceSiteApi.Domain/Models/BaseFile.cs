
using ECommerceSiteApi.Domain.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSiteApi.Domain.Models;

public class BaseFile:BaseEntity
{
    [NotMapped]
    public DateTime UpdatedDate { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string Storage { get; set; }

}
