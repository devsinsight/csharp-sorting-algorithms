namespace csharp_sorting_algorithms
{
    public class SelectionSort : ISort
    {
        public void Sort(int[] numbers)
        {
            for(int k=0; k < numbers.Length - 1; k++){
                int min = k;
                for(int j = k + 1; j < numbers.Length; j++ )
                    if(numbers[j] < numbers[min])
                        min = j;
                    
                int temp = numbers[min];
                numbers[min] = numbers[k];
                numbers[k] = temp;
            }
        }
    }
}