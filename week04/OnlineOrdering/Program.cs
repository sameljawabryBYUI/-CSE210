using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        Address address2 = new Address("456 High Holborn", "London", "Greater London", "UK");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-01", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "MK-05", 85.00, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("USB-C Hub", "UH-99", 40.00, 1));
        order2.AddProduct(new Product("Monitor Stand", "MS-22", 35.00, 2));
        order2.AddProduct(new Product("Webcam", "WC-1080", 60.00, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"--- Order #{orderNumber} ---");
            Console.WriteLine("PACKING LABEL:");
            Console.WriteLine(order.GetPackingLabel());
            
            Console.WriteLine("SHIPPING LABEL:");
            Console.WriteLine(order.GetShippingLabel());
            
            Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalCost():0.00}\n");
            orderNumber++;
        }
    }
}