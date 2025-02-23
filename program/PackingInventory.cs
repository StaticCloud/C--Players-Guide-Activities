//internal class PackingInventory
//{
//    string input;
//    bool success;
//    Pack pack;
//    InventoryItem item;

//    public PackingInventory()
//    {
//        pack = new Pack(10, 10, 10);

//        while (true)
//        {
//            Console.WriteLine(pack.ToString());
//            Console.Write("Please select an item to add to your inventory (arrow, bow, rope, water, food, sword): ");
//            input = Console.ReadLine().ToLower();

//            item = input switch
//            {
//                "arrow" => new Arrow(),
//                "bow" => new Bow(),
//                "rope" => new Rope(),
//                "water" => new Water(),
//                "food" => new Food(),
//                "sword" => new Sword()
//            };

//            success = pack.Add(item);

//            if (!success) Console.WriteLine("Failed to add item!");
//        }
//    }
//}

//abstract class InventoryItem
//{
//    public double Weight { get; }
//    public double Volume { get; }

//    public abstract override string ToString();

//    public InventoryItem(double weight, double volume)
//    {
//        Weight = weight;
//        Volume = volume;
//    }
//}

//class Arrow : InventoryItem
//{
//    public Arrow() : base(0.1, 0.05) { }
//    public override string ToString() => "Arrow";
//}

//class Bow : InventoryItem
//{
//    public Bow() : base(1, 4) { }
//    public override string ToString() => "Bow";
//}

//class Rope : InventoryItem
//{
//    public Rope() : base(1, 1.5) { }
//    public override string ToString() => "Rope";
//}

//class Water : InventoryItem
//{
//    public Water() : base(2, 3) { }
//    public override string ToString() => "Water";
//}

//class Food : InventoryItem
//{
//    public Food() : base(1, 0.5) { }
//    public override string ToString() => "Food";
//}

//class Sword : InventoryItem
//{
//    public Sword() : base(5, 3) { }
//    public override string ToString() => "Sword";
//}

//class Pack
//{
//    private int _weightCapacity { get; }
//    private int _volumeCapacity { get; }
//    private int _totalItems { get; }

//    private InventoryItem[] items { get; }

//    public Pack(int weightCapacity, int volumeCapacity, int totalItems) 
//    { 
//        _weightCapacity = weightCapacity;
//        _volumeCapacity = volumeCapacity;
//        _totalItems = totalItems;

//        items = new InventoryItem[_totalItems];
//    }

//    public override string ToString()
//    {
//        string output = "Pack containing:";

//        foreach(InventoryItem item in  items)
//        {
//            output += $" {item.ToString()}";
//        }

//        return output;
//    }

//    public bool Add(InventoryItem item)
//    {
//        if (GetVolume() > _volumeCapacity || GetWeight() > _weightCapacity || GetItemCount() == _totalItems) return false;

//        items.Append(item);

//        return true;
//    }

//    public double GetWeight()
//    {
//        double sum = 0;

//        foreach (InventoryItem item in items)
//        { 
//            sum += item.Weight;
//        }

//        return sum;
//    }

//    public double GetVolume()
//    {
//        double sum = 0;

//        foreach (InventoryItem item in items)
//        {
//            sum += item.Volume;
//        }

//        return sum;
//    }

//    public int GetItemCount() => items.Length;
//}