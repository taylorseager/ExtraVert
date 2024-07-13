// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<Plant> plants = new List<Plant>()
{
    new Plant(species: "Hosta", lightNeeds: 1, askingPrice:20.00M, city: "Nashville", zip: 37011, sold: true),
    new Plant(species:"Snake Plant", lightNeeds: 1, askingPrice: 15.99M, city: "Hendersonville", zip: 37075, sold: false),
    new Plant(species: "Zinnia", lightNeeds: 5, askingPrice: 12.99M, city: "Hendersonville", zip: 37075, sold: false),
    new Plant(species: "Stargazer Lily", lightNeeds: 4, askingPrice: 24.99M, city: "Nashville", zip: 37011, sold: true),
    new Plant(species: "Gerbera Daisy", lightNeeds: 4, askingPrice: 5.99M, city: "Hendersonville", zip: 37075, sold: false),
};

Random randomPlant = new Random();

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
                        4. Delist A Plant
                        5. Plant of the Day");
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
        AdoptAPlant();
    }
    else if (choice == "4")
    {
        DelistPlant();
    }
    else if (choice == "5")
    {
        PlantOfTheDay();
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

void ListAllAvailablePlants()
{
    var availablePlants = plants.Where(plant => !plant.Sold).ToList();

    for (int i = 0; i < availablePlants.Count; i++)
    {
        string availability = availablePlants[i].Sold ? "was sold" : "is available";
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species} in {availablePlants[i].City} {availability} for ${availablePlants[i].AskingPrice}");
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

    Plant newPlant = new Plant(species, lightNeeds, askingPrice, city, zip, sold: false);

    plants.Add(newPlant);

    Console.WriteLine($"The plant {newPlant.Species} has been added!");
}

void AdoptAPlant()
{
    Console.WriteLine("Please enter full plant name to adopt:");
    ListAllAvailablePlants();
    string chosenPlant = Console.ReadLine().Trim().ToLower();

    var availablePlants = plants.Where(plant => plant.Species.ToLower() == chosenPlant && !plant.Sold).ToList();

    if (availablePlants.Any())
    {
        for (int i = 0; i < availablePlants.Count; i++)
        {
            Console.WriteLine($"You selected: {availablePlants[i].Species}.");

            availablePlants[i].Sold = true;
            Console.WriteLine($"Plant {availablePlants[i].Species} has been adopted.");
        }
     
    }
    else
    {
        Console.WriteLine($"Your selected plant {chosenPlant} was not found.");
    }

}

void DelistPlant()
{
    Console.WriteLine("Please enter full plant name to delete:");
    ListAllPlants();

    string chosenPlant = Console.ReadLine().Trim().ToLower();

    var availablePlants = plants.Where(plant => plant.Species.ToLower() == chosenPlant && !plant.Sold).ToList();

    if (availablePlants.Any())
    {
        foreach (var plant in availablePlants)
        {
            plants.Remove(plant);
            Console.WriteLine($"{plant.Species} has been removed successfully");
        }
    }
    else
    {
        Console.WriteLine($"Your selected plant {chosenPlant.ToLower()} was not found.");
    }
}

void PlantOfTheDay()
{
    var availablePlants = plants.Where(plant => !plant.Sold).ToList();


    if (availablePlants.Any())
    {
        int randomInteger = randomPlant.Next(availablePlants.Count());
        {
            Plant plantOfTheDay = availablePlants[randomInteger];
            Console.WriteLine($"{plantOfTheDay.Species} in {plantOfTheDay.City}, requires light needs of {plantOfTheDay.LightNeeds} and is ${plantOfTheDay.AskingPrice}");
        }

    }
}
