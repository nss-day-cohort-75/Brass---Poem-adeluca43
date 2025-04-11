
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>
{
    new Product { Name = "The Raven", Price = 12.99M, ProductTypeId = 1 },
    new Product { Name = "Leaves of Grass", Price = 15.50M, ProductTypeId = 1 },
    new Product { Name = "Trumpet", Price = 299.99M, ProductTypeId = 2 },
    new Product { Name = "Trombone", Price = 349.00M, ProductTypeId = 2 },
    new Product { Name = "French Horn", Price = 425.75M, ProductTypeId = 2 }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType { Id = 1, Title = "Poem" },
    new ProductType { Id = 2, Title = "Brass" }
};
//put your greeting here
Console.WriteLine("Welcome to Brass & Poem!");

//implement your loop here
string option = null;
while (option != "5")
{
    DisplayMenu();

    option = Console.ReadLine();

    if (option == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (option == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (option == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (option == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (option == "5")
    {
        Console.WriteLine("Thanks for using Brass & Poem!");
    }
}



void DisplayMenu()
{
    Console.WriteLine(@"
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];


        string typeTitle = productTypes.First(item => item.Id == product.ProductTypeId).Title;

        Console.WriteLine($"{i + 1}. {product.Name}: ${product.Price}, {typeTitle}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the number of the product you'd like to delete:");

    DisplayAllProducts(products, productTypes);

    string userInputDelete = Console.ReadLine();
    int productNumber = int.Parse(userInputDelete);

    if (productNumber > 0 && productNumber <= products.Count)
    {
        products.RemoveAt(productNumber - 1); //use removeAt for number
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the name of the new product:");
    string newName = Console.ReadLine();

    Console.WriteLine("Enter the price of the product, format 00.00:");
    string newPrice = Console.ReadLine();
    decimal priceInput = decimal.Parse(newPrice);

    Console.WriteLine("Choose a product type, by number, from the list:");

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title}");
    }
    string newTypeInput = Console.ReadLine();
    int newProductTypeId = int.Parse(newTypeInput);


    Product newProduct = new Product
    {
        Name = newName,
        Price = priceInput,
        ProductTypeId = newProductTypeId
    };


    products.Add(newProduct);

    Console.WriteLine($"Product '{newProduct.Name}' added!");
}


void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Which product would you like to update( select number)?");

    DisplayAllProducts(products, productTypes);

    string updatedInput = Console.ReadLine();
    int number = int.Parse(updatedInput);

    Product productUpdate = products[number - 1];

    Console.WriteLine($"Enter a new name");
    string newName = Console.ReadLine();


    Console.WriteLine($"Enter a new price(format 00.00)");
    string newPrice = Console.ReadLine();
    decimal updatedPrice = decimal.Parse(newPrice);


    Console.WriteLine("Choose a new product type (by number)");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title}");
    }

    string newType = Console.ReadLine();

    productUpdate.Name = newName;
    productUpdate.Price = updatedPrice;
    productUpdate.ProductTypeId = int.Parse(newType);

    Console.WriteLine("Product updated!");
}


// don't move or change this!
public partial class Program { }