namespace Program
{
    internal class ThePotionMastersOfPattern
    {
        public ThePotionMastersOfPattern()
        {
            new Main().Run();
        }
    }

    class Main
    {
        private Potion _potion;

        public Main()
        {
            _potion = Potion.water;
        }

        public void Run() 
        {
            bool complete = false;

            while (complete == false)
            {
                DisplayInfo();
                GetIngredientChoice();

                complete = CompletePotion();
            }
        }

        private void DisplayInfo()
        {
            if (_potion == Potion.ruined)
            {
                Console.WriteLine("Your potion has been ruined! You will be given a new water potion.");
                _potion = Potion.water;
            }
            
            Console.WriteLine($@"You currently possess a {_potion} potion.

Select an ingredient to mix with your current potion.
1. Stardust
2. Snake Venom
3. Dragon Breath
4. Shadow Glass
5. Eyeshine
");
        }

        private void GetIngredientChoice()
        {
            string choice = Console.ReadLine().ToLower();

            Ingredient ingredient = choice switch
            {
                "stardust" => Ingredient.stardust,
                "snake venom" => Ingredient.snakeVenom,
                "dragon breath" => Ingredient.dragonBreath,
                "shadow glass" => Ingredient.shadowGlass,
                "eyeshine" => Ingredient.eyeshine,
                _ => Ingredient.stardust
            };

            CreateNewPotion(ingredient);
        }

        private void CreateNewPotion(Ingredient ingredient)
        {
            _potion = (_potion, ingredient) switch
            {
                (Potion.water, Ingredient.stardust) => Potion.elixir,
                (Potion.elixir, Ingredient.snakeVenom) => Potion.poison,
                (Potion.elixir, Ingredient.dragonBreath) => Potion.flying,
                (Potion.elixir, Ingredient.shadowGlass) => Potion.invisibility,
                (Potion.elixir, Ingredient.eyeshine) => Potion.nightSight,
                (Potion.nightSight, Ingredient.shadowGlass) => Potion.cloudy,
                (Potion.invisibility, Ingredient.eyeshine) => Potion.cloudy,
                (Potion.cloudy, Ingredient.stardust) => Potion.wraith,
                _ => Potion.ruined
            };
        }

        private bool CompletePotion()
        {
            Console.Write("Are you finished creating your potion (Y/N)?: ");
            string input = Console.ReadLine().ToLower();

            return input switch
            {
                "y" => true,
                "n" => false,
                _ => false
            };
        }
    }
}

enum Potion { water, elixir, poison, flying, invisibility, nightSight, cloudy, wraith, ruined }
enum Ingredient { stardust, snakeVenom, dragonBreath, shadowGlass, eyeshine }