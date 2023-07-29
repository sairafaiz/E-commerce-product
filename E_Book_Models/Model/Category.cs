using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Book_Models.Model
{
    public class Category
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public  string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100 ,ErrorMessage = "Diplay Order must be betwwen 1 to 100")]
        public  int DisplayOrder { get; set; }
    }
}
