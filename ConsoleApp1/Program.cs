// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
Product Apple = new Product(10, "Apple", 10, "Fruits", "itsanapple");
Seller Jacob = new Seller("Jacob", "0", 10, "itsacontract");
Store Magnit = new Store("Magnit", "Udoma", "9:00-22:00", Jacob);
Magnit.storeSeller.AddProduct(Apple);
Console.WriteLine(Magnit.storeSeller.GetSellerInfo());

public class Store
{
    private string storeName { get; set; }
    private string location { get; set; }
    private string storeHours { get; set; }
    public Seller storeSeller { get; set; }
    private List<Product> storeProducts = new();
    public Store(string _storeName, string _location, string _storeHours, Seller _storeSeller)
    {
        storeName = _storeName;
        location = _location;
        storeHours = _storeHours;
        storeSeller = _storeSeller;
    }
    public void AddStoreProduct(Product product)
    {
        storeProducts.Add(product);
    }
    public void AddSeller(Seller seller)
    {
        storeSeller = seller;
    }
    public void ListProducts()
    {
        foreach (var product in storeProducts)
        {
            Console.WriteLine(product.Name);
        }
    }
    public string GetStoreInfo()
    {
        var products = "";
        foreach (var product in storeProducts)
        {
            products += product.Name +", ";
        }
        return $"store location:{location}, store name:{storeName},store products: {products}";
    }
    
}
public class Seller
{
    public string Name { get; set; }
    private string EmployeeId { get; set; }
    protected decimal Salary { get; set; }
    internal string ContractInfo { get; set; }
    private List<Product> SellerProducts = new List<Product>();
    public Seller(string _Name, string _EmployeeId, decimal _Salary, string _ContractInfo)
    {
        Name = _Name;
        EmployeeId = _EmployeeId;
        Salary = _Salary;
        ContractInfo = _ContractInfo;
    }
    public void AddProduct(Product product)
    {
        SellerProducts.Add(product);
    }
    public void SetProduct(Product product, int quantity)
    {
        product.UpdateQuantity(quantity);
    }
    public string GetSellerInfo()
    {
        string products = "";
        foreach (var item in SellerProducts)
        {
            products += item.Name + ",";
        }
        return $"Name:{Name}, Salary:{Salary}, ContractInfo:{ContractInfo}, Products:{products}";

    }
}
public class Product
{
    private decimal Price { get; set; }
    public string Name { get; set; }
    private int Quantity { get; set; }
    protected string Category { get; set; }
    internal string Description { get; set; }
    public Product(decimal _Price, string _Name, int _Quantity, string _Category, string _Description)
    {
        Name = _Name;
        Price = _Price;
        Quantity = _Quantity;
        Category = _Category;
        Description = _Description;
    }
    public decimal GetTotalPrice()
    {
        return Price * Quantity;
    }
    public void UpdateQuantity(int amount)
    {
        Quantity = amount;
    }
    public string GetProductInfo()
    {
        return $"price:{Price}, quantity:{Quantity}, category:{Category}, name:{Name}, description{Description}";
    }
}