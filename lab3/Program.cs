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
            count++;
        }

        public Airline(string destination, string type_of_plane, string depature_time, string day)
        {
            this.flight_number = destination.GetHashCode() + depature_time.GetHashCode();
            this.destination = destination;
            this.type_of_plane = type_of_plane;
            this.depature_time = depature_time;
            this.day = day;
            count++;
        }

        public Airline(string destination, string type_of_plane = "Embraer E-175", string depature_time = "15:00")
        {
            this.flight_number = destination.GetHashCode() + depature_time.GetHashCode();
            this.destination = destination;
            this.type_of_plane = type_of_plane;
            this.depature_time = depature_time;
            this.day = "Monday";
            count++;
        }

        //private Airplane()
        //{

        //}

        //static Airline()
        //{
        //    count = 0;
        //}


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
                if (type_of_plane.Length > 100)
                {
                    Console.WriteLine("Incorrect type of plane");
                }
                else
                {
                    type_of_plane = value;
                }
            }
        }

        public static int Info()
        {
            return count;
        }
        public override string ToString()
        {
            return ($"Destination - {destination}, flight number is {flight_number}, type of plane - {type_of_plane}, {depature_time} - depature time on {day}.\n\n");
        }
        /////////////////////////////////////////////////////////

        class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
}
