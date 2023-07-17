using System;
using System.Collections.Generic;

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        products = new List<Product>();
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.Price * product.Quantity;
        }

        if (customer.Address.IsInUSA())
        {
            totalPrice += 5; // USA shipping cost
        }
        else
        {
            totalPrice += 35; // International shipping cost
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in products)
        {
            packingLabel += "Product Name: " + product.Name + ", Product ID: " + product.ProductID + Environment.NewLine;
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return "Customer Name: " + customer.Name + Environment.NewLine + "Address: " + customer.Address.GetFullAddress();
    }
}

class Product
{
    public string Name { get; set; }
    public int ProductID { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public string GetFullAddress()
    {
        return Street + ", " + City + ", " + State + ", " + Country;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address
        {
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            Country = "USA"
        };

        Customer customer1 = new Customer
        {
            Name = "John Doe",
            Address = address1
        };

        Product product1 = new Product
        {
            Name = "Product 1",
            ProductID = 1,
            Price = 10,
            Quantity = 2
        };

        Product product2 = new Product
        {
            Name = "Product 2",
            ProductID = 2,
            Price = 15,
            Quantity = 1
        };

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("Total Price: $" + order1.CalculateTotalPrice());

        Console.WriteLine();

        Address address2 = new Address
        {
            Street = "456 Elm Street",
            City = "London",
            State = "London",
            Country = "UK"
        };

        Customer customer2 = new Customer
        {
            Name = "Jane Smith",
            Address = address2
        };

        Product product3 = new Product
        {
            Name = "Product 3",
            ProductID = 3,
            Price = 20,
            Quantity = 3
        };

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("Total Price: $" + order2.CalculateTotalPrice());

        Console.ReadLine();
    }
}
