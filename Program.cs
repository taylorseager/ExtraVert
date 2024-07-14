// See https://aka.ms/new-console-template for more information
using System.Numerics;

List<Plant> plants = new List<Plant>()
{
    new Plant(species: "Hosta", lightNeeds: 5, askingPrice:20.00M, city: "Nashville", zip: 37011, sold: true, availableUntil: new DateTime(2024, 08, 12)),
    new Plant(species:"Snake Plant", lightNeeds: 3, askingPrice: 15.99M, city: "Hendersonville", zip: 37075, sold: false, availableUntil: new DateTime(2024, 07, 12)),
    new Plant(species: "Zinnia", lightNeeds: 2, askingPrice: 12.99M, city: "Hendersonville", zip: 37075, sold: false, availableUntil: new DateTime(2024, 08, 12)),
    new Plant(species: "Stargazer Lily", lightNeeds: 4, askingPrice: 24.99M, city: "Nashville", zip: 37011, sold: true, availableUntil: new DateTime(2024, 05, 12)),
    new Plant(species: "Gerbera Daisy", lightNeeds: 1, askingPrice: 5.99M, city: "Hendersonville", zip: 37075, sold: false, availableUntil: new DateTime(2024, 08, 12)),
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
                        5. Plant of the Day
                        6. Search for Plants by Light Needs
                        7. View Statistics");

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
    else if (choice == "6")
    {
        SearchByLightNeeds();
    }
    else if (choice == "7")
    {
        AppStatistics();
    }
    else
    {
        Console.WriteLine("Invalid Choice. Try again!");
    }
}

Plant chosenProduct = null;

if (choice != "0")
{
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
}

void ListAllPlants()
{
    foreach (var plant in plants)
    {
        string availability = plant.Sold ? "was sold" : "is available";
        Console.WriteLine($"{PlantDetails(plant)}. It {availability}. Post available until: {plant.AvailableUntil}");
    }
}

void ListAllAvailablePlants()
{
    DateTime now = DateTime.Now;

    var availablePlants = plants.Where(plant => !plant.Sold && plant.AvailableUntil > now).ToList();

    foreach (var plant in plants)
    {
        string availability = plant.Sold ? "was sold" : "is available";
        Console.WriteLine($"{PlantDetails(plant)}. It {availability}.");
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


    Console.WriteLine("Enter Year, Month, Day, your post will expire (YYYY-MM-DD): ");
    DateTime availableUntil;
    while (DateTime.TryParse(Console.ReadLine(), out availableUntil)) ;


    Plant newPlant = new Plant(species, lightNeeds, askingPrice, city, zip, sold: false, availableUntil);

    plants.Add(newPlant);

    Console.WriteLine($"The plant {newPlant.Species} has been added!");
}

void AdoptAPlant()
{
    DateTime now = DateTime.Now;

    Console.WriteLine("Please enter full plant name to adopt:");
    ListAllAvailablePlants();
    string chosenPlant = Console.ReadLine().Trim().ToLower();

    var availablePlants = plants.Where(plant => plant.Species.ToLower() == chosenPlant && !plant.Sold && plant.AvailableUntil > now).ToList();

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

void SearchByLightNeeds()
{
    Console.WriteLine("Please enter a whole number between 1 and 5");

    
    int chosenNumber;
    while (!int.TryParse(Console.ReadLine().Trim(), out chosenNumber))
    {
        Console.WriteLine("Wrong. Try again. Please enter a whole number between 1 and 5:");
    }

    List<Plant> matchedPlants = new List<Plant>();

    foreach (var plant in plants)
        {
            if (plant.LightNeeds <= chosenNumber)
            {
                matchedPlants.Add(plant);
            }
        }
    if (matchedPlants.Any())
    {
        Console.WriteLine($"Here are the plants with light needs of {chosenNumber} or lower: ");
        foreach (var matchedPlant in matchedPlants)
        {
            Console.WriteLine($"{matchedPlant.Species} with light need: {matchedPlant.LightNeeds}.");
        }
    }
    else
    {
        Console.WriteLine($"No plants found with light needs of {chosenNumber} or lower.");
    }
}

void AppStatistics()
{
    Console.WriteLine("Application Stats:");

    // LOWEST PRICED PLANT
    // decimal.MaxValue = largest value a decimal can hold
    decimal lowestPrice = decimal.MaxValue;
    Plant cheapestPlant = null;

    foreach (var plant in plants)
    {
        if (plant.AskingPrice < lowestPrice)
        {
            lowestPrice = (decimal)plant.AskingPrice;
            cheapestPlant = plant;
        }
    }

    if (cheapestPlant != null)
    {
        Console.WriteLine($"The cheapest plant is {PlantDetails(cheapestPlant)}.");
    }
    else
    {
        Console.WriteLine("No plants found in the list.");
    }

    // NUMBER OF AVAILABLE PLANTS:
    // have to set variable to 0
    int totalAvailablePlants = 0;

    // loop through list, then check if a plant is not sold, increment count for each plant that isn't sold
    foreach (var plant in plants)
    {
        if (!plant.Sold)
        {
            totalAvailablePlants++;
        }
    }
    Console.WriteLine($"Total number of available plants: {totalAvailablePlants}.");


    // HIGHEST LIGHT NEEDS
    double highestLight = double.MinValue;
    Plant sunnyPlant = null;

    foreach (var plant in plants)
    {
        if (plant.LightNeeds > highestLight)
        {
            highestLight = (double)plant.LightNeeds;
            sunnyPlant = plant;
        }
    }

    if (sunnyPlant != null)
    {
        Console.WriteLine($"The plant that has the highest light need is {sunnyPlant.Species} in {sunnyPlant.City} with a light need of {sunnyPlant.LightNeeds}.");
    }
    else
    {
        Console.WriteLine("No plants found in the list.");
    }

    // AVERAGE LIGHT NEEDS
    int sizeofPlants = plants.Count;
    int[] lightNeeds = new int[plants.Count];

    float avgLightNeeds = 0.0f;

    for (int i = 0; i < plants.Count; i++)
    {
        lightNeeds[i] = (int)plants[i].LightNeeds;
        avgLightNeeds += lightNeeds[i];
    }

    float sizeOfPlants = plants.Count;
    avgLightNeeds = avgLightNeeds / sizeOfPlants;

    Console.WriteLine($"Average light needs of all plants: {avgLightNeeds}");


    // PERCENTAGE OF PLANTS ADOPTED
    int plantsTotal = plants.Count;
    int plantsAdopted = plants.Count(plant => plant.Sold);

    // sets percentAdopted to 0; has to have f behind it to tell C# it's a float
    float percentAdopted = 0.0f;

    if (plantsTotal > 0)
    {
        percentAdopted = ((float)plantsAdopted / plantsTotal) * 100;
    }


    Console.WriteLine($"The % of plants adopted is: {percentAdopted}%.");
}

string PlantDetails(Plant plant)
{
    return $"{plant.Species} in {plant.City} for ${plant.AskingPrice}";
}