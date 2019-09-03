using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IComparable_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Item();
            var b = new Item();
            a.Name = "Bob";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            a.Name = "Carly";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            a.Name = "Edward";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));

            Application app = new Application();
            app.Name = "MY APPLICATION";
            app.initialise();

            //Console.Read();
        }
    }
    public class Item : IComparable
    {
        public string Name;

        public int CompareTo(object o)
        {
            Item that = o as Item;
            return this.Name.CompareTo(that.Name);
        }
    }

    interface ICompareByName{
	    int CompareByName(String str1, string str2);

    }     

    interface ICompareByLength{
	    int CompareByLength(string str1, string str2);
    }

    class Comparison : ICompareByName , ICompareByLength
    {
        public string Name { get; set; }

        public int CompareByName(string str1, string str2)
        {
            return str1.CompareTo(str2);
        }

        public int CompareByLength(string str1, string str2)
        {
            return str1.Length < str2.Length ? -1 : str1.Length > str2.Length? 1 : 0;
        }

    }

    class Application : Comparison
    {
        public void initialise()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine(Name);
                Console.WriteLine("First string?");
                string str1 = Console.ReadLine();
                Console.WriteLine("Second string?");
                string str2 = Console.ReadLine();

                Console.WriteLine(EvaluateInputs(str1, str2));
                Console.WriteLine("Exit? [Y/N] ");
                string exit = Console.ReadLine().ToLower();
                run = exit.Equals("y") ? false : true;
            }
        }

        private string EvaluateInputs(string str1, string str2)
        {
            str1 = str1.Trim();
            str2 = str2.Trim();

            string returnStr = "";
            switch(CompareByName(str1, str2)){
                case -1:
                    returnStr += str1 + " comes before " + str2;
                    break;
                case 0:
                    returnStr += str1 + " is the same as " + str2;
                    break;
                case 1:
                    returnStr += str1 + " comes after " + str2;
                    break;
            }

            returnStr += "\n";

            switch (CompareByLength(str1, str2))
            {
                case -1:
                    returnStr += str1 + " is shorter in length than " + str2;
                    break;
                case 0:
                    returnStr += str1 + " is the same length as " + str2;
                    break;
                case 1:
                    returnStr += str1 + " is longer in length than " + str2;
                    break;
            }

            return returnStr;
        }
    }
}