// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<Plant> plants = new List<Plant>()
{
    new Plant(species: "Hosta", lightNeeds: 1, askingPrice:20.00M, city: "Nashville", zip: 37011),
    new Plant(species:"Snake Plant", lightNeeds: 1, askingPrice: 15.99M, city: "Hendersonville", zip: 37075),
    new Plant(species: "Zinnia", lightNeeds: 5, askingPrice: 12.99M, city: "Hendersonville", zip: 37075),
    new Plant(species: "Stargazer Lily", lightNeeds: 4, askingPrice: 24.99M, city: "Nashville", zip: 37011),
    new Plant(species: "Gerbera Daisy", lightNeeds: 4, askingPrice: 5.99M, city: "Hendersonville", zip: 37075),
};

string greeting = @"Welcome to the Jungle
A plant store for everyone!";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Plants
                        2. Post A Plant To Be Adopted
                        3. Adopt A Plant
                        4. Delist A Plant");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Come back again soon!");
    }
    else if (choice == "1")
    {
        ListAllPlants();
    }
    else if (choice == "2")
    {
        NewPlant();
    }
    else if (choice == "3")
    {
        throw new NotImplementedException("Adopt A Plant");
    }
    else if (choice == "4")
    {
        throw new NotImplementedException("Delist A Plant");
    }
};

Plant chosenProduct = null;

while (chosenProduct == null)
{
    Console.WriteLine("Please enter a species number: ");
    try
    {
        int response = int.Parse(Console.ReadLine().Trim());
        chosenProduct = plants[response - 1];
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Try again! You missed something");
    }
}

void ListAllPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        string availability = plants[i].Sold ? "was sold" : "is available";
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {availability} for ${plants[i].AskingPrice}");
    }
}

void NewPlant()
{
    Console.WriteLine("Enter the details for the new plant:");
    Console.WriteLine("Species: ");
    string? species = Console.ReadLine().Trim();

    Console.WriteLine("Light Needs (1 = shade, 5 = sun): ");
    double lightNeeds;
    while (!double.TryParse(Console.ReadLine().Trim(), out lightNeeds));

    Console.WriteLine("Asking Price: ");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine().Trim(), out askingPrice));
  
        Console.WriteLine("City: ");
    string? city = Console.ReadLine().Trim();

    Console.WriteLine("Zipcode: ");
    int zip;
    while (!int.TryParse(Console.ReadLine().Trim(), out zip)) ;

    Plant newPlant = new Plant(species, lightNeeds, askingPrice, city, zip);

    plants.Add(newPlant);

    Console.WriteLine($"The plant {newPlant.Species} has been added!");}