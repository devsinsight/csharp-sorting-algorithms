using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_sorting_algorithms
{

    public static class Utils {
        private static Type Default = typeof(BubbleSort);
        public static int[] CustomSort(this int[] numbers, Type type = null){
             var s = (ISort) Activator.CreateInstance(type ?? Default);
             s.Sort(numbers);
             return numbers;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{1,5,1,2,6,4};

            var sortedNumbers = nums.CustomSort(typeof(SelectionSort));

            Console.WriteLine(String.Join(',', sortedNumbers));
        }

        

    }
}
