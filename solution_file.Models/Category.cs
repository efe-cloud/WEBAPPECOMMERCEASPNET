using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace solution_file.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Aralık 1 ile 100 arasından olmalı")]
        public int DisplayOrder { get; set; }

    }
}
