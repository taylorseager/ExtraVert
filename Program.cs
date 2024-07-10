// See https://aka.ms/new-console-template for more information
using ExtraVert;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Hosta",
        LightNeeds = 1,
        AskingPrice = 20.00M,
        City = "Nashville",
        Zip = 37011,
        Sold = false
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 1.5,
        AskingPrice = 15.99M,
        City = "Hendersonville",
        Zip = 37075,
        Sold = true
    },
    new Plant()
    {
        Species = "Zinnia",
        LightNeeds = 5,
        AskingPrice = 12.99M,
        City = "Hendersonville",
        Zip = 37075,
        Sold = false
    },
    new Plant()
    {
        Species = "Stargazer Lily",
        LightNeeds = 4,
        AskingPrice = 24.99M,
        City = "Nashville",
        Zip = 37011,
        Sold = true
    },
    new Plant()
    {
        Species = "Gerbera Daisy",
        LightNeeds = 4,
        AskingPrice = 5.99M,
        City = "Hendersonville",
        Zip = 37075,
        Sold = false
    },
};

string greeting = @"Welcome to the Jungle
A plant store for everyone!";

Console.WriteLine(greeting);

Console.WriteLine("Plants:");
for (int i = 0; i < plants.Count; i++)
{
    Console.WriteLine($"{i + 1}. {plants[i].Species}");
}