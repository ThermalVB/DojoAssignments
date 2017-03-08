using System;

namespace ConsoleApplication
{
    //create a class called Human
    public class Human
    {
        //Human attributes
        public String Name;
        public int Strength = 3;
        public int Intelligence = 3;
        public int Dexterity = 3;
        private int _health = 100;
        public int Health {
            get;
            set;
        }

        public Human(String name){
            //basic Human constructor
            name = name;
        }
        public Human(String name, int str, int intel, int dex, int health){
            //overloaded Human constructor for more specific needs
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Health = health;
        }
        public void Attack(Object myTarget){
            //Attack method. If target is human deal damage equal to Strength times 5
            int atkDmg = 5 * Strength;
            Human target = myTarget as Human;
                target.Health -= atkDmg;
        }
    }
}