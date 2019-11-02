using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimus.Services.Proxy;


namespace Minimus
{
    class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            IProxyWeather proxy = new ProxyWeather();
            var response = proxy.weather("rome");
            Console.WriteLine();
            Console.WriteLine($"Ciudad:{response.name}");
            Console.WriteLine($"Temperatura:{response.main.temp}");
            Console.WriteLine($"Min:{response.main.temp_min}");
            Console.WriteLine($"Max:{response.main.temp_max}");
            

            var response2 = proxy.forecast("rome");
            Console.WriteLine();
            int i = 0;
            foreach (var item in response2.list.Take(5))
            {
                i++;
                Console.WriteLine($"{DateTime.Now.AddDays(i).DayOfWeek}");
                Console.WriteLine($"Temperatura:{item.main.temp}");
                Console.WriteLine($"Min:{item.main.temp_min}");
                Console.WriteLine($"Max:{item.main.temp_max}");
            }

            Console.WriteLine();

            IProxyCountry proxyCountry = new ProxyCountry();
            var response3 = proxyCountry.country();

            for (int j = 0; j < response3.Count; j++)
            {
                Console.WriteLine(response3[j].name + ": " + response3[j].capital);
            }

        }

    }
}
