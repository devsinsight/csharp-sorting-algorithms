using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_sorting_algorithms
{

    public static class SortApplication {
        public static Task<int[]> CustomSort(this int[] numbers, Type type){
            var s = (CustomSort) Activator.CreateInstance(type);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            switch(type.Name){
                case "QuickSort":
                    s.Sort(numbers, 0, numbers.Length);
                    break;
                default:
                    s.Sort(numbers);
                    break;
            }
            
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", type.Name, stopwatch.Elapsed);
            return Task.FromResult(numbers);
        }
    }
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
            int[] nums = new int[20]; 

            Random randNum = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = randNum.Next(1, 20);
            }

            UserInterface(nums);
        }

        private static Task<int[]>[] GetSortTypes(int[] nums){
            return new Task<int[]>[] {
                nums.CustomSort(typeof(BubbleSort)),
                nums.CustomSort(typeof(SelectionSort)),
                nums.CustomSort(typeof(InsertionSort)),
                nums.CustomSort(typeof(QuickSort))
            };
        }

        private static Task<int[]>[] RunAllSort(int[] nums){
            return GetSortTypes(nums);
        }

        private static Task<int[]>[] RunSort(int[] nums, int selectedType){
            return new Task<int[]>[]{ nums.CustomSort(SortTypes[selectedType]) };
        }

        private static Task<int[]>[] Run(int[] nums, int selectedType){
            return selectedType > 4 ? RunAllSort(nums) : RunSort(nums, selectedType);

        }

        private static void UserInterface(int[] nums){
            Console.Write($"Choose a type of sorting: \n1) Bubble Sort\n2) Selection Sort\n3) Insertion Sort\n4) Quick Sort\n5) Run All\n-->");

            var key = Console.ReadKey().KeyChar;

            if(char.IsDigit(key))
            {
                var selectedType = Int32.Parse(key.ToString().Substring(0,1));

                if(selectedType > 0 && selectedType <= 5)
                {
                    Console.Clear();

                    var tasks = Run(nums, selectedType);

                    Task.WhenAll(tasks);

                    Console.WriteLine("\nSorted: {0}\n", String.Join(',', tasks[0].Result ));
                    UserInterface(nums);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid Option... Try Again.");
                    UserInterface(nums);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvalid Option... Try Again.");
                UserInterface(nums);
            }
        }

    }
}
