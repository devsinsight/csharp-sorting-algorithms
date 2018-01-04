namespace csharp_sorting_algorithms
{
    public class SelectionSort : CustomSort
    {
        public override void Sort(int[] numbers)
        {
            for(int k=0; k < numbers.Length - 1; k++){
                int min_index = k;
                for(int j = k + 1; j < numbers.Length; j++ )
                    if(numbers[j] < numbers[min_index])
                        min_index = j;
                    
                int temp = numbers[min_index];
                numbers[min_index] = numbers[k];
                numbers[k] = temp;
            }
        }
    }
}