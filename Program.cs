using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_sorting_algorithms
{

    public static class SortApplication {
        private static Type Default = typeof(BubbleSort);
        public static Task<int[]> CustomSort(this int[] numbers, Type type = null){
            var t = type ?? Default;
            var s = (CustomSort) Activator.CreateInstance(t);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            switch(t.Name){
                case "QuickSort":
                    s.Sort(numbers, 0, numbers.Length);
                    break;
                default:
                    s.Sort(numbers);
                    break;
            }
            
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", t.Name, stopwatch.Elapsed);
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
            int[] nums = new int[]{1,5,1,2,6,4};

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

                    Console.WriteLine("\nRESULT: {0}\n", String.Join(',', tasks[0].Result ));
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
