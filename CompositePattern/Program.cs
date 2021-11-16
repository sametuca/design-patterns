Categories telefonlar = new Categories("Telefonlar");
Categories apple = new Categories("Apple Telefonlar");
Categories samsung = new Categories("Samsung Telefonlar");

Product samsung01 = new Product("samsung 01");

Product apple01 = new Product("iphone 01");
Product apple02 = new Product("iphone 02");
Product apple03 = new Product("iphone 03");
Product apple04 = new Product("iphone 04");

apple.AddProduct(apple01);
apple.AddProduct(apple02);
apple.AddProduct(apple03);
apple.AddProduct(apple04);

samsung.AddProduct(samsung01);

telefonlar.AddProduct(apple);
telefonlar.AddProduct(samsung);
telefonlar.WriteDetail();

public abstract class IProduct
{
    public abstract void WriteDetail();
}
public class Categories : IProduct
{
    public string Name { get; set; }

    public List<IProduct> productList = new List<IProduct>();
    public Categories(string name)
    {
        Name = name;
    }
    public override void WriteDetail()
    {

        System.Console.WriteLine($"Kategori Adı - {Name}");
        foreach (var item in productList)
        {
            item.WriteDetail();
        }

    }
    public void AddProduct(IProduct product)
    {
        productList.Add(product);
    }
}
public class Product : IProduct
{
    public string Name { get; set; }

    public Product(string name)
    {
        Name = name;
    }
    public override void WriteDetail()
    {
        System.Console.WriteLine(Name);
    }
}