using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace csharp_sorting_algorithms
{
    public static class SortApplication {
        public static Task<int[]> CustomSort(this int[] numbers, Type type){
            var s = (CustomSort) Activator.CreateInstance(type);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            switch(type.Name){
                case "MergeSort":
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
}