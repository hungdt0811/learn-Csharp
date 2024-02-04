using System;

namespace ef {
    public class CategoryDetail {
        public int CategoryDetailID {get; set;}
        public int UserID {set; get;}
        public DateTime CreateDate {set; get;}
        public DateTime UpdateDate {set; get;}
        public int CountProduct {set; get;}
        public Category category {get; set;}
    }
}