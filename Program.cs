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
            var s = (ISort) Activator.CreateInstance(t);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            s.Sort(numbers);
            stopwatch.Stop();

            Console.WriteLine("Time elapsed for {0}: {1}", t.Name, stopwatch.Elapsed);
            return Task.FromResult(numbers);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{1,5,1,2,6,4};

            var tasks = new Task<int[]>[] {
                nums.CustomSort(typeof(BubbleSort)),
                nums.CustomSort(typeof(SelectionSort)),
                nums.CustomSort(typeof(InsertionSort))
            };

            var results = Task.WhenAll(tasks);
            
            UserInterface(tasks);
        }

        public static void UserInterface(Task<int[]>[] tasks){

            Console.Write("Choose a type of sorting: \n1) Bubble Sort\n2) Selection Sort\n3) Insertion Sort\n--> ");

            var key = Console.ReadKey().KeyChar;

            if(char.IsDigit(key))
            {
                var index = Int32.Parse(key.ToString().Substring(0,1));

                if(index > 0 && index <= tasks.Length)
                {
                    Console.WriteLine("\nRESULT: {0}", String.Join(',', tasks[index - 1].Result ));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid value... try again.");
                    UserInterface(tasks);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvalid value... try again.");
                UserInterface(tasks);
            }
        }

    }
}
