using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'findMedian' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     Constraints:
        1 <= n <= 1000001
        n is odd
        -10000 <= arr[i] <= 10000
     */

    public static List<int> sortArray(List<int> array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            sortArray(array, leftIndex, j);
        if (i < rightIndex)
            sortArray(array, i, rightIndex);
        return array;
    }
    public static int? findMedian(List<int> arr)
    {
        if (arr.Count == 0 || arr.Count%2==0 || arr.Count>1000001)
            return null;
        
        List<int> sortedArray = sortArray(arr, 0, arr.Count-1);

        if (sortedArray[0] < -10000 || sortedArray[sortedArray.Count - 1] > 10000)
            return null;

        int medianindex = (sortedArray.Count-1)/2;
        return sortedArray[medianindex];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int? result = Result.findMedian(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
