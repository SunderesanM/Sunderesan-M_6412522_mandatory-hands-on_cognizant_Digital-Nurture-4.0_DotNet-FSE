using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingTheSingletonPattern
{
    //im using sealed keyword because this class may be inherited by other classes...so i want to prevent that.
    public sealed class Logger
    { 
        //The instance of this class is created only once in the application, inside the class itself here.
        private static readonly Logger _instance = new Logger(); //im using private because I want to prevent access to this instance from outside the class.
        static string check;
        private Logger() 
        {
            check = "PROFF!!! This is from only one instance";
            //im using private constructor because..i want to prevent initalization of this class from outside. eg new Logger();
        }

        //this is a public property that returns the instance of this class to the outside.
        public static Logger Instance
        {
            get
            {
                return _instance; //this will return the instance of this class.
            }
        }

        //this is a method that can be used to log messages.
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}"); //this will log the message with the current date and time...just used the DateTime to learn how it works.
            Console.WriteLine(check); //this will print the check variable which is initialized in the constructor.
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //im creating two instances because i want to check if they are the same instance or not.it will return the same instance.
            Logger logger1 =Logger.Instance;
            Logger logger2=Logger.Instance;

            Console.WriteLine(logger1==logger2 ? "It is a SingletonPattern...both is pointing to same instance..success" : "Not singleton");

            //im using the Log method to log messages.
            logger1.Log("This is the message from 1st instance");
            logger2.Log("This is from 2nd instance..but it is pointing to the same instance as logger1 pointing");

            //var logger3 = new Logger(); //this will give an error because the constructor is private and cannot be accessed from outside the class.
            Console.WriteLine("Singleton Pattern successfully learned and implemented by sunder..");
            string waitt=Console.ReadLine(); //terminal is closing immediately, so making the program to wait for user input.
            Console.WriteLine(waitt);
        }
    }
}
