using System;
using System.Collections.Generic;

// Address Class
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer Class
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

// Product Class
class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"🛒 {name} (ID: {productId}) - ${price} x {quantity} = ${GetTotalCost():F2}";
    }
}

// Order Class
class Order
{
    private Customer customer;
    private List<Product> products;
    private static Random random = new Random();

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "🎁 Your Order is Packed with Love! 🎁\n";
        foreach (var product in products)
        {
            label += "📦 " + product.GetPackingLabel() + "\n";
        }
        label += "🎉 Surprise! Use code THANKYOU10 for 10% off your next purchase! 🎉\n";
        return label;
    }

    public string GetShippingLabel()
    {
        string trackingNumber = "TRK" + random.Next(100000, 999999);
        return $"🚚 Shipping To:\n{customer.GetName()}\n🏠 {customer.GetAddress()}\n📞 Customer Support: +1-800-SHOPNOW\n📦 Tracking Number: {trackingNumber}\n🌟 Estimated Delivery: {DateTime.Now.AddDays(3):MMMM dd, yyyy}";
    }
}

// Program Execution
class Program
{
    static void Main()
    {
        // Create Address and Customers
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer cust1 = new Customer("John Doe", addr1);
        Customer cust2 = new Customer("Alice Smith", addr2);

        // Create Orders
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "A123", 800, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25, 2));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Monitor", "C789", 200, 1));
        order2.AddProduct(new Product("Mechanical Keyboard", "D012", 50, 1));

        // Display Results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("💰 Total Price: " + order1.GetTotalPrice().ToString("F2") + " USD\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("💰 Total Price: " + order2.GetTotalPrice().ToString("F2") + " USD");
    }
}