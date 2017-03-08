using System;
using DbConnection;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        //main program runs read and create functions
        {
            
            //Placed inside the code block where you want to query the database
            //DbConnector.Query("Some query string expecting data returned");
            //or
            //DbConnector.Execute("Some query with no expected return");
            //to read from Console
            //string InputLine = Console.ReadLine();

            Read();
            Create();

        }
        public static void Read(){
            //read function unpacks the list of dictionaries created by DbConnector.Query and prints key value pairs
            foreach(var val in DbConnector.Query("SELECT * FROM users;")){
                foreach (var item in val){
                    Console.WriteLine("Key: {0} Value: {1}", item.Key, item.Value);
                }
            }
        }
        public static void Create(){
            //create function requests data to populate database fields and uses try catch blocks to handle exceptions(functionality not yet implemented)
            string[] InputNameSplit;
            string favorite_num;
            Console.WriteLine("Enter a user name (first_name last_name) to create a new user");
            string InputName = Console.ReadLine();
            try{
                InputNameSplit = InputName.Split(new char[] { ' ' });
            }
            catch (System.Exception){
                Console.WriteLine("Please enter a first and last name seperated by a space");
                throw;
            }
            try{
                Console.WriteLine("Enter the user's favorite number");
                favorite_num = Console.ReadLine();
            }
            catch (System.Exception){
                Console.WriteLine("Please enter a number");
                throw;
            }
            try
            {
                DbConnector.Execute("INSERT INTO users (first_name,last_name,favorite_number,created_at,updated_at) VALUES ("+"\""+InputNameSplit[0]+"\",\""+InputNameSplit[1]+"\","+favorite_num+",now(),now())");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                Console.WriteLine("SQL syntax problems");
                throw;
            }
            Read();
            }
        }
    }
