using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace C_charp_lesson_5
{
    delegate void myDel(string text);
    internal class Program
    {
        static void Print(string text)
        {
            Console.WriteLine(text);
        }

        static void WriteToFile(string text)
        {
            string name = "output.txt";
            var sw = new StreamWriter(name,true);
            sw.WriteLine(text);
            sw.Close();

            /*using (var sw01 = new StreamWriter(name,true)) { 
                sw01.WriteLine(text); 
            }*/
        }

        static void Main(string[] args)
        {
            myDel output = Print;
            output += WriteToFile;
            output($"Привет {DateTime.Now}");
            output.Invoke($"Привет {DateTime.Now.ToString("HH:mm:ss.fff")}");
            output.Invoke(null);
            output(null);
            Console.ReadKey();
        }
    }
}
