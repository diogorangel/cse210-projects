//Author : Diogo Rangel Dos Santos
// Online Ordering System Assingment

using System;
using System.Collections.Generic;

// Address class to hold the customer's address details
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }
     // Method to check if the address is in the USA
    public bool IsInBRA()
    {
        return country.ToLower() == "bra";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Product class to represent a product in the order
public class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    // Constructor
    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate the total cost of this product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Method to return the product details as a string
    public string GetProductInfo()
    {
        return $"{name} (ID: {productId}) - ${price} x {quantity} = ${GetTotalCost()}";
    }

    // Getters for the properties
    public string GetName() { return name; }
    public int GetProductId() { return productId; }
    public double GetPrice() { return price; }
    public int GetQuantity() { return quantity; }
}

// Customer class to represent a customer
public class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public bool IsInBRA()
    {
        return address.IsInBRA();
    }

    // Method to get the customer's name
    public string GetName()
    {
        return name;
    }

    // Method to get the customer's address
    public Address GetAddress()
    {
        return address;
    }
}

// Order class to represent an order with products and customer
public class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total cost of the order
    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost based on whether the customer is in the USA
        double shippingCost = customer.IsInUSA() ? 5 : 35;
        total += shippingCost;

        return total;
        
    }

    // Method to return the packing label (name and product id of each product)
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Method to return the shipping label (customer name and address)
    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        return label;
    }
}

// Program class to demonstrate the ordering system
public class Program
{
    public static void Main()
    {
        // Create customer addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", 101, 799.99, 1);
        Product product2 = new Product("Mouse", 102, 19.99, 2);
        Product product3 = new Product("Keyboard", 103, 49.99, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}\n");
    }
}
