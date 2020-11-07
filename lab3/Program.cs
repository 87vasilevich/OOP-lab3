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

        public void Town(ref string t, out bool flg)
        {
            if(this.destination==t)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }


        public void D_day(ref string t, out bool flg)
        {
            if (this.day == t)
            {
                flg = true;
            }
            else
            {
                flg = false;
            }
        }



        /////////////////////////////////////////////////////////




        class Program
        {
            static void Main(string[] args)
            {
                // SECOND TASK

                Airline u_one = new Airline();
                Airline u_two = new Airline("Gomel", "CY-24", "3:00", "Tuesday");
                Airline u_three = new Airline("Kiev");

                u_one.PlaneType = u_one.type_of_plane;
                u_two.PlaneType = u_two.type_of_plane;
                u_three.PlaneType = u_three.type_of_plane;

                Console.WriteLine(u_one.Equals(u_three)); // Пример. Сравнение 1-го и 3-го рейса

                string[] cities = { "Minsk", "Berlin", "Kiev", "Odessa", "Tokyo", "Moscow", "Paris", "Barcelona" };

                bool flag = false;
                foreach (string city in cities)
                {
                    if (u_one.destination == city)
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

                Console.WriteLine($"\nFor the 2nd task, {count} flight(s) was(were) taken\n\n");




                // THIRD TASK

                

                Airline[] arr = { new Airline("Minsk", "CY-24","13:50","Monday"), new Airline("Gomel", "CY-24", "14:45", "Friday"), new Airline("Odessa", "CY-47", "2:35", "Monday"), new Airline("Minsk", "9 - Boeing 737-800", "4:20", "Sunday")};
                //for(int i =0; i<arr.Length;i++)
                //{
                //    Console.WriteLine("Введите:\n1) пункт назначения ->");
                //    arr[i].destination = Console.ReadLine();

                //    Console.WriteLine("2) тип самолёта ->");
                //    arr[i].type_of_plane = Console.ReadLine();

                //    Console.WriteLine("3) время отправления ->");
                //    arr[i].depature_time = Console.ReadLine();

                //    Console.WriteLine("4) день вылета ->");
                //    arr[i].day = Console.ReadLine();
                //    Console.WriteLine("\n\n");
                //}

                Console.WriteLine("\nВсе авиарейсы:\n\n");

                //Проверка на правильность введённых городов
                for(int i =0; i<arr.Length; i++)
                {
                    flag = false;
                    for (int y =0; y<cities.Length; y++)
                    {
                        if(arr[i].destination==cities[y])
                        {
                            Console.WriteLine($"{arr[i].ToString()}\n================\n");
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        Console.WriteLine($"This city is not on the list. Flight #{i+1}\n================\n");
                    }
                }

                // FOURTH TASK
                Console.WriteLine("\nВведите пункт назначения:");
                string punkt = Console.ReadLine();
                int c = 0;
                Console.WriteLine("\nСписок рейсов для заданного пункта назначения:\n");
                for (int i = 0; i < arr.Length; i++)
                {
                    flag = false;
                    arr[i].Town(ref punkt, out flag);
                    if(flag==true)
                    {
                        Console.WriteLine($"{arr[i].ToString()}\n================\n");
                        c++;
                    }
                }
                if (c==0)
                {
                    Console.WriteLine("\nТаких рейсов нет!\n");
                }


                Console.WriteLine("\nВведите день недели:");
                punkt = Console.ReadLine();
                c = 0;
                Console.WriteLine("\nСписок рейсов для заданного дня недели:\n");
                for (int i = 0; i < arr.Length; i++)
                {
                    flag = false;
                    arr[i].D_day(ref punkt, out flag);
                    if (flag == true)
                    {
                        Console.WriteLine($"{arr[i].ToString()}\n================\n");
                        c++;
                    }
                }
                if (c==0)
                {
                    Console.WriteLine("\nТаких рейсов нет!\n");
                }


                // FIFTH TASK

                var SomeType = new { destination ="Кудыкина Гора", depature_time="00:00"};
                Console.WriteLine(SomeType.destination);

            }
        }
    }
}
