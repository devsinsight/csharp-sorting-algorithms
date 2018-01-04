namespace csharp_sorting_algorithms
{
    public class BubbleSort : CustomSort
    {
        public override void Sort(int[] numbers){
            bool swapped;

            for(int i = 0; i < numbers.Length - 1; i++){
                swapped = false;
                for(int j=0; j < numbers.Length - i - 1; j++){

                    if(numbers[j] > numbers[j + 1]){
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }
                if(!swapped) break;
            }
        }

        
    }
}