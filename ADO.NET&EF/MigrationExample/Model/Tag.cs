using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationExample {
    [Table("Tag")]
    public class Tag {
        // [Key]
        // public string TagId {get; set;}
        [Column(TypeName = "ntext")]
        public string Content {get; set;}
        [Key]
        public int TagId {get; set;}
    }
}