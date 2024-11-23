namespace Utils
{
    public static class IntExtension
    {
        public static int[] GetSumPrefixesArray(this int[] array)
        {
            var prefixes = new int[array.Length];
            prefixes[0] = array[0];
            
            for (var i = 1; i < array.Length; i++)
            { 
                prefixes[i] = prefixes[i - 1] + array[i];
            }

            return prefixes;
        }

        public static int GetIndexInRange(this int[] array, int number)
        {
            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (array[mid] == number)
                    return mid;
                
                if (number > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }
}