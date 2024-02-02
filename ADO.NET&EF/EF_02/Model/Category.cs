using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef {
    [Table("category")]
    public class Category {
        [Key]
        public int CategoryID {get; set;}
        [StringLength(100)]
        public string Name {get; set;}
        [Column(TypeName = "ntext")]
        public string Description {get; set;}
    }
}