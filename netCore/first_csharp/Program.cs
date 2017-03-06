using System;

namespace ConsoleApplication
{
    public class Program
    // Fundamentals 1 assignment. Simple C# problems
    {
        public static void Main(string[] args)
        {
            // loop 1 - 255
            // for (int i = 1; i < 256; i++)
            // {
            //     Console.WriteLine(i);
            // }
        
            //loop 1 - 100 fizzbuzz style (3 & 5) numbers only
            for (int i = 1; i < 101; i++){
                if (i % 3 == 0 || i % 5 == 0)
                {
                    if (i % 15 != 0){
                        Console.WriteLine(i);
                    }
                }
            }

            //loop 1 - 100 fizzbuzz style (3 & 5) with 'fizz' and 'buzz'
            // for (int i = 1; i < 101; i++){
            //     if (i % 3 == 0 && i % 5 != 0){
            //         Console.WriteLine("fizz");
            //     }
            //     if (i % 5 == 0 && i % 3 != 0){
            //         Console.WriteLine("buzz");
            //     }
            //     if (i % 3 == 0 && i % 5 == 0){
            //         Console.WriteLine("fizzbuzz");
            //     }
            // }

        }
    }
}
