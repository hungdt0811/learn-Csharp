using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef {
    public class Product {
        public int ProductID {get; set;}
        
        [Required]
        [StringLength(50)]
        [Column("Tên sản phẩm", TypeName = "ntext")]
        public string Name {get; set;}

        [Column("Giá", TypeName = "money")]
        public double Price {get; set;}

        public int CatID {get; set;}
        public virtual Category Category {get; set;} // FK -> PK

        public int? CatID2 {get; set;}
        // [ForeignKey("CatID2")]
        // [InverseProperty("Products")]
        public virtual Category Category2 {get; set;} // FK -> PK

        public void ShowInfo() {
            Console.WriteLine($"{ProductID} -- {Name} -- {Price} -- {CatID}");
        } 
    }
}