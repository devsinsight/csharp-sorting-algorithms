using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_sorting_algorithms
{

    public static class Utils {
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


            //Console.WriteLine(String.Join(',', tasks[2].Result ));
        }

    }
}
