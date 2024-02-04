using System;
using System.Collections.Generic;
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
        public virtual List<Product> Products {get; set;}
        public CategoryDetail categoryDetail {get; set;}
    }
}