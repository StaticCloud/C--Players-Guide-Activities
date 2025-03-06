namespace Program
{
    internal class AsynchronousRandomWords
    {
        private string _word;
        public AsynchronousRandomWords() 
        {
            string input = Console.ReadLine();
            _word = input;
            Task<int> attempts = RandomlyCreateAsync();
            attempts.Wait();
            Console.WriteLine($"It took a total of {attempts.Result} attempts to randomly generate your word!");
        }

        private Task<int> RandomlyCreateAsync()
        {
            return Task.Run(() => RandomlyRecreate());
        }

        private int RandomlyRecreate()
        {
            int attempts = 0;

            while (GenerateWord() == false)
            {
                attempts++;
            }

            return attempts;
        }

        private bool GenerateWord()
        {
            string newWord = "";
            Random random = new Random();

            for (int i = 0; i < _word.Length; i++)
            {
                newWord += (char)('a' + random.Next(26));
            }

            return newWord == _word;
        }
    }
}