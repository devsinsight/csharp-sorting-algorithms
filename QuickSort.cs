using System;

namespace csharp_sorting_algorithms
{
    public class QuickSort : CustomSort
    {
        public override void Sort(int[] numbers, int left, int right){
            int l = left;
            int r = right - 1;
            int size = right - left;
            if(size > 1){
                Random rand = new Random();
                int pivot = numbers[rand.Next(0, size) + l];
                while(l < r){
                    while(numbers[r] > pivot && r > l){
                        r--;
                    }
                    while(numbers[l] < pivot && l <= r){
                        l++;
                    }
                     if(l < r){
                         int temp = numbers[l];
                         numbers[l] = numbers[r];
                         numbers[r] = temp;
                         l++;
                     }
                }

                Sort(numbers, left, l);
                Sort(numbers, r, right);
            }
        }
    }
}