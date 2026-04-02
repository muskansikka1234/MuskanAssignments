using System.ComponentModel.DataAnnotations;

namespace AzureBlob.Models
{
    public class ContainerModel
    {
        [Required]
        public string Name { get; set; }
    }
}
