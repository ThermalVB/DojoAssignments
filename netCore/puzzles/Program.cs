using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        //test function for the following assignment functions from 'Puzzles'
        //uncomment to test functions, use the declared variables as arguments for the functions that require them
        {
            int num = 10;
            String[] namesArr = new String[5] {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            //random_array();
            //tossCoin(rand);
            tossMultipleCoins(num);
            //names(namesArr);
        }
        public static void random_array()
        //create a randomized array of 10 integer values between 5,25
        {
            //create a new random seed object
            Random newRand = new Random();
            //create a new array to populate
            int[] newArr = new int[10];
            //set max to the minimum possible randomized number
            int max = 5;
            //set min to the maximum possible randomized number
            int min = 25;
            //start sum at 0
            float sum = 0;
            //iterate through the array indices and assign randomized integers using the .Next method
            for(var i = 0; i < 10; i++)
            {
                newArr[i] = newRand.Next(5,26);
                //check for max
                if (newArr[i] > max)
                {
                    max = newArr[i];
                }
                //check for min
                if (newArr[i] < min)
                {
                    min = newArr[i];
                }
                //add to sum
                sum += newArr[i];
                //print each to console
                Console.WriteLine(newArr[i]);
            }
            //print all values
            Console.WriteLine("Max: "+max+" Min: "+min+" Sum: "+sum);
        }
        public static int tossCoin()
        //simulate rolling a d2
        {
            //create a new random seed object
            Random rand = new Random();
            //arbitrarily assigned heads to even numbers, tails to odd. 
            int seed = rand.Next(100);
            Console.WriteLine("Tossing a coin!");
            //test print to debug seed
            Console.WriteLine(seed);
            //prints and returns a binary value to use in the tossMultipleCoins function
            if(seed % 2 == 0)
            //heads
            {
                Console.WriteLine("Heads");
                return 1;
            }
            else
            //tails
            {
                Console.WriteLine("Tails");
                return 0;
            }
        }
        public static double tossMultipleCoins(int num)
        //call the tossCoin function 'num' times and return the ratio of heads:tails as a double
        {
            //declare variables being tracked
            float heads = 0;
            float tails = 0;
            double ratio = 0;
            //for loop calls tosscoin(rand) 'num' times
            for(var i = 0; i < num; i++)
            {
                //create an intentionally significant time waste to make the for loop wait
                //long enough to let system clock catch up
                for(var j = 0; j < 5000000; j ++){}
                //declare a variable within the for loop scope to use for each toss
                //each toss will also log the toss to the console
                int toss = tossCoin();
                if(toss == 1)
                {
                    heads++;
                }
                else{
                    tails++;
                }
            }
            //set the ratio variable
            if (tails > 0)
            {
                ratio = heads/tails;
            }
            else{
                ratio = 1;
            }
            //print the info
            Console.WriteLine("Heads: "+heads+" Tails: "+tails);
            Console.WriteLine("Ratio of heads : tails is: "+ratio);
            //return the double ratio
            return ratio;
        }
        public static String[] names(String[] names)
        //function that shuffles the location of elements within an array, returns an array of all elements longer than 4 characters
        {
            //create a new Random object
            Random rand = new Random();
            //for list that iterates through each index and randomly swaps its element with another location's element
            for(var i = 0; i < names.Length - 1; i++)
            {
                //choose a random index
                int randInd = rand.Next(i + 1, names.Length - 1);
                //hold the string in the current index
                string temp = names[i];
                //swap locations of both elements
                names[i] = names[randInd];
                names[randInd] = temp;
                //print to check functionality
                Console.WriteLine(names[i]);
            }
            //print the last element
            Console.WriteLine(names[names.Length - 1]);
            //create a new list for the return array
            List<string> nameList = new List<string>();
            //iterate through each item, check if it is longer than 4 chars
            foreach(var name in names)
            {
                if (name.Length > 4)
                {
                    nameList.Add(name);
                }
            }
            //change the list back to an array and return it
            return nameList.ToArray();
        }
    }
}
