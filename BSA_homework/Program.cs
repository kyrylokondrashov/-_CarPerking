using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BSA_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            while (Menu.Active == true)
            {
                try
                {
                    Menu.ChooseCommande();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: \n {0}", ex.Message);
                }
                finally
                {
                    Console.WriteLine("\n");
                }
            }

        }

    }
}
