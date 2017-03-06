using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //tests for all Basic 13 functions, uncomment any given function to test. Run in debug to test all. Leave first two lines uncommented to populate arguments.
            int[] nums = {1,3,-5,7,-9,2,11}; //arguments for functions that take an array
            int y = 4; //argument for greater_than_y function
            // print_1_255();
            // print_odds_1_255();
            // print_sum();
            // iterate_through_array(nums);
            // find_max(nums);
            // get_average(nums);
            // array_with_odds();
            // greater_than_y(nums, y);
            // square_the_values(nums);
            // eliminate_negatives(nums);
            // min_max_average(nums);
            // shifting_values(nums);
            // number_to_string(nums);
        }
        public static void print_1_255()
        {
            for (var i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void print_odds_1_255()
        {
            for (var i = 1; i < 256; i+=2)
            {
                Console.WriteLine(i);
            }
        }
        public static void print_sum()
        {
            int sum = 0;
            for ( var i = 0; i < 256; i++)
            {
                sum += i;
                Console.WriteLine("New number: "+i+" Sum: "+sum);
            }
        }
        public static void iterate_through_array(int[] arr)
        {
            foreach (var val in arr)
            {
                Console.WriteLine(val);
            }
        }
        public static void find_max(int[] arr)
        {
            int max = arr[0];
            for(var i = 1;i < arr.Length;i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine("Max value in the array is:"+max);
        }
        public static void get_average(int[] arr)
        {
            int sum = arr[0];
            for(var i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            float avg = sum/arr.Length;
            Console.WriteLine("The average of the array is:"+avg);
        }
        public static void array_with_odds()
        {
            int[] oddArr = new int[128];
            int j = 0;
            for(var i = 1; i < 256; i+=2)
            {
                oddArr[j] = i;
                Console.WriteLine(i);
                j++;
            }
            
        }
        public static void greater_than_y(int[] arr, int y)
        {
            int count = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if(arr[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count+" instances in the array greater than "+y);
        }
        public static void square_the_values(int[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i]*arr[i];
                Console.WriteLine(arr[i]);
            }
            
        }
        public static void eliminate_negatives(int[] arr)
        {
            for(var i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
        }
        public static void min_max_average(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            for(var i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                sum += arr[i];
            }
            float avg = sum/arr.Length;
            Console.WriteLine("Max: "+max+" Min: "+min+" Average: "+avg);
        }
        public static void shifting_values(int[] arr)
        {
            for(var i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = 0;
            foreach(var val in arr)
            {
                Console.WriteLine(val);
            }
        }
        public static void number_to_string(int[] arr)
        {
            Object[] newArr = new Object[arr.Length];
            for(var i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    newArr[i] = "Dojo";
                }
                else
                {
                    newArr[i] = arr[i];
                }
            }
            foreach(var val in newArr)
            {
                Console.WriteLine(val);
            }
        }
    }
}
