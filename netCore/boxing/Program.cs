using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //new object list
            List<Object> objList = new List<Object>();
            //adding stuff per assignment instructions
            objList.Add(7);
            objList.Add(28);
            objList.Add(-1);
            objList.Add(true);
            objList.Add("chair");

            foreach (var val in objList)
            {
                Console.WriteLine(val);
            }
            int sum = 0;
            foreach (var num in objList)
            {
                if (num is int)
                {
                    sum += (int)num;
                }   
            }
            Console.WriteLine(sum);
        }
    }
}
