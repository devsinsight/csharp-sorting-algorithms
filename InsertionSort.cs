namespace csharp_sorting_algorithms
{
    public class InsertionSort : CustomSort
    {
        public override void Sort(int[] numbers)
        {
            int j;
            for(int i = 1; i < numbers.Length; i++){
                j = i;
                while(j>0 && numbers[j-1] > numbers[j]){
                    int temp = numbers[j];
                    numbers[j] = numbers[j - 1];
                    numbers[j - 1] = temp;
                    j--;
                }
            }
        }
    }
}