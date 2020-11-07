using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public partial class Airline
    {
        // поля
        private string destination;
        private readonly int flight_number;
        private string type_of_plane;
        private string depature_time;
        private string day;
        private static int count;
        const int x = 88;
    }

    public partial class Airline
    {
        // конструкторы

        public Airline()
        {
            this.destination = "Berlin";
            this.type_of_plane = "9 - Boeing 737-800";
            this.depature_time = "18:58";
            this.day = "Monday";
            this.flight_number = destination.GetHashCode() + depature_time.GetHashCode();
            if (this.flight_number<0)
            {
                this.flight_number = Math.Abs(this.flight_number);
            }
            count++;
        }

        public Airline(string destination, string type_of_plane, string depature_time, string day)
        {
            this.flight_number = destination.GetHashCode() + depature_time.GetHashCode();
            if (this.flight_number < 0)
            {
                this.flight_number = Math.Abs(this.flight_number);
            }
            this.destination = destination;
            this.type_of_plane = type_of_plane;
            this.depature_time = depature_time;
            this.day = day;
            count++;
        }

        public Airline(string destination, string type_of_plane = "Embraer E-175", string depature_time = "15:00")
        {
            this.flight_number = destination.GetHashCode() + depature_time.GetHashCode();
            if (this.flight_number < 0)
            {
                this.flight_number = Math.Abs(this.flight_number);
            }
            this.destination = destination;
            this.type_of_plane = type_of_plane;
            this.depature_time = depature_time;
            this.day = "Monday";
            count++;
        }

        //private Airplane()
        //{

        //}

        static Airline()
        {
            count = 0;
        }


        //Методы

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Airline temp = (Airline)obj; return (this.destination == temp.destination && this.depature_time == temp.depature_time);
        }


        //Свойство

        public string PlaneType
        {
            get
            {
                return type_of_plane;
            }
            private set
            {
                if (type_of_plane.Length > 50)
                {
                    Console.WriteLine("Incorrect type of plane");
                }
                else
                {
                    type_of_plane = value;
                }
            }
        }


        //Методы
        public static int Info()
        {
            return count;
        }
        public override string ToString()
        {
            return ($"Destination - {destination}, flight number is {flight_number}, type of plane - {type_of_plane}, {depature_time} - depature time on {day}.");
        }



        /////////////////////////////////////////////////////////




        class Program
        {
            static void Main(string[] args)
            {
                // FIRST TASK

                Airline u_one = new Airline();
                Airline u_two = new Airline("Gomel", "CY-24", "3:00", "Tuesday");
                Airline u_three = new Airline("Kiev");

                u_one.PlaneType = u_one.type_of_plane;
                u_two.PlaneType = u_two.type_of_plane;
                u_three.PlaneType = u_three.type_of_plane;

                Console.WriteLine(u_one.Equals(u_three)); // Пример. Сравнение 1-го и 3-го рейса

                string[] cities = { "Minsk", "Berlin", "Kiev", "Odessa", "Tokyo", "Moscow", "Paris", "Barcelona"};

                bool flag = false;
                foreach (string city in cities)
                {
                    if(u_one.destination == city)
                    {
                        Console.WriteLine($"\n{u_one.ToString()}\n================\n");
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("This city is not on the list\n================\n");
                }


                flag = false;
                foreach (string city in cities)
                {
                    if (u_two.destination == city)
                    {
                        Console.WriteLine($"{u_two.ToString()}\n================\n");
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("This city is not on the list\n================\n");
                }


                flag = false;
                foreach (string city in cities)
                {
                    if (u_three.destination == city)
                    {
                        Console.WriteLine($"{u_three.ToString()}\n================\n");
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("This city is not on the list\n================\n");
                }

                Console.WriteLine($"\nFor the 2nd task, {count} flight(s) was(were) taken");

                //SECOND TASK



            }
        }
    }
}
