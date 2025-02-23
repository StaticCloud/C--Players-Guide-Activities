internal class WarPreparations
{
    public WarPreparations()
    {
        Sword swordA = new Sword(Material.Iron, null, 50, 10);
        Sword swordB = swordA with { gemStone = GemStone.Emerald };
        Sword swordC = swordA with { material = Material.Binarium, length = 60 };
        Console.WriteLine($"{swordA} {swordB} {swordC}");
    }
}

record Sword(Material material, GemStone? gemStone, int length, int width);

enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

enum GemStone
{
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone
}