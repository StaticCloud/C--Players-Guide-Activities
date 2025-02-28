namespace Program
{
    internal class CharberryTrees
    {
        public CharberryTrees() 
        {
            CharberryTree tree = new CharberryTree();
            Notifier notifier = new Notifier(tree);
            Harvester harvester = new Harvester(tree);

            while (true) tree.MaybeGrow();
        }
    }

    class CharberryTree
    {
        private Random _random = new Random();
        public bool Ripe { get; set; }
        public Action? Ripened;
        
        public void MaybeGrow()
        {
            if (_random.NextDouble() < 0.00000001 && !Ripe)
            {
                Ripe = true;
                Ripened();
            }
        }
    }

    class Notifier
    {
        public Notifier(CharberryTree tree)
        {
            tree.Ripened += () => Console.WriteLine("A charberry fruit has ripened!");
        }
    }

    class Harvester
    {
        public Harvester(CharberryTree tree) 
        {
            tree.Ripened += () => tree.Ripe = false;
        }
    }
}