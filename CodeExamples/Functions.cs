namespace CodeExamples
{
    public enum SortOrder { Ascending, Descending }
    public static class Functions
    {
        public static bool IsSorted(int[] array, SortOrder order)
        {
            bool isSorted = true;
            if (order == SortOrder.Ascending)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        isSorted = false;
                    }
                }
            }
            if (order == SortOrder.Descending)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        isSorted = false;
                    }
                }
            }

            return isSorted;
        }

        public static void Transform(int[] array, SortOrder order)
        {
            if (IsSorted(array, order))
            {
                for (int i = 0; i < array.Length; i++)
                {

                    array[i] = array[i] + i;
                }
            }
        }

        public static double MultArithmeticElements(double a, double t, int n)
        {
            double multiply = 0;
            double[] arr = new double[n];
            if (n > 0)
            {
                arr[0] = a;
                multiply = a;
                for (int i = 0; i < n - 1; i++)
                {
                    arr[i + 1] = arr[i] + t;
                    multiply *= arr[i + 1];
                }
            }
            return multiply;
        }

        public static double SumGeometricElements(double a, double t, double alim)
        {
            double sum = 0;
            if (a > alim)
            {
                double aCurr = a;
                sum = a;
                while (aCurr > alim)
                {
                    aCurr *= t;
                    if (aCurr > alim)
                        sum += aCurr;
                }
            }
            return sum;
        }
    }
}
