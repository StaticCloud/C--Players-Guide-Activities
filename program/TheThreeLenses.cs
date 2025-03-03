namespace Program
{
    internal class TheThreeLenses
    {
        public TheThreeLenses() 
        {
            int[] nums = [1, 9, 2, 8, 3, 7, 4, 6, 5];

            Display(SortNums(nums));
            Console.WriteLine("");
            Display(EvenNums(nums));
            Console.WriteLine("");
            Display(DoubleNums(nums));
        }
        private IEnumerable<int> SortNums(int[] nums)
        {
            Array.Sort(nums);
            return nums;
        }

        private IEnumerable<int> EvenNums(int[] nums)
        {
            return from i in nums
                   where i % 2 == 0
                   select i;
        }

        private IEnumerable<int> DoubleNums(int[] nums) 
        { 
            return nums.Select(i => i * 2);
        }

        private void Display(IEnumerable<int> nums)
        {
            foreach (int i in nums)
            {
                Console.Write($"{i} ");
            }
        }
    }
}