using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Three basic arrays
            // int[] basicArr1 = {0,1,2,3,4,5,6,7,8,9};

            // string[] basicArr2;
            // basicArr2 = new string[] {"Tim", "Martin","Nikki","Sara"};

            // Boolean[] basicArr3 = new Boolean[10];
            // for (int i = 0; i < 10; i+=2)
            // {
            //     basicArr3[i] = true;
            //     basicArr3[i+1] = false;
            // }

            //Multiplication table
            int[,] mult = new int[10,10];
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    mult[x, y] = (x + 1) * (y + 1);
                }
            }

            //Following code displays the multiplication table
            for(int x = 0; x < 10; x++)
            {
                string display = "[ ";
                for(int y = 0; y < 10; y++)
                {
                    display += mult[x, y] + ", ";
                    //Add an extra space for single digit values
                    if(mult[x,y] < 10)
                    {
                        display += " ";
                    }
                }
                display += "]";
                Console.WriteLine(display);
            }

            //List of Ice Cream Flavors
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Rocky Road");
            flavors.Add("Cookie Dough");
            flavors.Add("Neopolotan");
            flavors.Add("Rainbow Sherbet");

            //Output the length of the List
            Console.WriteLine(flavors.Count);

            //Print the 3rd value then remove it
            Console.WriteLine("The third flavor in the list is: " + flavors[2]);
            flavors.RemoveAt(2);

            //Output the updated length of the List of flavors
            Console.WriteLine(flavors.Count);
            

            //User Dictionary Construction
            Dictionary<string, string> userInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in nameArray)
            {
                userInfo[name] = flavors[rand.Next(flavors.Count)];
            }

            //Looping through info Dictionary
            Console.WriteLine("Users and their favor ice cream flavors:");
            foreach(KeyValuePair<string, string> info in userInfo)
            {
                Console.WriteLine(info.Key + " - " + info.Value);
            }
        }
    }
}
