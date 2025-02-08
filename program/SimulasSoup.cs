internal class SimulasSoup
{
    enum Type
    {
        soup,
        stew,
        gumbo
    }

    enum Main
    {
        mushroom,
        chicken,
        carrot,
        potato
    }

    enum Seasoning
    {
        spicy,
        salty,
        sweet
    }

    public SimulasSoup() 
    {
        (Type type, Main main, Seasoning seasoning) food = (Type.soup, Main.mushroom, Seasoning.spicy);
        string input = "";

        // Warning: redundancy ahead (keeping it this way for learning purposes)
        while (input != "soup" && input != "stew" && input != "gumbo")
        {
            Console.Write("What kind of food would you like (gumbo, stew, soup)?: ");
            input = Console.ReadLine().ToLower();
        }

        food.type = input == "soup" ? Type.soup : (input == "stew" ? Type.stew : Type.gumbo);

        while (input != "mushrooms" && input != "chicken" && input != "carrots" && input != "potatoes")
        {
            Console.Write("What would you like the main ingredient to be (mushrooms, chicken, carrots, potatoes)?: ");
            input = Console.ReadLine().ToLower();
        }

        food.main = input == "mushrooms" ? Main.mushroom : (input == "chicken" ? Main.chicken : (input == "carrots" ? Main.carrot : Main.potato));

        while (input != "spicy" && input != "salty" && input != "sweet")
        {
            Console.Write("What kind of seasoning would you like (spicy, salty, sweet)?: ");
            input = Console.ReadLine().ToLower();
        }

        food.seasoning = input == "spicy" ? Seasoning.spicy : (input == "salty" ? Seasoning.salty : Seasoning.sweet);

        Console.WriteLine($"{food.seasoning} {food.main} {food.type}");
    }
}