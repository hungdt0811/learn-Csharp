using System.Collections.Generic;

public class ProductName {
    private List<string> names;

    public ProductName() {
        names = new List<string>() {
            "Iphone X",
            "Samsung Note 10 Plus",
            "Nokia 1280",
            "Huaway"
        };
    }

    public List<string> GetName() => names;
}

