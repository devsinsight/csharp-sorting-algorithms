using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_sorting_algorithms
{
    class Program
    {
        private static Dictionary<int, Type> SortTypes = 
            new Dictionary<int, Type>(){
                { 1, typeof(BubbleSort) },
                { 2, typeof(SelectionSort) },
                { 3, typeof(InsertionSort) },
                { 4, typeof(QuickSort) }
            };
        static void Main(string[] args)
        {
            SortMenuApplication(GetRandomNumbers());
        }

        private static int[] GetRandomNumbers(){
            int[] nums = new int[20]; 

            Random randNum = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = randNum.Next(1, 20);
            }
            return nums;
        }

        private static Task<int[]>[] ExecuteAllSort(int[] nums){
            return new Task<int[]>[] {
                nums.CustomSort(typeof(BubbleSort)),
                nums.CustomSort(typeof(SelectionSort)),
                nums.CustomSort(typeof(InsertionSort)),
                nums.CustomSort(typeof(QuickSort))
            };
        }

        private static Task<int[]>[] ExecuteSingleSort(int[] nums, int option){
            return new Task<int[]>[]{ nums.CustomSort(SortTypes[option]) };
        }

        private static Task<int[][]> Execute(int[] nums, int option){
            return Task.WhenAll(option > 4 ? ExecuteAllSort(nums) : ExecuteSingleSort(nums, option));
        }

        private static void SortMenuApplication(int[] nums){
            PrintMenuOptions();

            var option = GetKeyFromConsole();

            if(option > 0 && option <= 5)
            {
                Console.Clear();
                PrintSuccessResult(GetResult(Execute(nums, option)));
                SortMenuApplication(nums);
            }
            else
            {
                PrintInvalidOption(nums);
                SortMenuApplication(nums);
            }
        }

        private static void PrintMenuOptions(){
            Console.Write($"Choose a type of sorting:" +
                            "\n1) Bubble Sort" +
                            "\n2) Selection Sort" +
                            "\n3) Insertion Sort" +
                            "\n4) Quick Sort" +
                            "\n5) Run All\n-->");
        }

        private static int GetKeyFromConsole(){
            var key = Console.ReadKey().KeyChar;
            return char.IsDigit(key) ? Int32.Parse(key.ToString().Substring(0,1)) : 0;
        }

        private static void PrintInvalidOption(int[] nums){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Option... Try Again.");
            Console.ResetColor();
        }

        private static void PrintSuccessResult(int[] result){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sorted: {0}\n", String.Join(',', result ));
            Console.ResetColor();
        }

        private static int[] GetResult(Task<int[][]> tasks){
            return tasks.Result.Last();
        }

    }
}
