// See https://aka.ms/new-console-template for more information
using LINQExample;
using System.Drawing;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("LINQ trong C#");
Console.WriteLine("-------------");

//Product p = new Product(1, "Abc", 1000, new string[] { "Xanh", "Do" }, 2);
//Console.WriteLine(p);

var brands = new List<Brand>() {
    new Brand{ID = 1, Name = "Công ty AAA"},
    new Brand{ID = 2, Name = "Công ty BBB"},
    new Brand{ID = 4, Name = "Công ty CCC"},
};

var products = new List<Product>()
{
    new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},             2),
    new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},            1),
    new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},                   3),
    new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},           1),
    new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},       2),
    new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},                   2),
    new Product(7, "Tủ áo",      600, new string[] {"Trắng"},                   3),
    new Product(8, "Máy tính",   900, new string[] {"Trắng", "Đen", "Nâu"},     3),
    new Product(9, "Điện thoại", 550, new string[] {"Trắng", "Đen", "Xanh"},    1),
};

// lay ra sp gia 400
var query = from p in products
            where p.Price == 400
            select p;

foreach (var product in query)
{
    Console.WriteLine(product);
}

// API Linq
Console.WriteLine("==================");
Console.WriteLine("API LINQ");
Console.WriteLine("==================");

// Select api
Console.WriteLine("Select Api");
Console.WriteLine("------------------");

products.Select(p => p.Name)
    .ToList()
    .ForEach((p) =>
    {
        Console.WriteLine(p);
    });

Console.WriteLine("------------------");

// Where api
Console.WriteLine("Where Api");
Console.WriteLine("------------------");
// lay ra ds sp co gia tu 400 - 600
products.Where(p => p.Price >= 400 && p.Price <= 600)
    .ToList()
    .ForEach(products => Console.WriteLine(products));

Console.WriteLine("------------------");

// SelectMany api
Console.WriteLine("SelectMany Api");
Console.WriteLine("------------------");

products.SelectMany(p => p.Colors)
    .ToList()
    .ForEach((p) =>
    {
        Console.WriteLine(p);
    });

Console.WriteLine("------------------");

// Sum, Max, Min, Average api
Console.WriteLine("Sum, Max, Min, Average Api");
Console.WriteLine("------------------");

var sum = products.Sum(p => p.Price);
Console.WriteLine("Tổng giá: " + sum);

var maxPrice = products.Max(p => p.Price);
Console.WriteLine("Giá lớn nhất: " + maxPrice);

var minPrice = products.Min(p => p.Price);
Console.WriteLine("Giá nhỏ nhất: " + minPrice);

var AvergePrice = products.Average(p => p.Price);
Console.WriteLine("Trung bình giá: " + AvergePrice);

Console.WriteLine("------------------");

// Join api
Console.WriteLine("Join Api");
Console.WriteLine("------------------");

var kq = products.Join(brands, p => p.Brand, b => b.ID,
            (p, b) =>
            {
                return new
                {
                    Name = p.Name,
                    Brand = b.Name
                };
            });

foreach (var sp in kq)
{
    Console.WriteLine(sp);
}

Console.WriteLine("------------------");

// GroupJoin api
Console.WriteLine("GroupJoin Api");
Console.WriteLine("------------------");

var kq1 = brands.GroupJoin(products, b => b.ID, p => p.Brand,
            (brand, pros) =>
            {
                return new
                {
                    tenThuongHieu = brand.Name,
                    cacSp = pros
                };
            });
foreach (var group in kq1)
{
    Console.WriteLine(group.tenThuongHieu);
    foreach (var sp in group.cacSp)
    {
        Console.WriteLine(sp);
    }
}

Console.WriteLine("------------------");

// Take api
Console.WriteLine("Take Api");
Console.WriteLine("------------------");

products.Take(3)
    .ToList()
    .ForEach( p => Console.WriteLine(p));

Console.WriteLine("------------------");

// Skip api
Console.WriteLine("Skip Api");
Console.WriteLine("------------------");

products.Skip(3)
    .ToList()
    .ForEach(p => Console.WriteLine(p));

Console.WriteLine("------------------");

// OrderBy / OrderByDescending api
Console.WriteLine("OrderBy / OrderByDescending Api");
Console.WriteLine("------------------");

products.OrderBy(p => p.Price)
    .ToList()
    .ForEach(p => Console.WriteLine(p));

Console.WriteLine("------------------");

products.OrderByDescending(p => p.Price)
    .ToList()
    .ForEach(p => Console.WriteLine(p));

Console.WriteLine("------------------");

// Reverse api
Console.WriteLine("Reverse Api");
Console.WriteLine("------------------");

products.Reverse();
products.ForEach(p => Console.WriteLine(p));

Console.WriteLine("------------------");

// GroudBy api
Console.WriteLine("GroudBy Api");
Console.WriteLine("------------------");

var kq2 = products.GroupBy(p => p.Price);

foreach (var group in kq2)
{
    Console.WriteLine(group.Key);
    foreach (var prod in group)
    {
        Console.WriteLine(prod);
    }
}

Console.WriteLine("------------------");

// Distincs api
Console.WriteLine("Distincs Api");
Console.WriteLine("------------------");

products.SelectMany(p => p.Colors)
    .Distinct()
    .ToList()
    .ForEach(p => Console.WriteLine(p));

Console.WriteLine("------------------");
Console.WriteLine("------------------");
//	In ra list gồm tên sp và nhãn hiệu có giá từ 300-400 và sắp xếp theo giảm dần

products.Where(p => p.Price <= 400 && p.Price >= 300)
    .OrderByDescending(p => p.Price)
    .Join(brands, p => p.Brand, b => b.ID, (p, b) =>
    {
        return new
        {
            Name = p.Name,
            Brand = b.Name,
            Price = p.Price,
        };
    })
    .ToList()
    .ForEach(info => Console.WriteLine($"{info.Name, 15} {info.Brand, 10}, {info.Price, 5}"));

Console.WriteLine("------------------");
Console.WriteLine("------------------");
Console.WriteLine("Using Linq");
Console.WriteLine("==================");
Console.WriteLine("Sử dụng Select");

// Linq
// Lay ra tap hop gom cac phan tu co gia <= 400 va co mau trang

var myQuery =   from p in products
                from c in p.Colors
                where p.Price <= 400 && c == "Trắng"
                select new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Color = c
                };

myQuery.ToList().ForEach(p => Console.WriteLine($"{p.Name} - {p.Price} - {p.Color}"));

Console.WriteLine("------------------");

// lay ra tap hop gom cac phan tu co gia 400-600, mau Xanh, ten co chua chu T, sap xep tang dan cua gia

var myQr = from p in products
           from c in p.Colors
           where p.Price <= 600
                    && p.Price >= 400
                    && c == "Xanh"
                    && p.Name.Contains("t")
           orderby p.Price
           select new
           {
               Name = p.Name,
               Price = p.Price,
               Color = p.Colors
           };


myQr.ToList().ForEach(p => Console.WriteLine($"{p.Name} - {p.Price} - {string.Join(',', p.Color)}"));

Console.WriteLine("==================");
Console.WriteLine("Sử dụng Groupby");
Console.WriteLine("------------------");

// Nhom sp theo gia

var qr = from p in products
         group p by p.Price;

qr.ToList().ForEach(group => {
    Console.WriteLine(group.Key);
    foreach (var p in group)
    {
        Console.WriteLine(p);
    }
});
Console.WriteLine("------------------");

var qr2 = from p in products
         group p by p.Price into gr
         orderby gr.Key
         select gr;

qr2.ToList().ForEach(group => {
    Console.WriteLine(group.Key);
    foreach (var p in group)
    {
        Console.WriteLine(p);
    }
});

Console.WriteLine("==================");
Console.WriteLine("Sử dụng Biến trong Linq");
Console.WriteLine("------------------");

var qr3 = from p in products
          group p by p.Price into gr
          orderby gr.Key
          let sl = "Số lượng là: " + gr.Count()
          select new
          {
              gia = gr.Key,
              cacSP = gr.ToList(),
              soLuong = sl
          };

qr3.ToList().ForEach(i =>
{
    Console.WriteLine(i.gia);
    Console.WriteLine(i.soLuong);
    i.cacSP.ForEach(p => Console.WriteLine(p));
});

Console.WriteLine("==================");
Console.WriteLine("kết hợp dữ liệu với Join");
Console.WriteLine("------------------");

var qr4 = from product in products
          join brand in brands on product.Brand equals brand.ID into t
          from b in t.DefaultIfEmpty()
          select new
          {
              name = product.Name,
              price = product.Price,
              brand = (b != null) ? b.Name : "Không có thương hiệu"
          };

qr4.ToList().ForEach(i =>
{
    Console.WriteLine($"{i.name} -- {i.price} -- {i.brand}");
});

